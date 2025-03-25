#if XR_ARFOUNDATION_5 || XR_ARFOUNDATION_6
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using YVR.Utilities;


namespace YVR.Core.ARFoundation.Anchor
{
    public class YVRAnchorSubsystem : XRAnchorSubsystem
    {
        internal const string k_SubsystemId = "YVRAnchor";
        private static Dictionary<TrackableId, ulong> m_TrackableIdToHandleMap;
        private static Dictionary<ulong, XRAnchor> m_HandleToXRAnchorMap;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
#if XR_ARFOUNDATION_5
            var cInfo = new XRAnchorSubsystemDescriptor.Cinfo()
            {
                id = k_SubsystemId,
                providerType = typeof(YVRAnchorProvider),
                subsystemTypeOverride = typeof(YVRAnchorSubsystem),
                supportsTrackableAttachments = false
            };

            XRAnchorSubsystemDescriptor.Create(cInfo);
#endif

#if XR_ARFOUNDATION_6
                var cInfo = new XRAnchorSubsystemDescriptor.Cinfo()
                {
                    id = k_SubsystemId,
                    providerType = typeof(YVRAnchorProvider),
                    subsystemTypeOverride = typeof(YVRAnchorSubsystem),
                    supportsTrackableAttachments = false,
                    supportsSynchronousAdd = false,
                    supportsSaveAnchor = true,
                    supportsLoadAnchor = true,
                    supportsEraseAnchor = true,
                    supportsGetSavedAnchorIds = false,
                    supportsAsyncCancellation = false
                };
                XRAnchorSubsystemDescriptor.Register(cInfo);
#endif
        }
    }
}

#endif