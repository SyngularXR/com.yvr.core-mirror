#if XR_ARFOUNDATION_5 || XR_ARFOUNDATION_6
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.XR.ARSubsystems;

namespace YVR.Core.ARFoundation.Plane
{
    public class YVRPlaneSubsystem : XRPlaneSubsystem
    {
        internal const string k_SubsystemId = "YVRPlane";

        const string k_AndroidScenePermission = "com.yvr.permission.USE_SCENE";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            var planeSubsystemCinfo = new XRPlaneSubsystemDescriptor.Cinfo
            {
                id = k_SubsystemId,
                providerType = typeof(YVRPlaneProvider),
                subsystemTypeOverride = typeof(YVRPlaneSubsystem),
                supportsHorizontalPlaneDetection = true,
                supportsVerticalPlaneDetection = true,
                supportsArbitraryPlaneDetection = false,
                supportsBoundaryVertices = true,
                supportsClassification = false
            };
#if XR_ARFOUNDATION_6
            XRPlaneSubsystemDescriptor.Register(planeSubsystemCinfo);
#endif
#if XR_ARFOUNDATION_5
            XRPlaneSubsystemDescriptor.Create(planeSubsystemCinfo);
#endif
        }

        private class YVRPlaneProvider : Provider
        {
            private static Dictionary<ulong,YVRPlaneDetectorLocation> m_CachePlanes = new ();
            private static Dictionary<TrackableId,YVRPlaneDetectorLocation> m_CurrentPlanes = new ();
            private static List<BoundedPlane> m_AddedPlane = new();
            private static List<BoundedPlane> m_UpdatePlane = new();
            private static List<TrackableId> m_RemovedPlane = new();

            private TrackableId m_SubsumedBy = new TrackableId(0, 1);

            public override PlaneDetectionMode requestedPlaneDetectionMode
            {
                get
                {
                    return PlaneDetectionMode.Horizontal | PlaneDetectionMode.Vertical;
                }
                set { }
            }

            public override PlaneDetectionMode currentPlaneDetectionMode
             => PlaneDetectionMode.Horizontal | PlaneDetectionMode.Vertical;


            public override void Start()
            {
#if UNITY_ANDROID
                ScenePermissionRequest();
#endif
                YVRPlaneDetectorMgr.getPlanesAction += OnGetPlanes;
                YVRPlaneDetectorMgr.instance.CreatePlaneDetector();
            }

            private void ScenePermissionRequest()
            {
                if (!Permission.HasUserAuthorizedPermission(k_AndroidScenePermission))
                {
                    var callbacks = new PermissionCallbacks();
                    callbacks.PermissionDenied += Denied;
                    callbacks.PermissionGranted += Granted;
                    Permission.RequestUserPermission(k_AndroidScenePermission, callbacks);
                }
            }

            private void Denied(string permission)  => Debug.LogWarning(
                $"Plane detection requires system permission {k_AndroidScenePermission}, but permission was not granted.");
            private void Granted(string permission) => Debug.Log($"{permission} Granted");

            public override void Stop()
            {
                YVRPlaneDetectorMgr.instance.EndPlaneDetector();
            }

            public override void Destroy() { }

            private TrackableId PlaneIdToTrackableId(ulong id)
            {
                return new TrackableId(id, 0);
            }

            private ulong TrackableIdToPlaneId(TrackableId trackableId)
            {
                return trackableId.subId1;
            }

            private void OnGetPlanes(List<YVRPlaneDetectorLocation> planes)
            {
                m_CurrentPlanes.Clear();
                foreach (var plane in planes)
                {
                    m_CurrentPlanes.Add(PlaneIdToTrackableId(plane.planeId),plane);
                    if (!m_CachePlanes.TryAdd(plane.planeId,plane))
                    {
                        m_CachePlanes[plane.planeId] = plane;
                    }

                    if (plane.changeState == YVRPlaneChangeState.Removed)
                    {
                        if (m_CachePlanes.ContainsKey(plane.planeId))
                            m_CachePlanes.Remove(plane.planeId);
                    }
                }
            }

            private BoundedPlane CreateBoundedPlane(YVRPlaneDetectorLocation plane)
            {
                Pose pose = new Pose()
                {
                    position = plane.pose.position,
                    rotation = plane.pose.orientation
                };

                BoundedPlane boundedPlane = new BoundedPlane(
                    PlaneIdToTrackableId(plane.planeId),
                    m_SubsumedBy,
                    pose,
                    Vector2.zero,
                    plane.extents,
                    GetPlaneAlignment(plane.orientation),
                    GetPlaneTrackingState(plane.changeState),
                    IntPtr.Zero,
                    PlaneClassification.None);
                return boundedPlane;
            }

            private TrackingState GetPlaneTrackingState(YVRPlaneChangeState changeState)
            {
                TrackingState trackingState = TrackingState.None;
                switch (changeState)
                {
                    case YVRPlaneChangeState.Added:
                    case YVRPlaneChangeState.Update:
                        trackingState =TrackingState.Tracking;
                        break;
                    case YVRPlaneChangeState.Removed:
                        trackingState = TrackingState.None;
                        break;
                }

                return trackingState;
            }

            private PlaneAlignment GetPlaneAlignment(YVRPlaneDetectorOrientation orientation)
            {
                PlaneAlignment planeAlignment;
                switch (orientation)
                {
                    case YVRPlaneDetectorOrientation.XR_PLANE_DETECTOR_ORIENTATION_HORIZONTAL_UPWARD_EXT:
                        planeAlignment = PlaneAlignment.HorizontalUp;
                        break;
                    case YVRPlaneDetectorOrientation.XR_PLANE_DETECTOR_ORIENTATION_HORIZONTAL_DOWNWARD_EXT:
                        planeAlignment = PlaneAlignment.HorizontalDown;
                        break;
                    case YVRPlaneDetectorOrientation.XR_PLANE_DETECTOR_ORIENTATION_VERTICAL_EXT:
                        planeAlignment = PlaneAlignment.Vertical;
                        break;
                    case YVRPlaneDetectorOrientation.XR_PLANE_DETECTOR_ORIENTATION_ARBITRARY_EXT:
                        planeAlignment = PlaneAlignment.NotAxisAligned;
                        break;
                    default:
                        planeAlignment = PlaneAlignment.None;
                        break;
                }

                return planeAlignment;
            }

            public override TrackableChanges<BoundedPlane> GetChanges(BoundedPlane defaultPlane, Allocator allocator)
            {
                m_AddedPlane.Clear();
                m_UpdatePlane.Clear();
                m_RemovedPlane.Clear();
                foreach (var plane in m_CurrentPlanes)
                {
                    BoundedPlane boundedPlane = CreateBoundedPlane(plane.Value);
                    switch (plane.Value.changeState)
                    {
                        case YVRPlaneChangeState.Added:
                            m_AddedPlane.Add(boundedPlane);
                            break;
                        case YVRPlaneChangeState.Update:
                            m_UpdatePlane.Add(boundedPlane);
                            break;
                        case YVRPlaneChangeState.Removed:
                            m_RemovedPlane.Add(boundedPlane.trackableId);
                            break;
                    }
                }

                var added = new NativeArray<BoundedPlane>(m_AddedPlane.ToArray(), allocator);
                var update = new NativeArray<BoundedPlane>(m_UpdatePlane.ToArray(), allocator);
                var removed = new NativeArray<TrackableId>(m_RemovedPlane.ToArray(), allocator);

                return TrackableChanges<BoundedPlane>.CopyFrom(added,update,removed,allocator);
            }

            public override void GetBoundary(TrackableId trackableId, Allocator allocator, ref NativeArray<Vector2> boundary)
            {
                if (m_CachePlanes.TryGetValue(TrackableIdToPlaneId(trackableId), out var plane))
                {
                    List<YVRPlaneDetectorPolygonBuffer> buffers = YVRPlaneDetectorMgr.instance.GetPlanePolygonBuffer(plane);
                    var vector2s = buffers.First().pointVectors;
                    boundary = new NativeArray<Vector2>(vector2s.Count, allocator);
                    for (int i = 0; i < vector2s.Count; i++)
                    {
                        boundary[i] = vector2s[i];
                    }
                }
                else
                {
                    boundary = new NativeArray<Vector2>();
                }
            }

        }
    }
}
#endif