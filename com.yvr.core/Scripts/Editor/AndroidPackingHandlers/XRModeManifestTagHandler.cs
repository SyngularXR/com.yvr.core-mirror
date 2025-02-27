using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Internal;
using YVR.Utilities;

namespace YVR.Core.XR
{
    [ExcludeFromDocs]
    [InitializeOnLoad]
    public static class XRModeManifestTagHandler
    {
        private const string k_ToolName = "YVR/Tools/";
        private const string k_MenuItemVROnly = k_ToolName + "VR mode";

        static XRModeManifestTagHandler() { EditorApplication.delayCall += OnDelayCall; }

        private static bool s_VROnly;

        private static YVRSDKSettingAsset asset => YVRAndroidManifestHandler.asset;

        [MenuItem(k_MenuItemVROnly)]
        private static void ToggleVROnly()
        {
            Debug.Log("sss select vr only: " + s_VROnly);

            s_VROnly = !s_VROnly;

            Menu.SetChecked(k_MenuItemVROnly, s_VROnly);

            YVRAndroidManifestHandler.GetOrCreateManifestTagInfo("com.yvr.application.mode", CreateVrOnlyInfo, s_VROnly)
                                     .required = s_VROnly; // YVR Private flag
            GetOrCreateImmerseHMDTagInfo().required = s_VROnly; // OpenXR standard flag

            YVRAndroidManifestHandler.PatchProjectAndroidManifest();

            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("select vr only: " + s_VROnly);
        }

        private static void OnDelayCall()
        {
            ManifestTagInfo immerseHMDTagInfo = GetOrCreateImmerseHMDTagInfo();
            immerseHMDTagInfo.required = s_VROnly;

            s_VROnly = YVRAndroidManifestHandler.GetOrCreateManifestTagInfo("com.yvr.application.mode",
                                                                    CreateVrOnlyInfo, true).required;

            Menu.SetChecked(k_MenuItemVROnly, s_VROnly);

            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static ManifestTagInfo CreateVrOnlyInfo(bool required)
        {
            return new ManifestTagInfo
            {
                nodePath = "/manifest/application",
                tag = "meta-data",
                attrName = "name",
                attrValue = "com.yvr.application.mode",
                attrs = new[] {"value", "vr_only"},
                required = required,
                modifyIfFound = true
            };
        }


        private static ManifestTagInfo GetOrCreateImmerseHMDTagInfo()
        {
            ManifestTagInfo immerseHMDTagInfo = asset.manifestTagInfosList.Find(info => info.attrValue ==
                                                                                    "org.khronos.openxr.intent.category.IMMERSIVE_HMD");
            if (immerseHMDTagInfo != null) return immerseHMDTagInfo;

            immerseHMDTagInfo = CreateImmerseHMDTagInfo(true);
            asset.manifestTagInfosList.Add(immerseHMDTagInfo);

            return immerseHMDTagInfo;

            static ManifestTagInfo CreateImmerseHMDTagInfo(bool required)
            {
                return new ManifestTagInfo
                {
                    nodePath = "/manifest/application/activity/intent-filter",
                    tag = "category",
                    attrName = "name",
                    attrValue = "org.khronos.openxr.intent.category.IMMERSIVE_HMD",
                    attrs = Array.Empty<string>(),
                    required = required,
                    modifyIfFound = true
                };
            }
        }
    }
}