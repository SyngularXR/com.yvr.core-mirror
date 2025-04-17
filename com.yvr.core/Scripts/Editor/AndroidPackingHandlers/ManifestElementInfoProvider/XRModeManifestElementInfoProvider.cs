using UnityEditor;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class XRModeManifestElementInfoProvider : ManifestElementInfoProvider
    {
        private static XRModeManifestElementInfoProvider s_Instance;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new XRModeManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        public override string manifestElementName => "org.khronos.openxr.intent.category.IMMERSIVE_HMD";

        public override void HandleManifestElementInfo()
        {
            var info = new ManifestTagInfo("/manifest/application/activity/intent-filter",
                                           "category", "name",
                                           manifestElementName);

            AndroidManifestHandler.UpdateManifestElement(manifestElementName, info);
        }
    }
}