using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace YVR.Core
{
    public struct YVRPlaneDetectorLocation
    {
        public ulong planeId;
        public YVRSpaceLocationFlags locationFlags;
        public PoseData pose;
        public Vector2 extents;
        public YVRPlaneDetectorOrientation orientation;
        public YVRPlaneDetectorSemanticType semanticType;
        public YVRPlaneChangeState changeState;
        public uint polygonBufferCount;

        public override string ToString()
        {
            return $"planeId:{planeId},locationFlags:{locationFlags}," +
                   $"pose:{pose},extents:{extents},orientation:{orientation},semanticType:{semanticType}," +
                   $"changeState:{changeState},polygonBufferCount:{polygonBufferCount}";        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct YVRPlaneDetectorLocationInternal
    {
        public int type;
        public IntPtr next;
        public ulong planeId;
        public YVRSpaceLocationFlags locationFlags;
        public PoseData pose;
        public Vector2 extents;
        public YVRPlaneDetectorOrientation orientation;
        public YVRPlaneDetectorSemanticType semanticType;
        public YVRPlaneChangeState changeState;
        public uint polygonBufferCount;
        public override string ToString()
        {
            return $"type:{type},next:{next},planeId:{planeId},locationFlags:{locationFlags}," +
                   $"pose:{pose},extents:{extents},orientation:{orientation},semanticType:{semanticType}," +
                   $"changeState:{changeState},polygonBufferCount:{polygonBufferCount}";
        }
    }

}