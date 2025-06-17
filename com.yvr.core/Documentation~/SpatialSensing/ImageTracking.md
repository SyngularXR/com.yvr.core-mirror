# Image Tracking

## Overview

Image tracking enables devices to recognize specific images on surfaces (such as posters, playing cards, or digital displays). You can use image tracking to locate images in the user's environment and overlay them with virtual content. For example, applications can leverage image tracking to detect specific images and provide users with on-screen experiences like 3D product visualizations.

## Requirements
- Requires Play For Dream MR device
- OS version 3.1.0 or higher

## Configuring Reference Image Gallery

### Creating Image Tracking Library

Create a `ToTrackImagesCollectionSO` resource under `Assets\XR\Resources\`  
   <img src="./ImageTracking/ImageTracking.png" alt="ImageTracking" style="width: 70%;">  
   This creates an image tracking library where you can add images for recognition.

### Adding Images to Library
1. Import images into the project via `Assets > Import New Asset`
2. Add images to the reference library:
   - Open `ToTrackImagesCollectionSO.asset` in the Inspector window
   - Click **Add new image** to add tracking images
   - Configure image information

### Configuring Tracked Images
Configure settings in the Inspector window after adding images:

| Property          | Description                                                                 |
|-------------------|-----------------------------------------------------------------------------|
| Image Id          | Runtime identifier for detected reference images (string)                   |
| Image             | Texture2D resource created from reference image file                       |
| Size              | Physical display size of tracked image (in meters)                          |
| Image File Path   | Path to reference image                                                    |

## Image Tracking Management

### Enable/Disable Image Tracking
```csharp
// Toggle image tracking functionality
ImageTrackingMgr.instance.SwitchImageTracking(true);
```

**Parameters**:  

| Name   | Type | Description                         |
|--------|------|-------------------------------------|
| enable | bool | `true`: Enable tracking<br>`false`: Disable tracking |

### Register All Configured Image Templates
```csharp
ImageTrackingMgr.instance.RegisterTrackImageLibrary();
```

### Register Global Tracking Callback (All Images)
```csharp
ImageTrackingMgr.instance.RegisterImageTrackingUpdateCallback(OnImageTrackingUpdate);
private void OnImageTrackingUpdate(TrackedImageInfo info){}
```

**Parameters**:  

| Name      | Type                         | Description             |
|-----------|------------------------------|-------------------------|
| callback  | Action<TrackedImageInfo>     | Tracking update callback|

### Unregister Global Callback
```csharp
ImageTrackingMgr.instance.UnRegisterImageTrackingUpdateCallback(OnImageTrackingUpdate);
```

**Parameters**:  

| Name      | Type                         | Description             |
|-----------|------------------------------|-------------------------|
| callback  | Action<TrackedImageInfo>     | Callback to remove      |

### Register Image-Specific Callback
```csharp
ImageTrackingMgr.instance.RegisterImageTrackingUpdateCallback("targetImage", OnImageTrackingUpdate);
private void OnImageTrackingUpdate(TrackedImageInfo info){}
```

**Parameters**:  

| Name      | Type                         | Description                     |
|-----------|------------------------------|---------------------------------|
| imageId   | string                       | Target image ID                 |
| callback  | Action<TrackedImageInfo>     | Tracking callback for this image|

### Unregister Image-Specific Callback
```csharp
ImageTrackingMgr.instance.UnRegisterImageTrackingUpdateCallback("targetImage", OnImageTrackingUpdate);
```

**Parameters**:  

| Name      | Type                         | Description                |
|-----------|------------------------------|----------------------------|
| imageId   | string                       | Target image ID            |
| callback  | Action<TrackedImageInfo>     | Callback to remove         |

### Unregister Image Template
```csharp
// Uses Image Id from ToTrackImagesCollectionSO resource
ImageTrackingMgr.instance.UnRegisterImageTemplate("targetImage");
```

**Parameters**:  

| Name      | Type             | Description                 |
|-----------|------------------|-----------------------------|
| imageId   | string           | Image ID to unregister      |

## Usage Example
```csharp
// Enable VST
YVRManager.instance.hmdManager.SetPassthrough(true);

// Register All Configured Image Templates
ImageTrackingMgr.instance.RegisterTrackImageLibrary();

// Register global callback
ImageTrackingMgr.instance.RegisterImageTrackingUpdateCallback(OnImageTracked);

// Register image-specific callback
ImageTrackingMgr.instance.RegisterImageTrackingUpdateCallback("targetImage", OnTargetTracked);

// Enable tracking
ImageTrackingMgr.instance.SwitchImageTracking(true);

void OnImageTracked(TrackedImageInfo info)
{
    Debug.Log($"Tracked image: {info.imageId}");
}

void OnTargetTracked(TrackedImageInfo info)
{
    Debug.Log($"Specific image position: {info.pose.position}");
}
```