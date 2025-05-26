using UnityEngine;
using UnityEngine.XR.Management;

namespace YVR.Core.XR
{
    [System.Serializable]
    [XRConfigurationData("YVR", "YVR.Core.XR.YVRXRSettings")]
    public class YVRXRSettings : ScriptableObject
    {
        private static YVRXRSettings s_Instance = null;

        public static YVRXRSettings instance
        {
            get
            {
                if (s_Instance != null) return s_Instance;
#if UNITY_EDITOR
                UnityEditor.EditorBuildSettings.TryGetConfigObject("YVR.Core.XR.YVRXRSettings", out s_Instance);
                return s_Instance;
#endif
                return null;
            }
        }

        [SerializeField, Tooltip("Use 16-bit depth buffer to save bandwidth")]
        public bool use16BitDepthBuffer = false;

        [SerializeField, Tooltip("Use the same poses for left/right eyes")]
        public bool useMonoscopic = false;

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

        public bool require6Dof = true;
        public HandTrackingSupport handTrackingSupport = HandTrackingSupport.ControllersOnly;
        public YVRFeatureSupport eyeTrackingSupport = YVRFeatureSupport.None;
        public bool requireSpatialAnchor = false;
        public bool requireSceneAnchor = false;
        public bool LBESupport = false;

        public ushort GetStereoRenderingMode() { return (ushort) stereoRenderingMode; }

        public void Awake() { s_Instance = this; }
    }
}