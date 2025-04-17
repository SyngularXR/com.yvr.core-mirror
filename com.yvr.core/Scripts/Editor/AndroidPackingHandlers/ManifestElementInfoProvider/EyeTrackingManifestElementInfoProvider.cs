using UnityEditor;
using YVR.Core.XR;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class EyeTrackingManifestElementInfoProvider : ManifestElementInfoProvider
    {
        private static EyeTrackingManifestElementInfoProvider s_Instance;
        private string m_EyePermissionName = "com.yvr.permission.EYE_TRACKING";
        private string m_EyeUsesFeatureName = "yvr.software.eye_tracking";

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new EyeTrackingManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        public override string manifestElementName => m_EyePermissionName;

        private EyeTrackingManifestElementInfoProvider()
        {
            ManifestTagInfo existInfo = AndroidManifestHandler.GetManifestTagInfo(m_EyeUsesFeatureName);
            if (existInfo is {required: true, attrs: {Length: >= 2}})
            {
                string requiredValue = existInfo.attrs[1];
                if (bool.TryParse(requiredValue, out bool isRequired) && isRequired)
                    YVRXRSettings.instance.eyeTrackingSupport = YVRFeatureSupport.Required;
                else
                    YVRXRSettings.instance.eyeTrackingSupport = YVRFeatureSupport.Supported;
            }
            else
            {
                YVRXRSettings.instance.eyeTrackingSupport = YVRFeatureSupport.None;
            }
        }

        public override void HandleManifestElementInfo()
        {
            YVRFeatureSupport support = YVRXRSettings.instance.eyeTrackingSupport;
            var permissionInfo = new ManifestTagInfo("/manifest", "uses-permission", "name", m_EyePermissionName);
            permissionInfo.required = support != YVRFeatureSupport.None;
            bool required = support == YVRFeatureSupport.Required;
            var featureInfo = new ManifestTagInfo("/manifest", "uses-feature", "name", m_EyeUsesFeatureName,
                                                  new[] {"required", required.ToString().ToLower()});
            featureInfo.required = support != YVRFeatureSupport.None;

            AndroidManifestHandler.UpdateManifestElement(m_EyePermissionName, permissionInfo);
            AndroidManifestHandler.UpdateManifestElement(m_EyeUsesFeatureName, featureInfo);
        }
    }
}