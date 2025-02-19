using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace YVR.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct YVRPlaneDetectorLocationsInternal
    {
        public int type;
        public IntPtr next;
        public uint planeLocationCapacityInput;
        public uint planeLocationCountOutput;
        public IntPtr planeLocations; // Use IntPtr to represent a pointer to XrPlaneDetectorLocationYVR

        public override string ToString()
        {
            return
                $"type:{type},next:{next},planeLocationCapacityInput:{planeLocationCapacityInput}," +
                $"planeLocationCountOutput:{planeLocationCountOutput},planeLocations:{planeLocations}";
        }
    }
}