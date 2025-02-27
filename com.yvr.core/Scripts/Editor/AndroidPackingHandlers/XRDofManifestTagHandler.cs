using UnityEditor;
using UnityEngine.Internal;
using YVR.Utilities;

namespace YVR.Core.XR
{
    [ExcludeFromDocs]
    [InitializeOnLoad]
    public static class XRDofManifestTagHandler
    {
        private const string k_ToolName = "YVR/Tools/";

        private const string k_MenuItem6Dof = k_ToolName + "Only 6Dof";
        private static bool s_SixDof = true;

        static XRDofManifestTagHandler() { EditorApplication.delayCall += OnDelayCall; }

        private static void OnDelayCall()
        {
            s_SixDof = YVRAndroidManifestHandler.GetOrCreateManifestTagInfo("android.hardware.vr.headtracking",
                                                                    CreateTrackingModeInfo, true).required;
            
            Menu.SetChecked(k_MenuItem6Dof, s_SixDof);

            EditorUtility.SetDirty(YVRAndroidManifestHandler.asset);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        [MenuItem(k_MenuItem6Dof)]
        private static void Toggle6Dof()
        {
            s_SixDof = !s_SixDof;

            ManifestTagInfo tagInfo = YVRAndroidManifestHandler.GetOrCreateManifestTagInfo("android.hardware.vr.headtracking",
             CreateTrackingModeInfo, true);
            tagInfo.attrs = CreateTrackingModeAttrs(s_SixDof);

            Menu.SetChecked(k_MenuItem6Dof, s_SixDof);
            
            EditorUtility.SetDirty(YVRAndroidManifestHandler.asset);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            YVRAndroidManifestHandler.PatchProjectAndroidManifest();
        }

        private static ManifestTagInfo CreateTrackingModeInfo(bool is6Dof)
        {
            return new ManifestTagInfo
            {
                nodePath = "/manifest",
                tag = "uses-feature",
                attrName = "name",
                attrValue = "android.hardware.vr.headtracking",
                attrs = CreateTrackingModeAttrs(is6Dof),
                required = true,
                modifyIfFound = true
            };
        }

        private static string[] CreateTrackingModeAttrs(bool is6Dof)
        {
            return new[] {"version", "1", "required", is6Dof ? "true" : "false"};
        }
    }
}