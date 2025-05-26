#if XR_ARFOUNDATION_5 || XR_ARFOUNDATION_6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace YVR.Core.ARFoundation.ImageTracking
{
    public class YVRImageTrackingSubsystem : XRImageTrackingSubsystem
    {
        internal const string k_SubsystemId = "YVRImageTracking";

        protected override void OnStart()
        {
            this.provider.Start();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
#if XR_ARFOUNDATION_5
            var info = new XRImageTrackingSubsystemDescriptor.Cinfo
            {
                id = k_SubsystemId,
                providerType = typeof(YVRImageTrackingProvider),
                subsystemTypeOverride = typeof(YVRImageTrackingSubsystem),
                supportsMovingImages = true,
                supportsMutableLibrary = false,
                supportsImageValidation = false
            };

            XRImageTrackingSubsystemDescriptor.Create(info);
#endif

#if XR_ARFOUNDATION_6
                var info = new XRImageTrackingSubsystemDescriptor.Cinfo
                {
                    id = k_SubsystemId,
                    providerType = typeof(YVRImageTrackingProvider),
                    subsystemTypeOverride = typeof(YVRImageTrackingSubsystem),
                    supportsMovingImages = true,
                    supportsMutableLibrary = false,
                    supportsImageValidation = false
                };

                XRImageTrackingSubsystemDescriptor.Register(info);
#endif
        }
    }
}
#endif