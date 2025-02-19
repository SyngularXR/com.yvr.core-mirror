# System keyboard

The system keyboard feature allows developers to use the system keyboard provided by Dream OS directly for text input within their applications, without needing to develop their own keyboard. The principle is that the system will listen for events where the application needs to invoke the keyboard and, in such cases, will wake up the keyboard through the [Focus Awareness](FocusAwareness.md) feature.

## Usage Example

> [!tip]
> The core of the following example is to create a Unity InputField and use the system keyboard for input within the scene.

1. In the **Hierarchy** panel, complete the following steps:

    - Select **+** > **UI** > **Event System** to add the event system to the scene.
    - Select **+** > **UI** > **Canvas** to add the canvas to the scene.

2. Select **Canvas** and in the **Inspector** panel, complete the following steps:

    - Set **Render Mode** to **World Space**.
    - Set **Event Camera** to **Main Camera**.
    - Add the **Tracked Device Graphics Raycast** script to the **Canvas**.

3. In the **Hierarchy** panel, right-click **Canvas** and select **UI** > **Input Field - TextMeshPro** from the context menu to add the input field to the scene.

4. Build the application to a real device, and click the Input Field on the device. At this point, you will see the system keyboard pop up.

![SystemKeyboard](../AdvancedFeatures/SystemKeyboard/SystemKeyboard.png)

> [!note]
> The system keyboard feature cannot be used in the Editor.