using UnityEditor;
using UnityEngine;
using System.IO;
using YVR.Utilities;
using UnityEditor.Android;
using UnityEngine.Internal;
using System;

namespace YVR.Core.XR
{
    [ExcludeFromDocs]
    public class YVRAndroidManifestHandler : IPostGenerateGradleAndroidProject
    {
        private const string k_SaveDataPath = "Assets/XR/Resources/";
        private static readonly string s_SettingAssetPath = $"{k_SaveDataPath}{nameof(YVRSDKSettingAsset)}.asset";

        private static readonly string s_AssetFilePath =
            $"{Application.dataPath}/XR/Resources/{nameof(YVRSDKSettingAsset)}.asset";

        private static YVRSDKSettingAsset s_Asset = null;

        public static YVRSDKSettingAsset asset
        {
            get
            {
                if (s_Asset != null) return s_Asset;

                if (File.Exists(s_AssetFilePath))
                {
                    s_Asset = AssetDatabase.LoadAssetAtPath<YVRSDKSettingAsset>(s_SettingAssetPath);
                }
                else
                {
                    s_Asset = ScriptableObject.CreateInstance<YVRSDKSettingAsset>();
                    ScriptableObjectUtility.CreateAsset(s_Asset, k_SaveDataPath);
                }

                return s_Asset;
            }
        }

        public int callbackOrder => 9999;

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            AssetPreprocessor.CopyAsset(asset.assetInfoList); // Some feature, like os splash screen require asset copy
            PatchApkAndroidManifest(path);
        }


        public static ManifestTagInfo GetOrCreateManifestTagInfo<T>(string condition,
                                                            Func<T, ManifestTagInfo> createFunc, T param)
        {
            ManifestTagInfo manifestTagInfo = asset.manifestTagInfosList.Find(info => info.attrValue == condition);
            if (manifestTagInfo != null) return manifestTagInfo;
            manifestTagInfo = createFunc.Invoke(param);
            asset.manifestTagInfosList.Add(manifestTagInfo);

            return manifestTagInfo;
        }
        
        public static ManifestTagInfo GetOrCreateManifestTagInfo(string condition,
                                                            Func<ManifestTagInfo> createFunc)
        {
            ManifestTagInfo manifestTagInfo = asset.manifestTagInfosList.Find(info => info.attrValue == condition);
            if (manifestTagInfo != null) return manifestTagInfo;
            manifestTagInfo = createFunc.Invoke();
            asset.manifestTagInfosList.Add(manifestTagInfo);

            return manifestTagInfo;
        }

        public static void PatchProjectAndroidManifest()
        {
            string sourceFile = "Assets/Plugins/Android/AndroidManifest.xml";
            if (File.Exists(sourceFile))
            {
                ManifestPreprocessor.PatchAndroidManifest(asset.manifestTagInfosList, sourceFile);
            }
        }

        private static void PatchApkAndroidManifest(string path)
        {
            string manifestFolder = Path.Combine(path, "src/main");
            string file = manifestFolder + "/AndroidManifest.xml";

            ManifestPreprocessor.PatchAndroidManifest(asset.manifestTagInfosList, file);
        }
    }
}