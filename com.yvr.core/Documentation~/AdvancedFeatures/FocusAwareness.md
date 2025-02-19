# Focus Awareness

The focus awareness feature allows the system UI to overlay on XR applications, enabling users to interact with the system UI directly within the application without needing to exit it.

Focus awareness is a system capability that developers can use without writing any code. When the user presses the Home button on the controller, the system will automatically display the system UI using the focus awareness feature. When the system UI appears, the application will lose focus. Developers need to listen for focus awareness events to handle the focus state correctly, such as:

- Pausing the game when focus is lost
- Stopping the rendering of the controller model when focus is lost (since the system will render its own hand/controller model for UI interaction in this state)

The focus awareness-related events are as follows:

| **Event**                                       | **Description**                                                                                                                                                                                                                 |
| ----------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| YVRManager.instance.eventsManager.onFocusGained | The application loses input focus. For example, when the application is running and the user presses the Home button on the controller, the system UI appears, and the application loses input focus. Developers can pause the game, disable user input (e.g., controller), or notify other online users that the user is not currently focused on the application. |
| YVRManager.instance.eventsManager.onFocusLost   | The application gains input focus. This event is triggered when the system UI is closed. Developers can resume the game or enable user input at this time.                                                                                                                       |

> [!TIP]
> The focus state changes caused by focus awareness are not the same as the focus state changes provided by Unity by default. The former is specific to the focus awareness feature for XR applications, while the latter is based on the focus state of the application window. Therefore, developers should not rely directly on Unity's `OnApplicationFocus` method to handle focus awareness state changes.