using UnityEditor;
using UnityEditor.Android;
using YVR.Utilities;

namespace YVR.Core.XR
{
    public class OpenXRLoaderManifestTagHandler : IPostGenerateGradleAndroidProject
    {
        public int callbackOrder => 1000;

        private static string s_OpenXRPermission = "org.khronos.openxr.permission.OPENXR";
        private static string s_OpenXRSystemPermission = "org.khronos.openxr.permission.OPENXR_SYSTEM";

        private static string s_QueryAuthorities
            = "org.khronos.openxr.runtime_broker;org.khronos.openxr.system_runtime_broker";

        private static string s_QueryRuntimeService = "org.khronos.openxr.OpenXRRuntimeService";
        private static string s_QueryAPILayer = "org.khronos.openxr.OpenXRApiLayerService";

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            _ = YVRAndroidManifestHandler.GetOrCreateManifestTagInfo(s_OpenXRSystemPermission,
                                                                     CreateOpenXRRuntimePermissionTag);
            _ = YVRAndroidManifestHandler.GetOrCreateManifestTagInfo(s_OpenXRPermission,
                                                                     CreateOpenXRPermissionTag);
            _ = YVRAndroidManifestHandler.GetOrCreateManifestTagInfo(s_QueryAuthorities, CreateOpenXRProviderQueries);
            _ = YVRAndroidManifestHandler.GetOrCreateManifestTagInfo(s_QueryRuntimeService,
                                                                     CreateOpenXRRuntimeServiceQueries);
            _ = YVRAndroidManifestHandler.GetOrCreateManifestTagInfo(s_QueryAPILayer, CreateOpenXRApiLayerQueries);

            YVRAndroidManifestHandler.PatchProjectAndroidManifest();
            EditorUtility.SetDirty(YVRAndroidManifestHandler.asset);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static ManifestTagInfo CreateOpenXRPermissionTag()
        {
            return new ManifestTagInfo
            {
                nodePath = "/manifest",
                tag = "uses-permission",
                attrName = "name",
                attrValue = s_OpenXRPermission,
                required = true,
                modifyIfFound = true
            };
        }

        private static ManifestTagInfo CreateOpenXRRuntimePermissionTag()
        {
            return new ManifestTagInfo
            {
                nodePath = "/manifest",
                tag = "uses-permission",
                attrName = "name",
                attrValue = s_OpenXRSystemPermission,
                required = true,
                modifyIfFound = true
            };
        }

        private static ManifestTagInfo CreateOpenXRProviderQueries()
        {
            return new ManifestTagInfo
            {
                nodePath = "/manifest/queries",
                tag = "provider",
                attrName = "authorities",
                attrValue = s_QueryAuthorities,
                required = true,
                modifyIfFound = true
            };
        }

        private static ManifestTagInfo CreateOpenXRRuntimeServiceQueries()
        {
            return new ManifestTagInfo
            {
                nodePath = "/manifest/queries",
                tag = "intent/action",
                attrName = "name",
                attrValue = s_QueryRuntimeService,
                required = true,
                modifyIfFound = true,
            };
        }

        private static ManifestTagInfo CreateOpenXRApiLayerQueries()
        {
            return new ManifestTagInfo
            {
                nodePath = "/manifest/queries",
                tag = "intent/action",
                attrName = "name",
                attrValue = s_QueryAPILayer,
                required = true,
                modifyIfFound = true,
            };
        }
    }
}