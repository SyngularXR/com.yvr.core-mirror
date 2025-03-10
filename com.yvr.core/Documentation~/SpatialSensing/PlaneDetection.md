# Plane Detection

Responsible for handling plane detection functionalities, including creating, retrieving, and ending plane detection.

## Public Fields

### `public static Action<List<YVRPlaneDetectorLocation>> getPlanesAction`
- **Description**: Callback used when planes are detected, passing the list of detected plane locations.
- **Type**: `Action<List<YVRPlaneDetectorLocation>>`
- **Usage**: This callback is invoked when plane detection is complete and plane locations are available to process the plane data.

## Public Methods

### `public void CreatePlaneDetector()`
- **Description**: Creates an instance of plane detection. Calling this method will start the plane detection process.
- **Parameters**: None
- **Return Value**: None

### `public List<YVRPlaneDetectorPolygonBuffer> GetPlanePolygonBuffer(YVRPlaneDetectorLocation plane)`
- **Description**: Retrieves the polygon buffer for the specified plane.
- **Parameters**: 
    - `YVRPlaneDetectorLocation plane`: The plane for which to retrieve the polygon buffer.
        - **Type**: `YVRPlaneDetectorLocation`
        - **Description**: A struct containing the plane ID and other related information.
- **Return Value**: 
    - **Type**: `List<YVRPlaneDetectorPolygonBuffer>`
    - **Description**: Returns a list of all polygon buffers for the plane. If no polygon buffers are found, returns an empty list.

### `public void EndPlaneDetector()`
- **Description**: Ends the instance of plane detection. Calling this method will stop the plane detection process.
- **Parameters**: None