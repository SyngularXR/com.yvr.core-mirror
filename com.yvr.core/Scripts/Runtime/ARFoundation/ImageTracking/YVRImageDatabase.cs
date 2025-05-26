#if XR_ARFOUNDATION_5 || XR_ARFOUNDATION_6

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace YVR.Core.ARFoundation.ImageTracking
{
    public class YVRImageDatabase : RuntimeReferenceImageLibrary
    {
        public readonly List<XRReferenceImage> k_Images = new();
        public override int count => k_Images.Count;
        protected override XRReferenceImage GetReferenceImageAt(int index) => k_Images[index];

        public YVRImageDatabase(XRReferenceImageLibrary library)
        {
            if (library != null)
            {
                foreach (var image in library)
                {
                    k_Images.Add(image);
                }
            }
        }

        public bool TryGetReferenceImageWithName(string name, out XRReferenceImage image)
        {
            foreach (var referenceImage in k_Images)
            {
                if (referenceImage.name == name)
                {
                    image = referenceImage;
                    return true;
                }
            }
            image = default;
            return false;
        }

    }
}
#endif