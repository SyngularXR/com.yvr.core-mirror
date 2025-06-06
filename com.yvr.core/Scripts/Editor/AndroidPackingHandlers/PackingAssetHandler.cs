using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Android;
using YVR.Utilities;

namespace YVR.Core.Editor.Packing
{
    public class PackingAssetHandler : IPostGenerateGradleAndroidProject
    {
        public int callbackOrder => 9001;

        public static HashSet<PackingAssetsInfoProvider> packingAssetsInfoProviders = new();

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            packingAssetsInfoProviders.ForEach(provider => provider.HandlePackingAssetsInfo(path));
            EditorUtility.SetDirty(YVRSDKSettingAsset.instance);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            YVRSDKSettingAsset.instance.packingAssetInfoList.ForEach(assetInfo =>
            {
                FileUtil.ReplaceFile(assetInfo.unityAssetPath, assetInfo.apkAssetPath);
            });

            YVRSDKSettingAsset.instance.toDeletePackingAssetList.ForEach(toDeletePath =>
            {
                FileUtil.DeleteFileOrDirectory(toDeletePath);
            });

            // After deleting the packing asset, clear the list to avoid deleting it again in the next build.
            YVRSDKSettingAsset.instance.toDeletePackingAssetList = new List<string>();
        }
    }
}