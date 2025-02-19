# Plane Detection

Responsible for handling plane detection related functions to enable the creation, retrieval, and termination of plane detection.

## Public Fields

### `public static Action<List<YVRPlaneDetectorLocation>> getPlanesAction`
- **Description**: Callback used when planes are detected, passing the list of detected plane locations.
- **Type**: `Action<List<YVRPlaneDetectorLocation>>`
- **Usage**: This callback is invoked when plane detection is complete and plane locations are available to process the plane data.

## Public Methods

### `public void CreatePlaneDetector()`
- **Description**: Creates an instance of plane detection. Calling this method will start the plane detection process.
- **Parameters**: None
- **Returns**: None

### `public List<YVRPlaneDetectorPolygonBuffer> GetPlanePolygonBuffer(YVRPlaneDetectorLocation plane)`
- **Description**: Retrieves the polygon buffer for the specified plane.
- **Parameters**: 
    - `YVRPlaneDetectorLocation plane`: The plane for which to retrieve the polygon buffer.
        - **Type**: `YVRPlaneDetectorLocation`
        - **Description**: A structure containing the plane ID and other related information.
- **Returns**: 
    - **Type**: `List<YVRPlaneDetectorPolygonBuffer>`
    - **Description**: Returns a list containing all polygon buffers for the plane. If no polygon buffers are found, an empty list is returned.

### `public void EndPlaneDetector()`
- **Description**: Terminates the instance of plane detection. Calling this method will stop the plane detection process.
- **Parameters**: None
- **Returns**: None