using System;
using System.Runtime.InteropServices;

namespace YVR.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PassthroughColorLutData
    {
        public uint BufferSize;
        public IntPtr Buffer;
    }
}