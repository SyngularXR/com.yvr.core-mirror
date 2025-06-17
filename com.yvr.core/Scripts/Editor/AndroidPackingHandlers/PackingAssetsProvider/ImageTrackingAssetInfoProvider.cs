using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using YVR.Core.ImageTracking;
using YVR.Utilities;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class ImageTrackingAssetInfoProvider : PackingAssetsInfoProvider, IPreprocessBuildWithReport
    {
        private static ImageTrackingAssetInfoProvider s_Instance;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new ImageTrackingAssetInfoProvider();
            PackingAssetHandler.packingAssetsInfoProviders.Add(s_Instance);
        }

        private static YVRSDKSettingAsset asset => YVRSDKSettingAsset.instance;

        public int callbackOrder => 9000;

        public void OnPreprocessBuild(BuildReport _)
        {
            EditorUtility.SetDirty(ToTrackImagesCollectionSO.instance);
            AssetDatabase.SaveAssets();
            AddTrackImagesCollectionSOToPreload();
        }

        private void AddTrackImagesCollectionSOToPreload()
        {
            var preloadedAssets = PlayerSettings.GetPreloadedAssets();
            Object assetToAdd = ToTrackImagesCollectionSO.instance;
            if (System.Array.Exists(preloadedAssets, a => a == assetToAdd))
            {
                return;
            }

            var newPreloadedAssets = new Object[preloadedAssets.Length + 1];
            preloadedAssets.CopyTo(newPreloadedAssets, 0);
            newPreloadedAssets[preloadedAssets.Length] = assetToAdd;
            PlayerSettings.SetPreloadedAssets(newPreloadedAssets);
        }

        public override void HandlePackingAssetsInfo(string path)
        {
            string assetPath = Path.Combine(path, "src/main/assets");
            string[] files = Directory.GetFiles(assetPath, "it_*");

            var toTrackImgColl = ToTrackImagesCollectionSO.instance;

            List<PackingAssetInfo> packedAssetInfoList = asset.packingAssetInfoList;
            List<ToTrackImage> toTrackImages = toTrackImgColl.toTrackImages;
            IEnumerable<PackingAssetInfo> toDeleteAssets = packedAssetInfoList.Where(toPackAssetInfo =>
            {
                return toPackAssetInfo.usage is "ImageTracking" &&
                       !toTrackImages.Exists(image =>
                       {
                           string imagePath = image.imageFilePath.Replace("it_", "");
                           return toPackAssetInfo.unityAssetPath.Contains(imagePath);
                       });
                ;
            });

            toDeleteAssets.ToList().ForEach(toDelete =>
            {
                if (toDelete.apkAssetPath != null)
                {
                    asset.toDeletePackingAssetList.Add(toDelete.apkAssetPath);
                    if (files.Contains(toDelete.apkAssetPath))
                    {
                        FileUtil.DeleteFileOrDirectory(toDelete.apkAssetPath);
                    }
                }

                packedAssetInfoList.Remove(toDelete);
            });

            toTrackImgColl.toTrackImages.Where(imageInfo => imageInfo.image != null).ForEach(imageInfo =>
            {
                string imageTarget = Path.Combine(assetPath, $"{imageInfo.imageFilePath}");
                string imageFileName = imageInfo.imageFilePath.Replace("it_", "");


                asset.packingAssetInfoList ??= new List<PackingAssetInfo>();
                PackingAssetInfo assetInfo = packedAssetInfoList.Find(info => info.usage is "ImageTracking" &&
                                                                              info.unityAssetPath
                                                                                 .Contains(imageFileName));
                if (assetInfo == null)
                {
                    assetInfo = new PackingAssetInfo();
                    asset.packingAssetInfoList.Add(assetInfo);
                }

                assetInfo.unityAssetPath = AssetDatabase.GetAssetPath(imageInfo.image);
                assetInfo.apkAssetPath = imageTarget;

                assetInfo.usage = "ImageTracking";
            });
        }
    }
}