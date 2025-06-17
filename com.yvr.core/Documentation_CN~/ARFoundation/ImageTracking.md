## Image Tracking

通过 AR Foundation 在项目中使用图像跟踪功能。

## 要求

  - 需要 Play For Dream MR 设备
  - OS 3.1.0 以上版本

## 使用说明

以下为图像跟踪的简单使用说明，详细使用说明参考 Unity 的  [AR Foundation Image Tracking](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.2/manual/features/image-tracking.html) 文档

### 配置图片库

#### 创建参考图片库

<img src="./Image/ImageTracking.png" alt="ImageTracking" style="width: 70%;">

#### 将图像添加到参考图像库

1. 在 Inspector 窗口中打开 Reference Image Library 资产。
2. 选择 Add Image 按钮将图像添加到库中。
3. 在图像预览框中，按 “选择” 以打开图像资源管理器。
4. 从下拉列表中选择相关图像。（对要添加的每张图像重复此作。）

<img src="./Image/AddImage.png" alt="AddImage" style="width: 70%;">

### 图像追踪管理组件

#### 启用图像追踪

要在应用程序中启用图像跟踪，请将 `AR Tracked Image Manager` 组件添加到 `XR Origin` 游戏对象中。如果场景不包含 `XR Origin` 游戏对象，请首先按照场景设置说明进行作。

每当您的应用不需要图像跟踪功能时，请禁用 `AR Tracked Image Manager` 组件以禁用图像跟踪，这可以提高应用程序性能。如果用户的设备不支持图像跟踪，则 `AR Tracked Image Manager` 组件将在 **OnEnable** 期间禁用自身。

#### 设置参考图片库

要检测环境中的图像，必须指示管理器查找编译到参考图像库中的一组参考图像。AR Foundation 仅检测此库中的图像

要使用 `AR Tracked Image Manager` 组件设置参考图像库，请执行以下作：

1. 在 `Inspector` 窗口中查看 `AR Tracked Image Manager` 组件。
2. 单击 Serialized Library 选择器 （⊙）。
3. 从 `Assets` 文件夹中选择您的参考图像库。

#### 图像追踪预制体

当检测到引用图像库中的图像时，都会实例化此预制件。管理器确保实例化的 `GameObject` 包含 `ARTrackedImage` 组件。您可以使用 `ARTrackedImage.referenceImage` 属性获取用于检测 `ARTrackedImage` 的参考图像。

#### 响应检测到的图像

订阅 `AR Tracked Image Manager` 的 `trackablesChanged` 事件，以便在添加、更新或删除图像时收到通知，如以下代码示例所示：
```
[SerializeField]
ARTrackedImageManager m_ImageManager;

void OnEnable() => m_ImageManager.trackablesChanged.AddListener(OnChanged);

void OnDisable() => m_ImageManager.trackablesChanged.RemoveListener(OnChanged);

void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
{
    foreach (var newImage in eventArgs.added)
    {
        // Handle added event
    }

    foreach (var updatedImage in eventArgs.updated)
    {
        // Handle updated event
    }

    foreach (var removed in eventArgs.removed)
    {
        // Handle removed event
        TrackableId removedImageTrackableId = removed.Key;
        ARTrackedImage removedImage = removed.Value;
    }
}
```

### 图像追踪组件

`ARTrackedImage` 组件是一种可跟踪对象，其中包含与检测到的 2D 图像关联的数据。当设备从环境中的参考图像库中检测到 2D 图像时，`AR Tracked Image Manager` 将创建一个 `ARTrackedImage`。

`ARTrackedImage` 中包含识别图片的 name/trackingState/size/pose 等相关参数。