using System.Runtime.InteropServices;
using UnityEngine;

namespace YVR.Core.ImageTracking
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ImageTemplateInfo
    {
        public float physicalWidth;
        public float physicalHeight;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string imageId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string templatePath;

        public ImageTemplateInfo(ToTrackImage toTrackImage)
        {
            physicalWidth = toTrackImage.size.x;
            physicalHeight = toTrackImage.size.y;
            imageId = toTrackImage.imageId;
            templatePath = (toTrackImage.image == null ? "file://" : "apk://") + toTrackImage.imageFilePath;
        }
    }
}