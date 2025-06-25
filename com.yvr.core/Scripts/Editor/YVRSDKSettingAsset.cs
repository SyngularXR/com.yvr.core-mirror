using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using YVR.Core.XR;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core
{
    public class YVRSDKSettingAsset : ScriptableObject
    {
        public bool ignoreSDKSetting = false;
        public bool appIDChecked = false;
        public List<ManifestTagInfo> manifestTagInfosList = new();
        public List<PackingAssetInfo> packingAssetInfoList;
        public List<string> toDeletePackingAssetList;

        private const string k_SaveDataPath = "Assets/XR/Resources/";
        private static readonly string s_SettingAssetPath = $"{k_SaveDataPath}{nameof(YVRSDKSettingAsset)}.asset";

        private static string s_AssetFilePath =>
            $"{Application.dataPath}/XR/Resources/{nameof(YVRSDKSettingAsset)}.asset";

        private static YVRSDKSettingAsset s_Asset = null;

        public static YVRSDKSettingAsset instance
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
    }
}