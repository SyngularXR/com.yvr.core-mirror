using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace YVR.Core
{
    public class EyeTrackingData
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct EyeGazesState
        {
            public EyeGazeState leftEyeGaze;
            public EyeGazeState rightEyeGaze;
            public Int64 time;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EyeGazeState
        {
            public Vector3 position;
            public Quaternion rotation;
            public float confidence;
            public bool isValid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EyeGazePose
        {
            [MarshalAs(UnmanagedType.U1)] public bool isValid;
            public Quaternion orientation;
            public Vector3 position;
        }
    }
}