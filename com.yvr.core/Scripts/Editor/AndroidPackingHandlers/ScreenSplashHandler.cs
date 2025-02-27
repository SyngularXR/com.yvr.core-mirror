using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Android;
using YVR.Utilities;

namespace YVR.Core.XR
{
    public class ScreenSplashHandler : IPostGenerateGradleAndroidProject
    {
        private static YVRSDKSettingAsset asset => YVRAndroidManifestHandler.asset;

        private static void GenerateSplashScreenImageAsset(string path)
        {
            EditorBuildSettings.TryGetConfigObject("YVR.Core.XR.YVRXRSettings", out YVRXRSettings settings);

            string splashScreenAssetFolder = Path.Combine(path, "src/main/assets");
            string splashScreenAssetPath = splashScreenAssetFolder + "/vr_splash.png";
            if (settings != null && settings.OSSplashScreen != null)
            {
                string splashScreenSourcePath = AssetDatabase.GetAssetPath(settings.OSSplashScreen);

                asset.assetInfoList ??= new List<AssetInfo>();
                AssetInfo assetInfo
                    = asset.assetInfoList.Find(info => info.androidProjectAssetPath == splashScreenAssetPath);
                if (assetInfo == null)
                {
                    assetInfo = new AssetInfo()
                    {
                        unityAssetPath = splashScreenSourcePath, androidProjectAssetPath = splashScreenAssetPath,
                        shouldDelete = false
                    };
                    asset.assetInfoList.Add(assetInfo);
                }
                else
                {
                    int index = asset.assetInfoList.IndexOf(assetInfo);
                    asset.assetInfoList[index].unityAssetPath = splashScreenSourcePath;
                    asset.assetInfoList[index].androidProjectAssetPath = splashScreenAssetPath;
                    asset.assetInfoList[index].shouldDelete = false;
                }
            }
            else
            {
                asset.assetInfoList ??= new List<AssetInfo>();
                AssetInfo shouldDeleteInfo
                    = asset.assetInfoList.Find(info => info.androidProjectAssetPath == splashScreenAssetPath);
                if (shouldDeleteInfo != null)
                {
                    int index = asset.assetInfoList.IndexOf(shouldDeleteInfo);
                    asset.assetInfoList[index].shouldDelete = true;
                }
            }

            asset.manifestTagInfosList ??= new List<ManifestTagInfo>();

            ManifestTagInfo manifestTagInfo
                = CreateSplashScreenInfo(settings != null && settings.OSSplashScreen != null);
            ManifestTagInfo tagInfo = asset.manifestTagInfosList.Find(info => info.attrValue == "com.yvr.ossplash");
            if (tagInfo == null)
            {
                asset.manifestTagInfosList.Add(manifestTagInfo);
            }
            else
            {
                int index = asset.manifestTagInfosList.IndexOf(tagInfo);
                asset.manifestTagInfosList[index].attrs = manifestTagInfo.attrs;
            }


            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
        }

        private static ManifestTagInfo CreateSplashScreenInfo(bool required)
        {
            return new ManifestTagInfo
            {
                nodePath = "/manifest/application",
                tag = "meta-data",
                attrName = "name",
                attrValue = "com.yvr.ossplash",
                attrs = new[] {"value", required ? "true" : "false"},
                required = true,
                modifyIfFound = true
            };
        }

        public int callbackOrder => 1000;

        public void OnPostGenerateGradleAndroidProject(string path) { GenerateSplashScreenImageAsset(path); }
    }
}