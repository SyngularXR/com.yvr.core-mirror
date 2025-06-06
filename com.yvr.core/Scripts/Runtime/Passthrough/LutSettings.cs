using UnityEngine;

namespace YVR.Core
{
    internal struct LutSettings
    {
        public Texture2D colorLutSourceTexture;
        public float lutWeight;
        public bool flipLutY;

        public LutSettings(
            Texture2D colorLutSourceTexture,
            float lutWeight,
            bool flipLutY)
        {
            this.colorLutSourceTexture = colorLutSourceTexture;
            this.lutWeight = lutWeight;
            this.flipLutY = flipLutY;
        }
    }
}