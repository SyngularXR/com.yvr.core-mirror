# Anchor
AR Foundation 中提供了 ARAnchorManager 锚点管理器组件，可以为每个锚点创建 GameObject

## 要求

- 使用锚点功能前，需前往 Edit > Project Settings > XR Plug-in Management > YVR > Feature Request ,然后勾选 Require Spatial Anchor 来开启权限

    <img src="./Image/SpatialAnchor.png" alt="SpatialAnchor" style="width: 70%;">

## 功能支持

| 功能 | 描述 |
| - | - |
| Save Anchor | 持久化锚点 |
| LoadAnchor | 加载锚点 |
| Erase Anchor | 删除锚点 |
| GetSavedAnchor | 获取已持久化锚点 |

功能的详细使用说明见 Unity 的 [ARFoundation 锚点接口文档](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.2/manual/features/anchors/aranchormanager.html)
