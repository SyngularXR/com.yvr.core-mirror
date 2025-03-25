#if XR_ARFOUNDATION_5 || XR_ARFOUNDATION_6
using System;
using AOT;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;


namespace YVR.Core.ARFoundation.Session
{
    public class YVRSessionSubsystem : XRSessionSubsystem
    {
        internal const string k_SubsystemId = "YVRSession";

        internal static Action<int> onSessionStateChangeAction;

        [MonoPInvokeCallback(typeof(Action<int>))]
        private static void OnSessionStateChangeCallback(int state)
        {
            onSessionStateChangeAction?.Invoke(state);
        }

        internal static YVRSessionSubsystem instance { get; private set; }

        public YVRSessionSubsystem()
        {
            instance = this;
            YVRPlugin.Instance.SetSessionStateChangeCallback(OnSessionStateChangeCallback);
            onSessionStateChangeAction = (newState) =>
            {
                ((SessionProvider)provider).OnSessionStateChange(newState);
            };
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
#if XR_ARFOUNDATION_5
        XRSessionSubsystemDescriptor.RegisterDescriptor(new XRSessionSubsystemDescriptor.Cinfo
#endif

#if XR_ARFOUNDATION_6
        XRSessionSubsystemDescriptor.Register(new XRSessionSubsystemDescriptor.Cinfo
#endif
            {
                id = k_SubsystemId,
                providerType = typeof(SessionProvider),
                subsystemTypeOverride = typeof(YVRSessionSubsystem),
                supportsInstall = false,
                supportsMatchFrameRate = false
            });
        }

        class SessionProvider : Provider
        {
            XrSessionState m_SessionState;
            Guid m_SessionId;

            public override Guid sessionId => m_SessionId;

            public override void Start()
            {
                m_SessionId = Guid.NewGuid();
            }

            public override Feature requestedTrackingMode
            {
                get => Feature.PlaneTracking | Feature.Meshing | Feature.AnyCamera | Feature.AnyTrackingMode;
                set { }
            }

            public override Feature currentTrackingMode => Feature.PlaneTracking | Feature.Meshing | Feature.AnyCamera | Feature.AnyTrackingMode;

            public override TrackingState trackingState
            {
                get
                {
                    switch (m_SessionState)
                    {
                        case XrSessionState.Idle:
                        case XrSessionState.Ready:
                        case XrSessionState.Synchronized:
                            return TrackingState.Limited;

                        case XrSessionState.Visible:
                        case XrSessionState.Focused:
                            return TrackingState.Tracking;

                        case XrSessionState.Unknown:
                        case XrSessionState.Stopping:
                        case XrSessionState.LossPending:
                        case XrSessionState.Exiting:
                        default:
                            return TrackingState.None;
                    }
                }
            }

            public override NotTrackingReason notTrackingReason
            {
                get
                {
                    switch (m_SessionState)
                    {
                        case XrSessionState.Idle:
                        case XrSessionState.Ready:
                        case XrSessionState.Synchronized:
                            return NotTrackingReason.Initializing;

                        case XrSessionState.Visible:
                        case XrSessionState.Focused:
                            return NotTrackingReason.None;

                        case XrSessionState.Unknown:
                        case XrSessionState.Stopping:
                        case XrSessionState.LossPending:
                        case XrSessionState.Exiting:
                        default:
                            return NotTrackingReason.Unsupported;
                    }
                }
            }
            public override Promise<SessionAvailability> GetAvailabilityAsync
                ()
                => Promise<SessionAvailability>.CreateResolvedPromise(SessionAvailability.Supported | SessionAvailability.Installed);
            public void OnSessionStateChange(int newState)
            {
                m_SessionState = (XrSessionState)newState;
            }
        }

        enum XrSessionState
        {
            Unknown = 0,
            Idle = 1,
            Ready = 2,
            Synchronized = 3,
            Visible = 4,
            Focused = 5,
            Stopping = 6,
            LossPending = 7,
            Exiting = 8,
        }

    }
}

#endif