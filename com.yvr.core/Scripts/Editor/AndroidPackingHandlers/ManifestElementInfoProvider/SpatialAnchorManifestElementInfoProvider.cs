using UnityEditor;
using YVR.Core.XR;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class SpatialAnchorManifestElementInfoProvider : ManifestElementInfoProvider
    {
        private static SpatialAnchorManifestElementInfoProvider s_Instance;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new SpatialAnchorManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        public sealed override string manifestElementName => "com.yvr.permission.USE_ANCHOR_API";

        private SpatialAnchorManifestElementInfoProvider()
        {
            ManifestTagInfo existInfo = AndroidManifestHandler.GetManifestTagInfo(manifestElementName);
            YVRXRSettings.instance.requireSpatialAnchor = existInfo is {required: true};
        }

        public override void HandleManifestElementInfo()
        {
            var manifestInfo = new ManifestTagInfo("/manifest", "uses-permission", "name", manifestElementName);
            manifestInfo.required
                = YVRXRSettings.instance.requireSpatialAnchor || YVRXRSettings.instance.requireSceneAnchor;

            AndroidManifestHandler.UpdateManifestElement(manifestElementName, manifestInfo);
        }
    }
}