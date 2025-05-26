# Plane detection

平面检测是指检测和跟踪物理环境中的平面。通过 ARFoundation 中组件可以控制您应用中的平面检测功能，并为每个检测到的平面创建 ARPlane 追踪。

## 要求

- 需要 Play For Dream MR 设备， OS 3.1.0 以上版本
- 平面检测依赖 Scene 权限，需要前往 `Edit > Project Settings` > `XR Plug-in Management` > `YVR` > `Feature Request` ,然后勾选 `Require Scene Anchor` 来开启权限

    <img src="./Image/Scene.png" alt="SpatialAnchor" style="width: 70%;">

## 使用说明

1. 将 `AR Plane Manager` 组件添加到场景内 XROrigin 对象中。`ARPlaneManager` 组件是平面追踪管理器，用于检测和追踪物理环境中的平面。为每个检测到的平面在您的场景中创建 GameObject

    <img src="./Image/PlaneManager.png" alt="PlaneManager" style="width: 70%;">
2. 为 `AR Plane Manager` 添加 `Plane Prefab` 预制体，当检测到追踪平面时，管理器会创建 `Plane Prefab` GameObject, `Plane Prefab` 中会包含平面相关数据，并持续更新平面
3. `Plane Prefab` 预制体上需添加 `AR Plane` 与 `AR Plane Mesh Visualizer` 组件来追踪与更新平面，根据 `AR Plane Mesh Visualizer` 脚本功能为对象添加 `Mesh Filter`/`Mesh Render`/`Line Render` 可以展示平面显示效果

    <img src="./Image/ARPlane.png" alt="ARPlane" style="width: 50%;">

平面检测组件详细文档可通过 [AR Foundation Plane detection](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.2/manual/features/plane-detection.html) 查看