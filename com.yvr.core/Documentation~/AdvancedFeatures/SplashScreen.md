# Splash Screen

When users open the application, the system needs some time to load it. The YVR SDK allows developers to use a custom splash screen to control the user experience during this loading period.
- **Reduce perceived loading time**: By using a custom splash screen, users may feel that they have already entered the game, thus reducing the perceived loading time.
- **Enhance brand awareness and image**: The splash screen is the first impression of the application. By customizing the splash screen, developers can showcase the application's theme, style, and brand information during the loading period.

> [!tip]
>
> This feature does not reduce the application's initialization time, nor can it replace Unity's Splash, i.e., the Unity Logo and the "MADE WITH Unity" text.
>
> This feature is used to modify the system's behavior during the application's loading period.

Developers can set the splash screen through the `Project Settings -> XR Plug-in Management - YVR` by using the `OS Splash Screen` option.