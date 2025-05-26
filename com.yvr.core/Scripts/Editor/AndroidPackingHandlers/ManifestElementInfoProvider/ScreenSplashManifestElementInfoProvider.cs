using UnityEditor;
using YVR.Core.XR;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class ScreenSplashManifestElementInfoProvider : ManifestElementInfoProvider
    {
        public override string manifestElementName => "com.yvr.ossplash";

        private static ScreenSplashManifestElementInfoProvider s_Instance;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new ScreenSplashManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        public override void HandleManifestElementInfo()
        {
            bool requiredSplash = YVRXRSettings.instance != null && YVRXRSettings.instance.OSSplashScreen != null;

            var manifestTagInfo = new ManifestTagInfo()
            {
                nodePath = "/manifest/application",
                tag = "meta-data",
                attrName = "name",
                attrValue = manifestElementName,
                attrs = new[] {"value", requiredSplash ? "true" : "false"},
                required = true
            };
            AndroidManifestHandler.UpdateManifestElement(manifestElementName, manifestTagInfo);
        }
    }
}