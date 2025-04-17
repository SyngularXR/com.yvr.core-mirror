using UnityEditor;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class OpenXRLoaderManifestElementInfoProvider : ManifestElementInfoProvider
    {
        // As we need to handle several manifest elements here, we do not specific a name for the manifest element
        public override string manifestElementName => null;

        private static OpenXRLoaderManifestElementInfoProvider s_Instance;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new OpenXRLoaderManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        private static string s_OpenXRPermission =
            "org.khronos.openxr.permission.OPENXR";

        private static string s_OpenXRSystemPermission =
            "org.khronos.openxr.permission.OPENXR_SYSTEM";

        private static string s_QueryAuthorities =
            "org.khronos.openxr.runtime_broker;org.khronos.openxr.system_runtime_broker";

        private static string s_QueryRuntimeService =
            "org.khronos.openxr.OpenXRRuntimeService";

        private static string s_QueryAPILayer =
            "org.khronos.openxr.OpenXRApiLayerService";

        public override void HandleManifestElementInfo()
        {
            var systemPermission = new ManifestTagInfo("/manifest", "uses-permission", "name",
                                                       s_OpenXRSystemPermission);
            var openXRPermission = new ManifestTagInfo("/manifest", "uses-permission", "name",
                                                       s_OpenXRPermission);
            var runtimeServiceQueries = new ManifestTagInfo("/manifest/queries", "intent/action", "name",
                                                            s_QueryRuntimeService);
            // var openXRApiLayerQueries = new ManifestTagInfo("/manifest/queries", "intent/action", "name",
            //                                                 s_QueryAPILayer);


            var openXRProviderQueries = new ManifestTagInfo
            {
                nodePath = "/manifest/queries",
                tag = "provider",
                attrName = "authorities",
                attrValue = "org.khronos.openxr.runtime_broker;org.khronos.openxr.system_runtime_broker",
                attrs = null,
                required = true
            };

            var openXRApiLayerQueries = new ManifestTagInfo
            {
                nodePath = "/manifest/queries",
                tag = "intent/action",
                attrName = "name",
                attrValue = "org.khronos.openxr.OpenXRApiLayerService"
            };


            AndroidManifestHandler.UpdateManifestElement(s_OpenXRSystemPermission, systemPermission);
            AndroidManifestHandler.UpdateManifestElement(s_OpenXRPermission, openXRPermission);
            AndroidManifestHandler.UpdateManifestElement(s_QueryAuthorities, openXRProviderQueries);
            AndroidManifestHandler.UpdateManifestElement(s_QueryRuntimeService, runtimeServiceQueries);
            AndroidManifestHandler.UpdateManifestElement(s_QueryAPILayer, openXRApiLayerQueries);
        }
    }
}