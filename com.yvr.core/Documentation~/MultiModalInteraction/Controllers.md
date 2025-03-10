# Controllers

`YVRInput` and `YVRControllerRig` are the two entry points for obtaining controller data. `YVRInput` implements all functions related to controller input states, while `YVRControllerRig` encapsulates all operations and information related to controller rigidity.

For more information, refer to [YVRInput](xref:YVR.Core.YVRInput) and [YVRControllerRig](xref:YVR.Core.YVRControllerRig).

## YVR Touch Tracking

[YVRControllerRig](xref:YVR.Core.YVRControllerRig) provides touch position and orientation data through [GetPosition](xref:YVR.Core.YVRControllerRig.GetPosition(YVR.Core.ControllerType)) and [GetRotation](xref:YVR.Core.YVRControllerRig.GetRotation(YVR.Core.ControllerType)). Other data, such as velocity, angular velocity, acceleration, and angular acceleration, can also be obtained from [YVRControllerRig](xref:YVR.Core.YVRControllerRig).

## YVRInput Usage

The main purpose of [YVRInput](xref:YVR.Core.YVRInput) is to access the controller input states through `Get()`, `GetDown()`, and `GetUp()`. It also sets the amplitude and duration of the controller's vibration.

* `Get()`: Queries the current state of a controller.
* `GetDown()`: Queries if a button (touch) was pressed in this frame.
* `GetUp()`: Queries if a button (touch) was released in this frame.
* `SetControllerVibration()`: Sets the amplitude and duration of the controller's vibration.

### Control Input Enums

For the `Get()`, `GetDown()`, and `GetUp()` functions, there are various variations to provide different access to different sets of controls. These control sets are divided into two categories: `Virtual Mapping` and `Raw Mapping`, both exposed through enums. The enum categories defined in `Virtual Mapping` are as follows:

* `VirtualButton`: Traditional buttons on YVR Touches.
* `VirtualTouch`: Capacitive sensing control surfaces on YVR Touches.
* `VirtualAxis1D`: One-dimensional controls reporting `float` states.
* `VirtualAxis2D`: Two-dimensional controls reporting `Vector2` states.

The enums defined in the `Raw Mapping` category are highly related to those in `Virtual Mapping`, as follows:

* `RawButton`
* `RawTouch`
* `VirtualAxis1D`
* `VirtualAxis2D`

For the conversion between `Raw Mapping` and `Virtual Mapping`, refer to the following section.

### Touch Input Mapping

![Touch Input](Controllers/2021-12-14-15-41-15.png)