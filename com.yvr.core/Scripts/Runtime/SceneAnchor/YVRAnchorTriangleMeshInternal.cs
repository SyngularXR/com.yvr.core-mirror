using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace YVR.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct YVRAnchorTriangleMeshInternal
    {
        public int vertexCapacityInput;
        public int vertexCountOutput;
        public IntPtr verticesIntPtr;
        public int indexCapacityInput;
        public int indexCountOutput;
        public IntPtr indicesIntPtr;
    }
}