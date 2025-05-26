using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using YVR.Core.XR;
using Object = UnityEngine.Object;

namespace YVR.Core.ImageTracking
{
    [CreateAssetMenu(fileName = "ToTrackImagesCollectionSO", menuName = "YVR/Image Tracking/ToTrackImagesCollectionSO")]
    public class ToTrackImagesCollectionSO : ScriptableObject
    {
        public List<ToTrackImage> toTrackImages = new();

        private const string k_SaveDataPath = "Assets/XR/Resources/";

        private static readonly string
            s_SettingAssetPath = $"{k_SaveDataPath}{nameof(ToTrackImagesCollectionSO)}.asset";

        private static readonly string s_AssetFilePath =
            $"{Application.dataPath}/XR/Resources/{nameof(ToTrackImagesCollectionSO)}.asset";

        private static ToTrackImagesCollectionSO s_Instance = null;

        protected void OnEnable()
        {
            s_Instance = this;
        }

        public static ToTrackImagesCollectionSO instance
        {
            get
            {
                if (s_Instance != null) return s_Instance;

#if UNITY_EDITOR
                if (File.Exists(s_AssetFilePath))
                {
                    s_Instance = AssetDatabase.LoadAssetAtPath<ToTrackImagesCollectionSO>(s_SettingAssetPath);
                }
                else
                {
                    s_Instance = CreateInstance<ToTrackImagesCollectionSO>();
                    ScriptableObjectUtility.CreateAsset(s_Instance, k_SaveDataPath);
                }
#endif

                return s_Instance;
            }
        }

        public static void UpdateTrackImage(string imageName,Vector2 physicalSize,string imagePath,Object texture)
        {
            var updateImage = new ToTrackImage();
            updateImage.imageId = imageName;
            updateImage.imageFilePath = $"it_{Path.GetFileName(imagePath)}";;
            updateImage.size = physicalSize;
            updateImage.image = (Texture2D)texture;
            var trackImages = instance.toTrackImages;
            for (int i = 0; i < trackImages.Count; i++)
            {
                if (string.IsNullOrEmpty(trackImages[i].imageId) || string.IsNullOrEmpty(trackImages[i].imageFilePath) ||
                    string.IsNullOrEmpty(imagePath) || string.IsNullOrEmpty(imageName))
                {
                    continue;
                }
                if (imageName == trackImages[i].imageId)
                {
                    trackImages[i] = updateImage;
                    break;
                }
            }

            var trackImage = trackImages.Find(tiem => tiem.imageId == imageName);
            if (string.IsNullOrEmpty(trackImage.imageId) && !string.IsNullOrEmpty(imageName))
            {
                instance.toTrackImages.Add(updateImage);
            }
        }
    }
}