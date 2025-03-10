# Eye Tracking

> [!note]
>
> Requires Play For Dream MR device, OS version 3.1.0 or above

We provide eye tracking data based on `XR Devices`. You can find eye tracking devices using [GetDevicesWithCharacteristics](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/XR.InputDevices.GetDevicesWithCharacteristics.html) and [InputDeviceCharacteristics.EyeTracking](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/XR.InputDeviceCharacteristics.EyeTracking.html), and obtain eye tracking data from them:

```csharp
InputDevice eyeDevice = default;
var devices = new List<InputDevice>();
InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.EyeTracking, devices);
if (devices.Count > 0) eyeDevice = devices[0];

eyeDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
eyeDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
```

> [!tip]
>
> For more information on eye tracking, refer to [Eye Tracking Sample](https://github.com/PlayForDreamDevelopers/EyeTrackingSample-Unity)
