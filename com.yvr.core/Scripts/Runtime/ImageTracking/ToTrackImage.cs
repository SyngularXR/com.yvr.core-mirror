using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace YVR.Core.ImageTracking
{
    [Serializable]
    public struct ToTrackImage
    {
        public string imageId;
        public Texture2D image;
        public Vector2 size;
        public string imageFilePath;

        public ToTrackImage(string imageId, Texture2D image, Vector2 size)
        {
            this.imageId = imageId;
            this.image = image;
            this.size = size;
            imageFilePath = string.Empty;
        }
    }
}