using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace YVR.Core.ImageTracking
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TrackedImageInfo
    {
        public XRPose pose;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string imageId;

        public Int32 isActive;
        public float confidence;
        public Int64 timestamp;
        public Vector2 size;
    }
}