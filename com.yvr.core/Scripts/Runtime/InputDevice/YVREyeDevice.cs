#if UNITY_INPUT_SYSTEM
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using UnityEngine.Scripting;

namespace YVR.Core.XR.InputDevices
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    [Preserve]
    [InputControlLayout(displayName = "YVR Eye Device", canRunInBackground = true)]
    public class YVREyeDevice : TrackedDevice
    {
        private const string k_YVREyeDeviceProductName = "EyesTracking";
        private const string k_YVREyeDeviceManufacturerName = "YVR";

        public EyesControl eyesData { get; protected set; }

        protected override void FinishSetup()
        {
            base.FinishSetup();
            eyesData = GetChildControl<EyesControl>("eyesData");
        }

        static YVREyeDevice() { RegisterLayout(); }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void RegisterLayout()
        {
            InputSystem.RegisterLayout<YVREyeDevice>(matches: new InputDeviceMatcher()
                                                             .WithProduct(k_YVREyeDeviceProductName)
                                                             .WithManufacturer(k_YVREyeDeviceManufacturerName));
        }
    }
}
#endif
