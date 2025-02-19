using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Management;

namespace YVR.Core.XR
{
    [System.Serializable]
    [XRConfigurationData("YVR", "YVR.Core.XR.YVRXRSettings")]
    public partial class YVRXRSettings : ScriptableObject
    {
        [SerializeField, Tooltip("Use 16-bit depth buffer to save bandwidth")]
        public bool use16BitDepthBuffer = false;

        [SerializeField, Tooltip("Use the same poses for left/right eyes")]
        public bool useMonoscopic = false;

        [SerializeField, Tooltip("Submit default layer on VRWidget")]
        public bool useVRWidget = false;

        [SerializeField,
         Tooltip("Always discarding depth and resolving MSAA color to improve performance, this may break user content, Vulkan only")]
        public bool optimizeBufferDiscards = false;

        [SerializeField, Tooltip("Enable AppSW, Vulkan only")]
        public bool useAppSW = false;

        [SerializeField, Tooltip("Set the Stereo Rendering Method")]
        public StereoRenderingMode stereoRenderingMode = StereoRenderingMode.Multiview;

        [SerializeField, Tooltip("Outer Pass Render Scale, works only when stereoRenderingMode is QuadViews")]
        public float outerPassRenderScale = 1.0f;

        [SerializeField, Tooltip("Inner Pass Render Scale, works only when stereoRenderingMode is QuadViews")]
        public float innerPassRenderScale = 1.0f;

        [SerializeField, Tooltip("Set a PNG format file as system splash screen")]
        public Texture2D OSSplashScreen;

        [SerializeField, Tooltip("Get PassThrough Image in Unity")]
        public bool passthroughProvider = false;

        [SerializeField, Tooltip("Get PassThrough Image in Unity")]
        public bool autoResolve = true;

        [SerializeField, Tooltip("Double RenderPasses")]
        public bool extraRenderPass = false;

        [SerializeField, Tooltip("Set RenderPass Depth")]
        public int extraRenderPassDepth = -1;

        [SerializeField, Tooltip("Only works while rendering mode is QuadViews and extraRenderPass enabled")]
        public float outerExtraPassRenderScale = 1.0f;

        [SerializeField, Tooltip("Only works while rendering mode is QuadViews and extraRenderPass enabled")]
        public float innerExtraPassRenderScale = 1.0f;

        [SerializeField, Tooltip("Is in P3 color space")]
        public bool isP3 = false;

        public static YVRXRSettings xrSettings { get; private set; }

        public ushort GetStereoRenderingMode() { return (ushort) stereoRenderingMode; }

        public void Awake() { xrSettings = this; }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (OSSplashScreen == null)
                return;

            string path = AssetDatabase.GetAssetPath(OSSplashScreen);
            if (Path.GetExtension(path).ToLower() != ".png")
            {
                OSSplashScreen = null;
                Debug.LogError("system splash screen file is not PNG format: " + path);
            }
        }
#endif
    }
}