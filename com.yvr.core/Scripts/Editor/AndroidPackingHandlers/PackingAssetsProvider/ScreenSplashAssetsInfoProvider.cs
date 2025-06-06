using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using YVR.Core.XR;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class ScreenSplashAssetsInfoProvider : PackingAssetsInfoProvider
    {
        private static ScreenSplashAssetsInfoProvider s_Instance;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new ScreenSplashAssetsInfoProvider();
            PackingAssetHandler.packingAssetsInfoProviders.Add(s_Instance);
        }

        private static YVRSDKSettingAsset asset => YVRSDKSettingAsset.instance;

        public override void HandlePackingAssetsInfo(string path)
        {
            string splashTargetPath = Path.Combine(path, "src/main/assets") + "/vr_splash.png";
            asset.packingAssetInfoList ??= new List<PackingAssetInfo>();

            if (YVRXRSettings.instance?.OSSplashScreen != null)
            {
                string unityAssetPath = AssetDatabase.GetAssetPath(YVRXRSettings.instance.OSSplashScreen);
                PackingAssetInfo assetInfo
                    = asset.packingAssetInfoList.Find(info => info.unityAssetPath == unityAssetPath);
                if (assetInfo == null)
                {
                    assetInfo = new PackingAssetInfo();
                    asset.packingAssetInfoList.Add(assetInfo);
                }

                assetInfo.usage = "Splash";
                assetInfo.unityAssetPath = unityAssetPath;
                assetInfo.apkAssetPath = splashTargetPath;
            }
            else
            {
                PackingAssetInfo assetInfo = asset.packingAssetInfoList.Find(info => info.usage == "Splash");
                asset.packingAssetInfoList.Remove(assetInfo);
                if (assetInfo?.apkAssetPath != null)
                    asset.toDeletePackingAssetList.Add(assetInfo.apkAssetPath);
            }
        }
    }
}