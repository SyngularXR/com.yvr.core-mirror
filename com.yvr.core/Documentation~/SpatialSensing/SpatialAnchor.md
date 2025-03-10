---
created: 2024-01-02
updated: 2024-01-03
---
# Spatial Anchors
## Introduction

Spatial Anchors are key points used for positioning and tracking objects or scenes in virtual or augmented reality environments. They can be used to achieve stable placement of virtual objects, environmental understanding, shared virtual scenes, and other functions. Spatial Anchors are a technology jointly implemented by software and hardware, capable of associating virtual content with specific locations or objects in the real world.

## Basic Concepts

| Name | Description |
| --- | --- |
| UUID | The unique identifier of the anchor, returned when the anchor is created |
| anchorHandle | The handle of the anchor, the identifier in the application's memory |

## Enabling Spatial Anchor Permissions for the Application

1. Open the project in Unity
2. Add XR Origin to the scene
3. Add the YVRManager script
4. Check the Enable SpatialAnchorSupport option in the YVRManager script panel
```ad-note
After checking the SpatialAnchorSupport checkbox, the corresponding permission will be added to the AndroidManifest.xml file 
**\<uses-permission android:name="com.yvr.permission.USE_ANCHOR_API"\\>**
```
## Spatial Anchor Interface
### Creating an Anchor

``` CSharp
/// <summary>  
/// Creates a spatial anchor using the given position and rotation.  
/// </summary>  
/// <param name="position">Anchor position</param>  
/// <param name="rotation">Anchor rotation</param>  
/// <param name="result">Callback for the anchor creation interface</param>
public void CreateSpatialAnchor(Vector3 position, Quaternion rotation, Action<YVRSpatialAnchorResult,bool> result) 
```
After creating the anchor, the **Action<YVRSpatialAnchorResult,bool>** callback will be triggered. YVRSpatialAnchorResult returns anchor information, and bool indicates whether the anchor creation was successful.
```CSharp
public struct YVRSpatialAnchorResult  
{  
    // Task Id
    public ulong requestId;  
    // Anchor handle
    public ulong anchorHandle;  
    // Anchor unique identifier
    public Char[] uuid;  
}
```
Code example
```CSharp
public void CreateSpatialAnchor(Transform transform)  
{  
    YVRSpatialAnchor.instance.CreateSpatialAnchor(transform.position, transform.rotation, OnCreateSpatialAnchor);  
}  
  
private void OnCreateSpatialAnchor(YVRSpatialAnchorResult result, bool success)  
{  
    if(!success)  
    {  
        Debug.LogError("Create spatial anchor failed!" );  
        return;    
    }  
    
    Debug.Log("Create spatial anchor success");
    //TODO Custom logic
}
```
### Saving an Anchor
Call the **YVRSpatialAnchor.instance.SaveSpatialAnchor** interface to save the anchor. The anchor can be saved on the local device or in the cloud. **Saving the anchor in the cloud requires the user to be logged into the device account and the device to be connected to the internet**

```CSharp
/// <summary>  
/// Saves the spatial anchor using the provided save information  
/// </summary>  
/// <param name="saveInfo">Save information</param>  
/// <param name="callback">Save result callback</param>  
public void SaveSpatialAnchor(YVRSpatialAnchorSaveInfo saveInfo, Action<YVRSpatialAnchorSaveCompleteInfo,bool> callback)
```
Save anchor parameter information **YVRSpatialAnchorSaveInfo**
```CSharp
public struct YVRSpatialAnchorSaveInfo  
{  
    // Handle of the anchor to be saved
    public ulong anchorHandle;  
    // Save location Local: Local memory, Cloud: Cloud
    public YVRSpatialAnchorStorageLocation storageLocation; 
}
```
Save result callback **Action<YVRSpatialAnchorSaveCompleteInfo,bool>**
YVRSpatialAnchorSaveCompleteInfo save result information, bool indicates whether the save was successful
```CSharp
public struct YVRSpatialAnchorSaveCompleteInfo  
{  
    // Task Id
    public ulong requestId;  
    // Result code
    public int resultCode;
    // Saved anchor handle
    public ulong anchorHandle;  
    // Saved anchor UUID
    public char[] uuid;  
    // Save location
    public YVRSpatialAnchorStorageLocation location;  
}
```
Code example:
```CSharp
private void SaveAnchor(ulong anchorHandle)
{
    YVRSpatialAnchorSaveInfo saveInfo = new YVRSpatialAnchorSaveInfo();  
    saveInfo.anchorHandle = anchorHandle;  
    // Save to local
    saveInfo.storageLocation = YVRSpatialAnchorStorageLocation.Local; 
    // Save to cloud
    //saveInfo.storageLocation = YVRSpatialAnchorStorageLocation.Cloud;   
    YVRSpatialAnchor.instance.SaveSpatialAnchor(saveInfo, OnSaveCompleteCallback);
}

private void OnSaveCompleteCallback(YVRSpatialAnchorSaveCompleteInfo saveResult,bool success)  
{  
    Debug.Log("Save anchor result:" + success); 
}
```
### Deleting an Anchor
Call the **YVRSpatialAnchor.instance.EraseSpatialAnchor()** interface to delete the specified anchor at the specified location
```CSharp
/// <summary>  
/// Deletes the corresponding spatial anchor based on the anchor handle and storage location  
/// </summary>  
/// <param name="anchorHandle">Handle of the anchor to be deleted</param>  
/// <param name="location">Storage location of the anchor</param>  
/// <param name="callback">Callback for the delete result</param>  
public void EraseSpatialAnchor(UInt64 anchorHandle, YVRSpatialAnchorStorageLocation location,Action<YVRSpatialAnchorResult,bool> callback)
```
Delete result callback **Action<YVRSpatialAnchorResult,bool>** YVRSpatialAnchorResult deleted anchor, bool indicates whether the deletion was successful

Code example:
```CSharp
private void EraseSpatialAnchor()
{
    YVRSpatialAnchor.instance.EraseSpatialAnchor(m_spatialAnchor.spaceHandle, YVRSpatialAnchorStorageLocation.Local,  
    OnEraseCompleteCallback);
}

private void OnEraseCompleteCallback(YVRSpatialAnchorResult result,bool success)
{
    Debug.Log($"Erase anchor:{result.anchorHandle}, uuid:{new string(result.uuid)} {success}");
}
```
### Querying an Anchor
Call the **YVRSpatialAnchor.instance.QuerySpatialAnchor** to query the anchor
```CSharp
/// <summary>  
/// Queries the spatial anchor based on the provided query information  
/// </summary>  
/// <param name="queryInfo">Query information</param>  
/// <param name="queryCallback">Query result</param>  
public void QuerySpatialAnchor(YVRSpatialAnchorQueryInfo queryInfo , Action<List<YVRSpatialAnchorResult>> queryCallback)
```
YVRSpatialAnchorQueryInfo query information, supports querying by uuid or component type
```CSharp
public struct YVRSpatialAnchorQueryInfo  
{  
    // Maximum number of anchors to return in the query (default is zero, meaning no limit)
    public uint MaxQuerySpaces;
    // Query timeout (default is zero, meaning no timeout)
    public double Timeout;
    // Query location
    public YVRSpatialAnchorStorageLocation storageLocation; 
    // Component type of the anchor to query
    public YVRSpatialAnchorComponentType component;
    // Number of uuids to query
    public int numIds;  
    // List of uuids to query
    public YVRSpatialAnchorUUID[] ids;  
}
```

Code example:
```CSharp
// Query all local anchors saved on this device
private void QueryAllLocalAnchor()
{
    YVRSpatialAnchorQueryInfo queryInfo = new YVRSpatialAnchorQueryInfo();  
    queryInfo.storageLocation = YVRSpatialAnchorStorageLocation.Local;
    YVRSpatialAnchor.instance.QuerySpatialAnchor(queryInfo, QuerySpatialAnchorComplete);
}

// Query anchors previously saved in the cloud using uuids
private void QuerryUUIDsAnchor(List<char[]> uuids)
{
    YVRSpatialAnchorQueryInfo queryInfo = new YVRSpatialAnchorQueryInfo();  
    queryInfo.storageLocation = YVRSpatialAnchorStorageLocation.Cloud;  
    queryInfo.ids = new YVRSpatialAnchorUUID[uuids.Count];
    for(int i = 0; i < uuids.Count; i++)
    {
        queryInfo.ids[i] = new YVRSpatialAnchorUUID();  
        queryInfo.ids[i].Id = uuids[i];
    }
    
    YVRSpatialAnchor.instance.QuerySpatialAnchor(queryInfo, QuerySpatialAnchorComplete);
}

// Query result
private void QuerySpatialAnchorComplete(List<YVRSpatialAnchorResult> results)
{
    Debug.Log("QuerySpacesComplete count:" + results.Count);
}
```

```ad-note
When querying saved anchors in the same area, you may not find the anchors. Try walking around to collect more point cloud data and then call the query again. The frequency of interface calls can be decided by yourself, **it is recommended to call once every second**
```
### Getting the Real-time Pose of an Anchor

Call the **YVRSpatialAnchor.instance.GetSpatialAnchorPose** interface to get the real-time position of the anchor, keeping the anchor's position fixed. If not obtained, the anchor's position may shift when the user moves in the scene or performs recentering. It supports calling every frame.
```CSharp
/// <summary>  
/// Gets the pose of the anchor  
/// </summary>  
/// <param name="anchorHandle">Anchor handle</param>  
/// <param name="position">Returns the position of the anchor</param>  
/// <param name="rotation">Returns the rotation of the anchor</param>  
/// <param name="locationFlags">Anchor location status</param>  
/// <returns></returns>  
public bool GetSpatialAnchorPose(ulong anchorHandle, out Vector3 position, out Quaternion rotation,out YVRAnchorLocationFlags locationFlags)
```
```ad-note
When the method to get the anchor pose returns false, or the location status is not tracked, it means the current map has switched. At this time, the anchor becomes invalid, and the returned pose may be incorrect. You need to wait for the user to return to the map where the anchor was created, or when the map where the anchor was created merges with other maps, the anchor will become valid again.
```
### Getting Supported Component Types of an Anchor
Call **YVRSpatialAnchor.instance.GetSpatialAnchorEnumerateSupported** to get the supported component types of the specified anchor. Currently, anchors created by third-party references only support pose (Locatable), storage (Storable), and sharing (Sharable).
```CSharp
/// <summary>  
/// Gets the supported component types of the anchor  
/// </summary>  
/// <param name="anchorHandle">Anchor handle</param>  
/// <param name="components">Supported component types</param>
public void GetSpatialAnchorEnumerateSupported(ulong anchorHandle, out YVRSpatialAnchorSupportedComponent components)
```

### Setting the Component Status of an Anchor
Call **YVRSpatialAnchor.instance.SetSpatialAnchorComponentStatus()** to set the component status of the anchor. The created anchor by default includes pose (Locatable), storage (Storable), and sharing (Sharable).
```CSharp
/// <summary>  
/// Sets the component status of the anchor  
/// </summary>  
/// <param name="anchorHandle">Anchor handle</param>  
/// <param name="setInfo">Status information</param>  
/// <param name="callback">Callback for setting the anchor status</param>  
/// <returns></returns>  
public bool SetSpatialAnchorComponentStatus(ulong anchorHandle, YVRSpatialAnchorComponentStatusSetInfo setInfo,  
    Action<YVRSpatialAnchorSetStatusCompleteInfo,bool> callback)
```

Code example:

```CSharp
private void DisableAnchorStorableState(ulong anchorHandle)
{
    YVRSpatialAnchorComponentStatusSetInfo componentStatusSetInfo = new YVRSpatialAnchorComponentStatusSetInfo();  
    componentStatusSetInfo.component = YVRSpatialAnchorComponentType.Storable;
    // When setting the Storable of the created anchor to false, the anchor cannot be saved.
    componentStatusSetInfo.enable = false;    
    YVRSpatialAnchor.instance.SetSpatialAnchorComponentStatus(result.anchorHandle, componentStatusSetInfo,null);
}
```
```ad-note
The code example above disables the storage permission of the anchor
```
### Getting the Component Status of an Anchor
Call **YVRSpatialAnchor.instance.GetSpatialAnchorComponentStatus** to get the status of the specified component of the anchor
```CSharp
/// <summary>  
/// Gets the status of the specified component of the anchor  
/// </summary>  
/// <param name="anchorHandle">Anchor handle</param>  
/// <param name="componentType">Component type</param>  
/// <param name="status">Returned status information</param>  
public void GetSpatialAnchorComponentStatus(ulong anchorHandle, YVRSpatialAnchorComponentType componentType, out YVRSpatialAnchorComponentStatus status)
```

### Batch Saving Anchors
**YVRSpatialAnchor.instance.SaveSpatialAnchorList** saves multiple anchors at once
```CSharp
/// <summary>  
/// Batch saves anchors  
/// </summary>  
/// <param name="spatialAnchorHandleList">List of anchor handles</param>  
/// <param name="location">Save location</param>  
/// <param name="callback">Save result callback</param>  
public void SaveSpatialAnchorList(List<ulong> spatialAnchorHandleList, YVRSpatialAnchorStorageLocation location,  
    Action<bool> callback)
```
### Getting Anchor UUID by anchorHandle
Call **YVRSpatialAnchor.instance.GetSpatialAnchorUUIDForHandle** to get the unique identifier of the anchor by the anchor handle
```CSharp
/// <summary>  
/// Gets the unique identifier of the anchor by the anchor handle  
/// </summary>  
/// <param name="anchorHandle">Anchor handle</param>  
/// <param name="uuid">Anchor unique identifier</param>  
public void GetSpatialAnchorUUIDForHandle(ulong anchorHandle, out YVRSpatialAnchorUUID uuid)
```
## Getting Spatial Calibration Anchor Information
Only anchors created by the **Spatial Calibration** application in the system support setting calibration information, including anchor components, semantic tags, plane information, and cube information. You can use the **Spatial Calibration** interface to get the calibration information of the anchor and then use it in your own reference. For details, refer to the **Spatial Calibration** documentation.

## Demo
[SpatialAnchorSample](https://github.com/YVRDeveloper/SpatialAnchorSample-Unity) demonstrates the related functions of spatial anchors, including creating anchors, saving anchors, deleting anchors, querying anchors, sharing anchors, etc. When demonstrating the sharing function, you need to manually configure your own photon id and service.