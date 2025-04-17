using UnityEditor;
using YVR.Core.XR;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class SpatialSceneManifestElementInfoProvider : ManifestElementInfoProvider
    {
        private static SpatialSceneManifestElementInfoProvider s_Instance;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new SpatialSceneManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        public sealed override string manifestElementName => "com.yvr.permission.USE_SCENE";

        private SpatialSceneManifestElementInfoProvider()
        {
            ManifestTagInfo existInfo = AndroidManifestHandler.GetManifestTagInfo(manifestElementName);
            YVRXRSettings.instance.requireSceneAnchor = existInfo is {required: true};
        }

        public override void HandleManifestElementInfo()
        {
            var manifestInfo = new ManifestTagInfo("/manifest", "uses-permission", "name", manifestElementName);
            manifestInfo.required = YVRXRSettings.instance.requireSceneAnchor;
            AndroidManifestHandler.UpdateManifestElement(manifestElementName, manifestInfo);
        }
    }
}