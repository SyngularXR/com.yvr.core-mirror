#if XR_ARFOUNDATION_5 || XR_ARFOUNDATION_6
using System;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace YVR.Core.ARFoundation.Camera
{
    public class YVRCameraSubsystem : XRCameraSubsystem
    {
        internal const string k_SubsystemId = "YVRCamera";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
#if XR_ARFOUNDATION_6
        var cameraSubsystemCinfo = new XRCameraSubsystemDescriptor.Cinfo
#endif

#if XR_ARFOUNDATION_5
        var cameraSubsystemCinfo = new XRCameraSubsystemCinfo
#endif
            {
                id = k_SubsystemId,
                providerType = typeof(YVROpenXRProvider),
                subsystemTypeOverride = typeof(YVRCameraSubsystem),
                supportsAverageBrightness = false,
                supportsAverageColorTemperature = false,
                supportsColorCorrection = false,
                supportsDisplayMatrix = false,
                supportsProjectionMatrix = false,
                supportsTimestamp = false,
                supportsCameraConfigurations = false,
                supportsCameraImage = false,
                supportsAverageIntensityInLumens = false,
                supportsFocusModes = false,
                supportsFaceTrackingAmbientIntensityLightEstimation = false,
                supportsFaceTrackingHDRLightEstimation = false,
                supportsWorldTrackingAmbientIntensityLightEstimation = false,
                supportsWorldTrackingHDRLightEstimation = false,
                supportsCameraGrain = false,
            };

#if XR_ARFOUNDATION_5
            XRCameraSubsystem.Register(cameraSubsystemCinfo);
#endif

#if XR_ARFOUNDATION_6
            XRCameraSubsystemDescriptor.Register(cameraSubsystemCinfo);
#endif
        }

        class YVROpenXRProvider : Provider
        {
            /// <summary>
            /// Start the camera functionality.
            /// </summary>
            public override void Start()
            {
                YVRPlugin.Instance.SetPassthrough(true);
            }

            /// <summary>
            /// Stop the camera functionality.
            /// </summary>
            public override void Stop()
            {
                YVRPlugin.Instance.SetPassthrough(false);
            }
        }
    }
}
#endif