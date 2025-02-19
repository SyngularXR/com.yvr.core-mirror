# 平面检测

 负责处理平面检测的相关功能，以实现平面检测的创建、获取和结束。

## 公共字段

### `public static Action<List<YVRPlaneDetectorLocation>> getPlanesAction`
- **描述**: 用于在检测到平面时回调，传递检测到的平面位置列表。
- **类型**: `Action<List<YVRPlaneDetectorLocation>>`
- **用途**: 当平面检测完成并且有平面位置可用时，调用此回调以处理平面数据。

## 公共方法

### `public void CreatePlaneDetector()`
- **描述**: 创建平面检测的实例。调用此方法将启动平面检测过程。
- **参数**: 无
- **返回值**: 无

### `public List<YVRPlaneDetectorPolygonBuffer> GetPlanePolygonBuffer(YVRPlaneDetectorLocation plane)`
- **描述**: 获取指定平面的多边形缓冲区。
- **参数**: 
  - `YVRPlaneDetectorLocation plane`: 要获取多边形缓冲区的平面。
    - **类型**: `YVRPlaneDetectorLocation`
    - **描述**: 包含平面 ID 和其他相关信息的结构体。
- **返回值**: 
  - **类型**: `List<YVRPlaneDetectorPolygonBuffer>`
  - **描述**: 返回一个包含该平面的所有多边形缓冲区的列表。如果没有找到多边形缓冲区，则返回空列表。

### `public void EndPlaneDetector()`
- **描述**: 结束平面检测的实例。调用此方法将停止平面检测过程。
- **参数**: 无