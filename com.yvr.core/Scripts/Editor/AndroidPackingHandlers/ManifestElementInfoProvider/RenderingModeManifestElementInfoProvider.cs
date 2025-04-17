using UnityEditor;
using YVR.Core.XR;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class RenderingModeManifestElementInfoProvider : ManifestElementInfoProvider
    {
        public override string manifestElementName => "yvr.software.quadviews";

        private static RenderingModeManifestElementInfoProvider s_Instance;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new RenderingModeManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        public override void HandleManifestElementInfo()
        {
            var renderingModeTagInfo = new ManifestTagInfo("/manifest", "uses-feature",
                                                           "name", "yvr.software.quadviews",
                                                           new[] {"required", "false"});

            renderingModeTagInfo.required = YVRXRSettings.instance.stereoRenderingMode == StereoRenderingMode.QuadViews;
            AndroidManifestHandler.UpdateManifestElement(manifestElementName, renderingModeTagInfo);
        }
    }
}