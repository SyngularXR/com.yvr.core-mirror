using System.Runtime.InteropServices;
using UnityEngine.Serialization;

namespace YVR.Core.XR
{
    [StructLayout(LayoutKind.Sequential)]
    public struct YVRXRUserDefinedSettings
    {
        [MarshalAs(UnmanagedType.U1)] public bool use16BitDepthBuffer;

        [MarshalAs(UnmanagedType.U1)] public bool useMonoscopic;

        [MarshalAs(UnmanagedType.U1)] public bool useLinearColorSpace;

        [MarshalAs(UnmanagedType.U1)] public bool UseVRWidget;

        [MarshalAs(UnmanagedType.U1)] public bool useAppSW;

        [MarshalAs(UnmanagedType.U1)] public bool optimizeBufferDiscards;

        [MarshalAs(UnmanagedType.U1)] public bool enablePassthroughProvider;

        [MarshalAs(UnmanagedType.U1)] public bool autoResolve;

        [MarshalAs(UnmanagedType.U1)] public bool extraRenderPass;
        [MarshalAs(UnmanagedType.U1)] public bool isP3;

        public int extraRenderPassDepth;
        public ushort stereoRenderingMode;
        public float outerPassRenderScale; // Only works while rendering mode is QuadViews
        public float innerPassRenderScale; // Only works while rendering mode is QuadViews
        public float outerExtraPassRenderScale; //Only works while rendering mode is QuadViews and extraRenderPass enabled
        public float innerExtraPassRenderScale; //Only works while rendering mode is QuadViews and extraRenderPass enabled
    }
}