using System.Collections.Generic;
using System.IO;
using UnityEditor;
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

            PackingAssetInfo assetInfo = asset.packingAssetInfoList.Find(info => info.apkAssetPath == splashTargetPath);

            if (YVRXRSettings.instance?.OSSplashScreen != null)
            {
                assetInfo ??= new PackingAssetInfo();
                assetInfo.unityAssetPath = AssetDatabase.GetAssetPath(YVRXRSettings.instance.OSSplashScreen);
                assetInfo.apkAssetPath = splashTargetPath;
                if (!asset.packingAssetInfoList.Contains(assetInfo))
                    asset.packingAssetInfoList.Add(assetInfo);
            }
            else if (assetInfo != null)
            {
                asset.packingAssetInfoList.Remove(assetInfo);
                asset.toDeletePackingAssetList.Add(assetInfo.apkAssetPath);
            }
        }
    }
}