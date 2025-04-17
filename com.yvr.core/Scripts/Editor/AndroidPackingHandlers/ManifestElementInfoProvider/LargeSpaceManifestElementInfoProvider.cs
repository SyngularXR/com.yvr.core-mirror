using UnityEditor;
using YVR.Utilities.Editor.PackingProcessor;
using YVR.Core.XR;

namespace YVR.Core.Editor.Packing
{
    public class LargeSpaceManifestElementInfoProvider : ManifestElementInfoProvider
    {
        private static LargeSpaceManifestElementInfoProvider s_Instance;
        private string m_LargeSpaceUsesFeatureName = "yvr.software.largespace";

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new LargeSpaceManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        public override string manifestElementName => m_LargeSpaceUsesFeatureName;

        private LargeSpaceManifestElementInfoProvider()
        {
            ManifestTagInfo existInfo = AndroidManifestHandler.GetManifestTagInfo(m_LargeSpaceUsesFeatureName);

            YVRXRSettings.instance.LBESupport = existInfo is {required: true, attrs: {Length: >= 1}} &&
                                                bool.TryParse(existInfo.attrs[1], out bool isRequired) && isRequired;
        }

        public override void HandleManifestElementInfo()
        {
            // Assume YVRXRSettings.instance.largeSpaceSupport exists as bool
            bool required = YVRXRSettings.instance.LBESupport;
            var featureInfo = new ManifestTagInfo("/manifest", "uses-feature", "name", m_LargeSpaceUsesFeatureName,
                                                  new[] {"required", required.ToString().ToLower()});
            featureInfo.required = required;

            AndroidManifestHandler.UpdateManifestElement(m_LargeSpaceUsesFeatureName, featureInfo);
        }
    }
}