using UnityEditor;
using UnityEngine;
using YVR.Core.XR;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class HandTrackingManifestElementInfoProvider : ManifestElementInfoProvider
    {
        public override string manifestElementName => null;

        private string m_HandPermissionName = "com.yvr.handtracking.permission.HAND_TRACKING";
        private string m_HandUsesFeatureName = "yvr.software.handtracking";

        private static HandTrackingManifestElementInfoProvider s_Instance;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new HandTrackingManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        private HandTrackingManifestElementInfoProvider()
        {
            ManifestTagInfo existInfo = AndroidManifestHandler.GetManifestTagInfo(m_HandUsesFeatureName);
            if (existInfo is {required: true, attrs: {Length: >= 2}})
            {
                string requiredValue = existInfo.attrs[1];
                if (bool.TryParse(requiredValue, out bool isHandsOnly) && isHandsOnly)
                    YVRXRSettings.instance.handTrackingSupport = HandTrackingSupport.HandsOnly;
                else
                    YVRXRSettings.instance.handTrackingSupport = HandTrackingSupport.ControllersAndHands;
            }
            else
            {
                YVRXRSettings.instance.handTrackingSupport = HandTrackingSupport.ControllersOnly;
            }
        }


        public override void HandleManifestElementInfo()
        {
            HandTrackingSupport handSupports = YVRXRSettings.instance.handTrackingSupport;

            var permissionInfo = new ManifestTagInfo("/manifest", "uses-permission", "name",
                                                     m_HandPermissionName);
            permissionInfo.required = handSupports != HandTrackingSupport.ControllersOnly;
            bool isHandsOnly = handSupports == HandTrackingSupport.HandsOnly;
            var featureInfo = new ManifestTagInfo("/manifest", "uses-feature", "name",
                                                  m_HandUsesFeatureName,
                                                  new[] {"required", isHandsOnly.ToString().ToLower()});
            featureInfo.required = handSupports != HandTrackingSupport.ControllersOnly;

            AndroidManifestHandler.UpdateManifestElement(m_HandPermissionName, permissionInfo);
            AndroidManifestHandler.UpdateManifestElement(m_HandUsesFeatureName, featureInfo);
        }
    }
}