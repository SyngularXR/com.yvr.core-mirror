using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace YVR.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct YVRPlaneDetectorPolygonBuffer
    {
        public List<Vector2> pointVectors;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct YVRPlaneDetectorPolygonBufferInternal
    {
        public int type;
        public IntPtr next;
        public uint vertexCapacityInput;
        public uint vertexCountOutput;
        public IntPtr vertices;
        public override string ToString()
        {
            return $"type:{type},next:{next},vertexCapacityInput:{vertexCapacityInput}," +
                   $"vertexCountOutput:{vertexCountOutput},vertices:{vertices}";
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct YVRPlaneDetectorPolygonBuffersInternal
    {
        public uint bufferCount;
        public IntPtr buffers;
    }
}