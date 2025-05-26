using System;
using System.Collections.Generic;
using AOT;
using UnityEngine;
using YVR.Utilities;

namespace YVR.Core.ImageTracking
{
    public class ImageTrackingMgr : Singleton<ImageTrackingMgr>
    {
        private static Action<TrackedImageInfo> s_ImageTrackingUpdateCallback = null;
        private static Dictionary<string, Action<TrackedImageInfo>> s_ImageIDToCallbackDict = new();

        protected override void OnInit()
        {
            YVRPlugin.Instance.SetImageTrackingUpdateCallback(OnTrackedImageUpdate);
        }

        public void RegisterTrackImageLibrary()
        {
            bool requiredTrack = ToTrackImagesCollectionSO.instance.toTrackImages.Count != 0;
            if (requiredTrack)
            {
                ToTrackImagesCollectionSO.instance.toTrackImages.ForEach(RegisterTemplateTemplate);
            }
        }

        public void SwitchImageTracking(bool enable) { YVRPlugin.Instance.SwitchImageTracking(enable); }

        public void RegisterImageTrackingUpdateCallback(Action<TrackedImageInfo> callback)
        {
            s_ImageTrackingUpdateCallback += callback;
        }

        public void UnRegisterImageTrackingUpdateCallback(Action<TrackedImageInfo> callback)
        {
            s_ImageTrackingUpdateCallback -= callback;
        }

        public void RegisterImageTrackingUpdateCallback(string imageId, Action<TrackedImageInfo> callback)
        {
            if (callback == null) return;

            s_ImageIDToCallbackDict.TryAdd(imageId, null);
            s_ImageIDToCallbackDict[imageId] += callback;
        }

        public void UnRegisterImageTrackingUpdateCallback(string imageId, Action<TrackedImageInfo> callback)
        {
            if (callback == null) return;

            if (!s_ImageIDToCallbackDict.TryGetValue(imageId, out Action<TrackedImageInfo> existingCallback)) return;

            existingCallback -= callback;
            if (existingCallback == null)
            {
                s_ImageIDToCallbackDict.Remove(imageId);
            }
        }

        public void RegisterTemplateTemplate(ToTrackImage image)
        {
            YVRPlugin.Instance.RegisterImageTemplate(new ImageTemplateInfo(image));
        }

        public void UnRegisterImageTemplate(string imageId)
        {
            if (s_ImageIDToCallbackDict.ContainsKey(imageId))
            {
                s_ImageIDToCallbackDict.Remove(imageId);
            }

            YVRPlugin.Instance.UnRegisterImageTemplate(imageId);
        }

        [MonoPInvokeCallback(typeof(Action<TrackedImageInfo>))]
        private static void OnTrackedImageUpdate(TrackedImageInfo trackedImageInfo)
        {
            s_ImageTrackingUpdateCallback?.Invoke(trackedImageInfo);

            if (s_ImageIDToCallbackDict.TryGetValue(trackedImageInfo.imageId, out Action<TrackedImageInfo> callback))
            {
                callback?.Invoke(trackedImageInfo);
            }
        }
    }
}