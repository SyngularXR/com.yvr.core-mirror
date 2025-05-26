#if XR_ARFOUNDATION_5 || XR_ARFOUNDATION_6

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using YVR.Core.ImageTracking;

namespace YVR.Core.ARFoundation.ImageTracking
{
    public class YVRImageTrackingProvider : XRImageTrackingSubsystem.Provider
    {
        private ImageTrackingMgr m_ImageTrackingMgr;
        private static Dictionary<TrackableId, TrackedImageInfo> m_TrackableIdToHandleMap;
        private static List<XRTrackedImage> m_AddedTrackedImages = new();
        private static List<XRTrackedImage> m_UpdateTrackedImages = new();
        private static List<TrackableId> m_RemovedTrackableIds = new();
        private YVRImageDatabase m_ImageDatabase;

        public override void Start()
        {
            m_ImageTrackingMgr = ImageTrackingMgr.instance;
            m_TrackableIdToHandleMap = new();
            m_ImageTrackingMgr.RegisterImageTrackingUpdateCallback(OnImageTrackingUpdate);
        }

        private void OnImageTrackingUpdate(TrackedImageInfo trackedImageInfo)
        {
            m_ImageDatabase.TryGetReferenceImageWithName(trackedImageInfo.imageId,
                out XRReferenceImage referenceImage);
            TrackableId trackableId = GenerateTrackableId(referenceImage.guid);
            if (!m_TrackableIdToHandleMap.TryAdd(trackableId,trackedImageInfo))
            {
                m_TrackableIdToHandleMap[trackableId] = trackedImageInfo;
            }else
            {
                var xrTrackedImage = CreateXRImage(trackedImageInfo,referenceImage);
                m_AddedTrackedImages.Add(xrTrackedImage);
            }
        }

        private TrackableId GenerateTrackableId(Guid guid)
        {
            byte[] bytes = guid.ToByteArray();
            TrackableId trackableId = new TrackableId(BitConverter.ToUInt64(bytes, 0), BitConverter.ToUInt64(bytes, 8));
            return trackableId;
        }

        public override void Stop()
        {
            m_ImageTrackingMgr.SwitchImageTracking(false);
        }

        public override void Destroy()
        {
            m_ImageTrackingMgr.SwitchImageTracking(false);
        }

        public override int requestedMaxNumberOfMovingImages { get; set; }

        public override int currentMaxNumberOfMovingImages { get; }

        private XRTrackedImage CreateXRImage(TrackedImageInfo trackedImageInfo, XRReferenceImage referenceImage)
        {
            var state = trackedImageInfo.confidence > 0.6f ? TrackingState.Tracking : TrackingState.Limited;
            state = trackedImageInfo.isActive == 0 ? TrackingState.None : state;
            var trackedImage = new XRTrackedImage(
                trackableId: GenerateTrackableId(referenceImage.guid),
                sourceImageId: referenceImage.guid,
                pose: new Pose(trackedImageInfo.pose.position, trackedImageInfo.pose.orientation),
                size: trackedImageInfo.size,
                trackingState: state,
                nativePtr: IntPtr.Zero);

            return trackedImage;
        }

        public override TrackableChanges<XRTrackedImage> GetChanges(XRTrackedImage defaultTrackedImage,
            Allocator allocator)
        {
            m_UpdateTrackedImages.Clear();
            m_RemovedTrackableIds.Clear();
            foreach (var trackedImageInfo in m_TrackableIdToHandleMap)
            {
                m_ImageDatabase.TryGetReferenceImageWithName(trackedImageInfo.Value.imageId,
                    out XRReferenceImage referenceImage);
                m_UpdateTrackedImages.Add(CreateXRImage(trackedImageInfo.Value,referenceImage));
            }
            var added = new NativeArray<XRTrackedImage>(m_AddedTrackedImages.ToArray(), allocator);
            m_AddedTrackedImages.Clear();
            var update = new NativeArray<XRTrackedImage>(m_UpdateTrackedImages.ToArray(), allocator);
            var removed = new NativeArray<TrackableId>(m_RemovedTrackableIds.ToArray(), allocator);
            return TrackableChanges<XRTrackedImage>.CopyFrom(added,update,removed,allocator);
        }

        public override RuntimeReferenceImageLibrary imageLibrary
        {
            set
            {
                if (value == null) { return; }
                if (value is YVRImageDatabase database)
                {
                    foreach (var image in database.k_Images)
                    {
                        var trackImage =
                            ToTrackImagesCollectionSO.instance.toTrackImages.Find(toTrackImage =>
                                image.name == toTrackImage.imageId);

                        if (!string.IsNullOrEmpty(trackImage.imageId))
                        {
                            m_ImageTrackingMgr.RegisterTemplateTemplate(trackImage);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException($"The {value.GetType().Name} is not a valid YVR image library.");
                }
            }
        }

        public override RuntimeReferenceImageLibrary CreateRuntimeLibrary(XRReferenceImageLibrary serializedLibrary)
        {
            m_ImageTrackingMgr.SwitchImageTracking(true);
            m_ImageDatabase = new YVRImageDatabase(serializedLibrary);
            return m_ImageDatabase;
        }
    }
}
#endif