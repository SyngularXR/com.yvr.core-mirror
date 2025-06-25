# Changelog

## [1.28.11] - 2025-06-20

### Added

- 添加获取设备 IPD 数据的接口

## [1.28.10] - 2025-06-20

### Added

- 添加旅行模式切换接口

## [1.28.9] - 2025-06-19

### Fixed

- 修复 Render Scale 调整不生效问题
- 修复无 Splash 的 Crash 问题
- 修复 Package 导入时可能的报错

## [1.28.8] - 2025-06-08

### Fixed

- 修复了无法触发左手震动的问题

## [1.28.7] - 2025-06-09

### Fixed

- 修复 Image Tracking 纹理无法正确打包的问题

## [1.28.6] - 2025-06-06

### Added

- 调整 ImagePacking 的路径

## [1.28.5] - 2025-06-06

### Added

- ImagePacking 不再依赖 Apk Asset Path

## [1.28.4] - 2025-06-06

### Fixed

- 修复 Splash Asset Path 强依赖 APkPath 路径的问题

## [1.28.3] - 2025-05-30

### Added

- 增加 LUT 相关接口

## [1.28.2] - 2025-05-27

### Changed

- mesh tracking 添加坐标系转换

## [1.28.1] - 2025-05-23

### Added

- Image Tracking 适配 ARFoundation

## [1.28.0] - 2025-05-19

### Added

- 增加 Image Tracking 相关接口

## [1.27.1] - 2025-05-15

### Changed

- 将手势追踪中 C# 层的坐标转换修改到 native 中

## [1.27.0-preview.0] - 2025-05-14

### Changed

- Core Native 交互部分重构
    - 删除 YVRWidget 部分
    - 删除 YVRDeveloperMode 相关的设置
    - 增加 Profiler 支持
    - 删除 EyeBias 数组获取，改由 xrLocateView 获取
    - 不再对 Input 数据进行 Queue 缓存
    - 将 HMD，Controller 拆分为独立的 InputMgr 管理
    - 使用 独立InputDevices 管理 UnityInputProvider 中的数据
    - 删除手势相机获取数据获取相关的 api

## [1.26.7] - 2025-04-29

### Fixed

- 修复 xrLocateViews 接口中 displayTime 参数为 0

## [1.26.6] - 2025-04-24

### Fixed

- 修复更新 Pose 时偶现右手系位姿

## [1.26.5] - 2025-04-21

### Fixed

- 修复 Controller 和 Hand Tracking Mode 错误标识的问题

## [1.26.4] - 2025-04-21

### Added

- 减少无效 Physical RenderPose 刷新

## [1.26.3] - 2025-04-18

### Added

- 增加针对 ManifestFest 的 Gradle Project 生成后的处理

## [1.26.2] - 2025-04-08

### Added

- 简化 RenderingModeManifestElementInfoProvider

## [1.26.1] - 2025-04-08

### Changed

- 让 YVRXRSettings 数据可从原工程中恢复

## [1.26.0] - 2025-04-08

### Changed

- 重构 Manifest 相关逻辑, 将原 YVRManager 的操作挪至 YVRXRSettings 中

## [1.25.3] - 2025-04-08

### Added

- 添加获取/设置边界效果类型接口

## [1.25.2] - 2025-04-03

### Fixed

- 修复 previewtool 偶现崩溃

## [1.25.1] - 2025-04-01

### Added

- 增加 EngineVersion

## [1.25.0] - 2025-03-31

### Changed

- Dynamic Tick 中同样使用预测时间获取位姿
- 使用 CLOCK_MONOTONIC 作为获取 Pose 的时间戳

## [1.24.2] - 2025-03-26

### Fixed

- 修复导入 arfoundation 包后默认开启了平面检测

## [1.24.1] - 2025-03-25

### Added

- 使用系统推荐的 Inner/Outer 渲染分辨率


## [1.24.0] - 2025-03-24

### Added

- 支持 ARFoundation 接口

## [1.23.11] - 2025-03-24

### Added

- 支持在运行时设置渲染分辨率

## [1.23.10] - 2025-03-17

### Added

- 更新 openxr loader
- 添加渲染倍率接口

## [1.23.9] - 2025-02-27

### Changed

- 移除 YVREyeDevice 中的 Usage 描述

## [1.23.8] - 2025-02-26

### Changed

- 直接使用 Device Position/Rotation 作为手柄的位置/旋转

## [1.23.7] - 2025-02-26

### Changed

- 移除 YVRHandDevice，将 InteractionEyeDevice 合并至 EyeDevice

## [1.23.6] - 2025-02-26

### Added

- 增加 Hand/Aim Hand/Eye/Interaction Device

## [1.23.5] - 2025-02-26

### Changed

- 更新 OpenXR Loader
- 添加设置/获取边界触发范围接口

## [1.23.4] - 2025-02-25

### Changed

- 更新 OpenXR Loader

## [1.23.3] - 2025-02-25

### Fixed

- 修复 OpenXR 相关的 Action 共用 Intent 导致无法安装的问题

## [1.23.2] - 2025-02-24

### Added

- 在打包时自动添加 OpenXR 相关 Manifest 权限

### Changed

- 将 OpenXRLoader 替换为 KHR 通用版本

## [1.23.1] - 2025-01-22

### Fixed

- 修复 GraphicAPI 设置为 Vulkan 闪退的 bug

## [1.23.0] - 2025-01-21

### Added

- 把两个 ProjectionLayer 的 RenderScale 区分开

## [1.22.2] - 2025-01-09

### Added

- 添加设置/获取眼动输入模式接口

## [1.22.1] - 2025-01-08

### Changed

- 在 C++ 中转换平面检测坐标系

## [1.22.0] - 2025-01-08

### Added

- 增加获取矩形平面及多边形功能

## [1.21.32] - 2024-12-31

### Added

- 增加 API 通知系统虚拟环境状态

## [1.21.31] - 2024-12-31

### Added

- 增加 YVRProjectSettingSO 基类，供对于配置的整体管理使用

## [1.21.30] - 2024-12-23

- 支持在运行时更改 inner, outer 渲染比例

## [1.21.29] - 2024-12-12

### Changed

- 重新编译 libyvrunity.aar

## [1.21.28] - 2024-12-11

### Changed

- 优化 updateRenderPasses 性能开销

## [1.21.27] - 2024-12-07

### Added

- 增加 slam 标定相关的 API

## [1.21.26] - 2024-11-29

### Added

- 增加手势标定相关的 API

## [1.21.25] - 2024-11-28

### Fixed

- 修复调用 xrAcquirePassthroughImageYVR 时可能的报错

## [1.21.24] - 2024-11-28

### Added

- 更新 OpenXRLoader 版本
- 增加获取/设置色散模式的 API

## [1.21.23] - 2024-11-20

### Changed

- 手柄连接时始终更新电量信息

## [1.21.22] - 2024-11-15

### Changed

- 手柄连接时始终更新电量信息

## [1.21.21] - 2024-11-06

### Changed

- 更新获取当前连接手柄类型接口

## [1.21.20] - 2024-11-06

### Added

- 支持大空间的应用 AndroidManifest 中添加对应 feature

## [1.21.19] - 2024-10-31

### Changed

- 更新获取/设置眼动追踪接口参数

## [1.21.18] - 2024-10-30

### Added

- 添加对 VST Provider 提供的 Image 合法判断

## [1.21.17] - 2024-10-29

### Fixed

- previewTool 在设备未连接时渲染错误

## [1.21.16] - 2024-10-28

### Added

- 添加 IPD 接口

## [1.21.15] - 2024-10-23

### Added

- 添加系统设置相关接口

## [1.21.14] - 2024-10-22

### Changed

- stop 时不进行 HMD 设备的断开

## [1.21.13] - 2024-10-15

### Added

- 增加关闭 VST Provider 接口

## [1.21.12] - 2024-10-14

### Added

- 添加拦截输入接口

## [1.21.11] - 2024-10-10

### Added

- 仅在 VR 模式下，刷新 System Property

## [1.21.10] - 2024-10-10

### Added

- 更新设置地面高度接口参数
- 获取当前左右手柄类型
- 修复修改渲染分辨率时报错
- 控制是否更新手柄数据

### Fixed

- 修复 Resume 后使用了错误预测时间获取 Locate View 的问题

## [1.21.9] - 2024-09-14

### Added

-  添加获取大空间重定位坐标数据接口

## [1.21.8] - 2024-09-11

### Changed

- 获取眼动开关前判断设备是否支持眼动

## [1.21.7] - 2024-09-11

### Added

- 增加 stereoRenderingMode 接口获取当前的渲染模式

## [1.21.6] - 2024-09-10

### Added

- 添加地图优化接口

## [1.21.5] - 2024-08-30

### Added

- 添加大空间相关接口

## [1.21.4] - 2024-08-22

### Added

- 可直接获取 VST 图像与渲染画面的偏移量
- 为 YVRCameraRig.CenterCamera 增加缓存

## [1.21.3] - 2024-08-21

### Changed

- 修改 Eye Tracking 设备的名称

## [1.21.2] - 2024-08-19

### Added

- 增加 P3 色域的设置

## [1.21.1] - 2024-08-13

### Fixed

- 修复获取 Fov 时传入的 DisplayTime 错误的问题

## [1.21.0] - 2024-08-08

### Added

- 添加 extraRenderPass 选项

## [1.20.8] - 2024-08-06

### Added

- 支持分别设置 Inner 和 Outer 的渲染系数

## [1.20.7] - 2024-07-29

### Added

- 添加接口用于获取 PassthroughProvider 的 Pose

## [1.20.6] - 2024-07-23

### Added

- 当使用 Quad Views 时，始终对 Inner Fov Pass 开启 Auto Resolve

## [1.20.5] - 2024-07-17

### Changed

- 更新 OpenXR Loader，删除对 YVR 拓展 SetColorSpace 的调用

### Added

- 增加 Get/SetEyeTrackingEnable 接口用于开关眼动追踪

## [1.20.4] - 2024-07-13

### Added

- 添加内部接口获取左右眼显示外参 YVRGetEyeBias

## [1.20.3] - 2024-07-10

### Changed

- 修改 StopPassthroughProvider 的调用位置在 OnGfxThreadStop
- 眼动数据支持通过 UnityXR 接口获取

## [1.20.2] - 2024-07-01

### Added

- 增加 Quad Views 渲染时 Main Pass 分辨率配置

## [1.20.1] - 2024-06-27

### Added

- 将 MultiView 作为 QuadViews 的 Fallback

## [1.20.0] - 2024-06-25

### Added

- 增加 QuadViews 渲染方式支持

## [1.19.6] - 2024-06-20

### Fixed

- 修复右眼 Culling 错误的问题

## [1.19.5] - 2024-06-20

### Changed

- 更新 d3 手柄贴图

## [1.19.4] - 2024-06-17

### Changed

- 优化 Quad Shape Composition Layer 更新性能

## [1.19.3] - 2024-05-30

### Changed

- 修改 PassthroughProvider 和 Swapchain 的创建销毁顺序

## [1.19.2] - 2024-05-29

### Added

- 增加 AutoRolve Flag 切换功能

## [1.19.1] - 2024-05-24

### Added

- 添加 d3 手柄模型和动画

## [1.19.0] - 2024-05-22

### Added

- 支持通过 XRMeshSubsystem 获取追踪信息

## [1.18.0] - 2024-05-21

### Added

- 添加 Unity 获取 VST 画面的功能

## [1.17.4] - 2024-05-03

### Fixed

- 修复 Composition Layer 不变要的 LateUpdate 更新

## [1.17.3] - 2024-04-30

### Fixed

- 修复 surfaceSwapchain 和 StaticImage 隐藏显示后不显示的问题
- 修复 staticImage 报错问题

### Added

- 完善 compositeLayer 测试场景

## [1.17.2] - 2024-04-26

### Added

- 添加 SetSurfaceDimensions 方法修改 surface 尺寸

## [1.17.1] - 2024-04-13

### Changed

- 手柄的摇杆类型从 Vector2Control 改为 StickControl

## [1.17.0] - 2024-04-12

### Added

- 添加对 SurfaceSwapchain 的支持

## [1.15.2] - 2024-03-25

### Removed

- 删除空间锚点中的 Debug 日志

### Added

- 更新 OpenXR，增加 MeshTracking 接口

## [1.15.1] - 2024-03-1

### Removed

- 删除无用的 Log 信息

## [1.15.0] - 2024-03-15

### Added

- 为 Core 中的代码都添加命名空间
- 适配 Utilities 的命名空间

## [1.14.10] - 2024-03-12

### Fixed

- 修复 YVRQualityManagerEditor 显示异常的问题

### Added

- 在没有勾选 yvrloader 的时候在打包时移除 yvr 相关依赖库

## [1.14.9] - 2024-03-01

### Added

- 添加动态分辨率功能
- 添加 XR_EXT_eye_gaze_interaction 眼动扩展

### Changed

- 删除 eyeResolutionScale 设置

## [1.14.8] - 2024-02-27

### Fixed

- 修复偶现的在 Unity 启动时加载 Project Settings Icon 失败的问题

## [1.14.7] - 2024-02-21

### Added

- Manifest 添加 Scene 权限，当支持 Scene 时默认支持 Spatial Anchor

## [1.14.6] - 2024-02-19

### Changed

- scene 相关锚点适配 meta 方案

## [1.14.5] - 2024-02-02

### Changed

- 修改 scene anchor 位置为 box2D 平面中心，box3d 为上表面中心

## [1.14.4] - 2024-01-29

### Added

- 在 Manifest 中增加版本号的 meta-data

## [1.14.3] - 2024-01-25

### Fixed

- 修复 setEyeBufferSettings 报空的问题

## [1.14.2] - 2024-01-24

### Fixed

- 修复获取 scene count 始终为 0

## [1.14.1] - 2024-01-22

### Fixed

- 修复导入 XRI 后的编译问题

## [1.14.0] - 2024-01-22

### Added

- 增加对 XRHand Package 的支持
- 增加 CompositeLayer 对 Equirect 和 Equirect2 的支持

## [1.13.0] - 2024-01-05

### Added

- 添加对 ProjectionLayer 和 CompositeLayer 的超采样和锐化
- 添加 DFFR

## [1.12.3] - 2023-12-25

### Fixed

- 修复创建空间锚点有概率闪退问题

## [1.12.2] - 2023-12-15

### Changed

- 将 CL 中部份 private 字段改为 protected

## [1.12.1] - 2023-11-30

### Added

- Native 增加 SetPassthroughMode 模式

## [1.12.0] - 2023-11-30

### Added

- 添加眼动追踪功能
- 添加空间锚点功能

## [1.11.6] - 2023-11-16

### Added

- 每一次 Focus，Visibility 重新获取时都会刷新 ipd 信息

### Fixed

- 修复获取左右眼位置信息相同问题

## [1.11.5] - 2023-11-10

### Fixed

- 修复 previewtool 中左手柄获取按键出错

## [1.11.4] - 2023-11-09

### Changed

- 修改 YVRInputDataDummyProvider 中的 rayTransform

## [1.11.3] - 2023-11-07

### Fixed

- 修复息屏亮屏后，重复创建 render layer 问题

## [1.11.2] - 2023-11-03

### Fixed

- 修复导入 sdk 后 vr mode 默认是 false 的问题
- 修复场景中 AudioSource 的 Clip 是 null 导致报错的问题

## [1.11.1] - 2023-11-01

### Add

- 支持 XRSettings 设置 eyeTextureResolutionScale, renderViewportScale 接口

## [1.11.0] - 2023-10-12

### Add

- 编辑器预览增加手势支持

## [1.10.9] - 2023-10-10

### Changed

- 更新手势模型

## [1.10.8] - 2023-09-25

### Removed

- 删除 Display Latency 相关数据
- 删除 Tracking with ipd 相关配置

## [1.10.7] - 2023-09-21

### Add

- 适配 OpenXR 1.0.30

## [1.10.6] - 2023-09-19

### Add

- 添加对 OptimizeBufferDiscard 的支持

### Changed

- 将 systemSplashScreen 和 6Dof 重命名

## [1.10.5] - 2023-09-18

### Fixed

- 修复 FFR 在最新 rom 上失效的问题

## [1.10.4] - 2023-09-15

### Fixed

- 修复 YVRInput.clickedControllerType/touchedControllerType 的值，在单只手柄连接时进入手势后判断错误

## [1.10.3] - 2023-09-13

### Add

- 添加到 org.khronos.openxr.intent.category.IMMERSIVE_HMD 的 category 到 AndroidManifest.xml

## [1.10.2] - 2023-09-12

### Add

- 添加 Project Setup Tool 的 Status Icon 提示
- 添加 3Dof/6Dof uses-feature 到 AndroidManifest.xml

## [1.10.1] - 2023-09-05

### Changed

- 将部份 YVR 扩展改为 FB 扩展

## [1.10.0] - 2023-09-04

### Add

- 添加 OS Splash Screen 功能

## [1.9.4] - 2023-08-25

### Fixed

- 修复 resume 后 ProjectionLayer 卡的问题

## [1.9.3] - 2023-08-16

### Changed

- 将 ASW 改为 AppSW

## [1.9.2] - 2023-08-14

### Changed

- 将 Use Unity XR 默认值改为 true

## [1.9.1] - 2023-08-11

### Changed

- 矫正手柄预制体旋转角度，实例化后无需设置 rotation

## [1.9.0] - 2023-08-11

### Added

- 添加 ASW 功能

## [1.8.0] - 2023-08-01

### Changed

- 修复 renderLayerId 管理混乱的问题

## [1.7.8] - 2023-07-27

### Changed

- 移除了对 libc++ 的依赖

## [1.7.7] - 2023-07-19

### Changed

- 优化手柄动画和手势动画

## [1.7.6] - 2023-07-17

### Changed

- 优化手势接口造成的 GC

## [1.7.5] - 2023-07-13

### Changed

- 移除 Plugin 中输入设备切换事件，改为查询，移除地面距离检测事件

## [1.7.4] - 2023-07-07

### Fixed

- 修复 Core 在旧版本 Unity 中的部份编译错误

## [1.7.3] - 2023-07-05

### Fixed

- 修复当使用 CompositLayer 时打开关闭 UI 面板会影响到手势模型的透明度

## [1.7.2] - 2023-07-04

### Added

- 增加兼容性，仅在系统支持 Local_Floor 时才启用该拓展。

## [1.7.1] - 2023-07-03

### Added

- 补全 YVRHMDManager 中 PassThrough 开关的实现

## [1.7.0] - 2023-06-30

### Added

- 添加 ProjectSetup 功能

## [1.6.12] - 2023-06-28

### Added

- 增加 PassThrough 接口，直接开启/关闭 Passthrough

## [1.6.11] - 2023-06-25

### Fixed

- 修复打开 PassThrough 时，面板 Flag 错误导致混合效果错误的问题

## [1.6.10] - 2023-06-25

### Changed

- 重命名 SetFocusAwareness 为 SetSystemMenuMode

## [1.6.9] - 2023-06-25

### Added

- 使能 OpenXR Local—Floor 拓展

## [1.6.8] - 2023-06-20

### Added

- CompositeLayer 适配 XROrigin
- 新增获取四目相机数据接口

### Changed

- 当前点击的手柄改为 GetDow
- 更新 OpenXR Loader

### Fixed

- 修复 Recenter 失效问题

## [1.6.7] - 2023-06-16

### Changed

- 更新 OpenXR Loader

## [1.6.6] - 2023-06-14

### Changed

- 更新 OpenXR Loader

## [1.6.5] - 2023-06-06

### Changed

- 更新默认手柄贴图，材质使用 Unlit

## [1.6.4] - 2023-06-02

### Changed

- 兼容 Unity 低版本 API
- 仅当 YVRControllerEmulator 存在时，才使用 YVRControllerEmulator，而不是通过 instance 创建一个新的 YVRControllerEmulator。

## [1.6.3] - 2023-06-02

### Changed

- 延缓 Composite Layer 对 YVRManager 的依赖，仅在具体访问 YVRManager 时才访问 instance

## [1.6.2] - 2023-05-31

### Added

- AndroidManifest 文件中添加是否使用手势的标签

### Changed

- 更新默认手柄的 URP 材质

## [1.6.1] - 2023-05-29

### Fixed

- 修复头部转动时指针位置发生偏移
- 移除应用内开关手势接口

### Added

- 支持获取 Grip 键的键程值

## [1.6.0] - 2023-05-29

### Added

- 增加设置/获取手柄模型类型和抗眩晕等级的接口

## [1.5.8] - 2023-05-26

### Fixed

- 修复手势骨骼点坐标为世界坐标导致的模型显示偏移

## [1.5.7] - 2023-05-24

### Fixed

- 修复 RecreateLayer 删除 id2RenderLayerMap 后无法正常销毁 Layer 的问题

## [1.5.6] - 2023-05-24

### Add

- 添加手势捏合指针效果

## [1.5.5] - 2023-05-19

### Fixed

- 修复 RecreateLayer 后无法销毁 Native 中 RenderLayer 和 id2RenderLayerMap 的问题

## [1.5.4] - 2023-05-18

### Add

- 子物体支持可以挂载 YVRCurvedUIRaycaster

## [1.5.3] - 2023-05-16

### Fixed

- 修复 Composite Layer 序列化错误问题
- 修复 Hand 相关资源 Meta 资源冲突问题

## [1.5.2] - 2023-05-12

### Add

- 添加获取曲面 remappedPosition 和 CL shape 的方法

## [1.5.1] - 2023-05-12

### Changed

- 移除 YVRHandManager 中关于切换手柄与手势的方法
- 移除 CompositeLayer 中打洞相关代码

## [1.5.0] - 2023-05-09

### Added

- 增加对 Cylinder CompositeLayer 的支持

## [1.4.0] - 2023-04-12

### Added

- YVRManager 增加 useUnityRig 字段，用以标明是否使用了 Unity 自带的 XR Rig 组件

### Changed

- 将 YVRPerformanceManager 调整为 static 类

## [1.3.13] - 2023-04-12

### Added

- 在应用 Display 被销毁时，销毁 OpenXR Instance

## [1.3.12] - 2023-04-12

### Changed

- 新手柄材质由 lit 改为 simple lit

## [1.3.11] - 2023-04-12

### Changed

- 更新手柄材质

## [1.3.10] - 2023-04-11

### Added

- 添加新的手柄模型

## [1.3.9] - 2023-04-11

### Added

- 在 Pass Through 模式下，永远将第一层 Layer 设置为半透明

## [1.3.8] - 2023-04-10

### Fixed

- 修复应用退出时，OpenXR 相关资源未释放的问题

## [1.3.7] - 2023-04-04

### Added

- 添加空间感应接口

### Changed

- 移除手势代码中冗余的数据结构，移除手势模型的 animator 组件

## [1.3.6] - 2023-04-01

### Fixed

- 修复 AAR 错误的问题

## [1.3.5] - 2022-03-31

### Added

- 添加强制使用头控接口

## [1.3.4]-2022-03-31

### Changed

- 减少获取当前射线交互的 UI 对象时的 GC 分配

### Fixed

- 修复 Composite Layer 在 Disable 状态下无法创建的问题

## [1.3.3] - 2022-03-28

### Added

- YVRCompositeLayer 增加对于是否显示的判断，仅在显示时更新画面数据

## [1.3.2] - 2022-03-28

### Fixed

- 修复在多帧内连续创建 Layer，会导致有无效的 Layer 被添加至 Layer List，造成性能浪费的问题。

## [1.3.1] - 2023-03-28

### Fixed

- 修复切换手势与手柄输入源事件，在渲染线程操作游戏对象引起的崩溃问题

## [1.3.0] - 2023-03-24

### Changed

- 将 Composite Layer 的渲染顺序调整为 PostSubmit

### Added

- 为 CompositeLayer 增加 SetTexture 功能

## [1.1.12] - 2023.03.22

## Changed

- 增加手势追踪支持

## [1.1.11] - 2023.02.20

## Changed

- 回退 VR Only 改动

## [1.1.10] - 2023.02.17

## Added

- 新增内部设置 ColorSpace 接口

## [1.1.9] - 2023.01.11

## Fixed

- Focus/Visible 异常触发两次的问题
- MultiPasses 模式下，画面存在撕裂的问题

## Changed

- 默认启用 Android Session

## [1.1.8] - 2023.01.11

## Fixed

- 修复手柄断开时，充电状态错误的问题

## [1.1.7] - 2023.01.11

## Changed

- 更新 openxr_loader.so 版本

## [1.1.6] - 2023.01.09

## Fixed

- 修复 FFR 在应用 Pause / Resume 后失效的问题

## [1.1.5] - 2022.12.30

## Added

- 添加启用和关闭 Boundary 的接口

## [1.1.4] - 2022.12.30

## Changed

- 回退对于 Vulkan 模式 Crash 的修复，该修复会导致上层 Unity 状态读取失败

## [1.1.3] - 2022.12.28

## Added

- 支持通过 OpenXR 接口获取头盔/手柄加速度（目前算法数据仍然为 0）

## Changed

- 允许在应用非 Focus 状态下设置手柄震动

## [1.1.2] - 2022.12.20

## Changed

- YVRSetCameraFrequency 接口返回 bool 值表示接口是否设置成功

## [1.1.1] - 2022.12.15

## Changed

- 更新编译生成的 aar

## [1.1.0] - 2022.12.15

## Added

- 增加获取/设置 Camera 频率的接口

## [1.0.0] - 2022.12.13

## Fixed

- 修复 Editor 下键盘模拟失效的问题

## [1.0.0-preview.12] - 2022.11.28

## Removed

- 删除不必要的 Log 信息

## [1.0.0-preview.11] - 2022.11.25

## Added

- 当 End Session 时，重置 SwapChain 和 Frame
- 当创建新的 App Space 时，删除之前的 Space

## [1.0.0-preview.10] - 2022.11.24

## Added

- 增加 VR Widget 功能

### Changed

- 将 Begin/End Session 移动至渲染线程
- 增加编译 Clear 功能

## [1.0.0-preview.9] - 2022.11.18

### Added

- 增加 YVRSetAsVRWidget 接口
- 增加接口获取 Controller 和 HMD 的 MCU 版本

### Fixed

- 修复每一帧都存在从主屏 SwapChain 开销的问题

## [1.0.0-preview.8] - 2022.11.14

### Changed

- 将 YVRCompositeLayer 中 LateUpdate 调整为 protected

## [1.0.0-preview.7] - 2022.11.14

## Added

- 同步原 Master 分支所有改动

### Fixed

- 修复 Physical Pose Predict Time 不准确问题
- 修复 Focus 事件上报不准确问题
- 修复 Multi Pass 应用在 Pause / Resume 后画面撕裂的问题

## [1.0.0-preview.6] - 2022.11.4

### Fixed

- 修复 OpenXR Boundary 相关拓展错误使用的问题
- 修复 Recenter 事件未被正常触发的问题
- 修复 Controller Emulator 不生效的问题
- 增加 Android Sessnion 拓展支持，该拓展用于控制 Session 启用的生命周期
- 增加临时 Log 以确认 OpenXR 按钮问题

## [1.0.0-preview.5] - 2022.11.4

### Changed

- 适配 Guardian 相关的 OpenXR 拓展 Action 修改

## [1.0.0-preview.4] - 2022.11.3

### Changed

- 修改应用以 System Menu 形式运行时的 OpenXR Layer Type

## [1.0.0-preview.3] - 2022.11.3

### Fixed

- Editor 中手柄模拟器不生效问题

## [1.0.0-preview.2] - 2022.11.3

### Fixed

- 部分 OpenXR 生命周期异常导致的渲染失败问题

## [1.0.0-preview.1] - 2022.11.2

### Added

- 恢复对 VRAPpiHander 的支持

## [1.0.0-preview.0] - 2022.10.31

### Added

- Vulkan experimental support

### Changed

- 使用 OpenXR 作为 Backend，完全删除 YVR Lib 支持

### Known-Issues

- Vulkan API 下 Composite Layer 失效
- Vulkan API 下 FFR 失效
- VUlkan API 下 GPU 占用率过高
- APIHandler 失效

## [0.7.4-preview.1] - 2022-10-21

### Changed

- CompositeLayer 中的 requireToForceUpdateContent 访问等级调整为 protected

## [0.7.4-preview.0] - 2022-10-08

### Added

- 增加获取四目相机数据接口

### Fixed

- 应用暂停和恢复时对 RT 的重绘操作导致透明部分有杂色

## [0.7.3-preview.2] - 2022-09-01

### Added

- Unity 编译应用选择 Development 模式时，将 Display Subsystem 的 PresentToMainScreen 打开，一些调试应用，如 RenderDoc 依赖该选项。
- 修复静态 Composite Layer 在第一次创建时会导致应用 Crash 的问题。
- 修复当应用在 Gamma Space 时，会出现的使用 SRGB 纹理警告
- 从 Native 获取左右眼位置/旋转角度的数据
- 增加可以清除 '当前手柄链接、点击、触摸 状态' 的接口。

## [0.7.3-preview.1] - 2022-08-31

### Added

- 在设置 FocusAwareness 开关时设置需要更新 layer 的 flag 状态
- 添加 YVRSetSkipFrameCount，可以设置跳过指定帧数提交

## [0.7.3-preview.0] - 2022-08-26

### Fixed

- 修复在 Awake 函数中触发 YVRManager.instance 后，无法获取头盔/手柄位姿的问题

## [0.7.2-preview] - 2022-08-23

### Added

- YVRInput 中添加设置/获取系统全局中的手柄的接口
- 增加 setLayerFlags & unsetLayerFlags 接口

## [0.7.1-preview] - 2022-08-18

### Added

- 编辑器下增加设置 AppId 窗口
- YVRloader 加载时上报 sdk 信息

### Fixed

- 移除 core Asembly 中对 platform 的引用
- 重复设置 FocusAwareness layer Visiable 状态，

## [0.7.0-preview] - 2022-08-12

### Added

- 添加 FocusAwareness 相关接口

## [0.6.12] - 2022-08-10

### Fixed

- 修复 singlepass 下深度检测失效
- 修复通过 InputDevices.GetDevicesAtXRNode 接口获取 Head 节点值时失败
- 修复 URP 下 Linear 空间色彩不准确问题

## [0.6.11] - 2022-08-02

### Added

- 添加内部接口来设置和获取原地边界半径尺寸

## [0.6.10] - 2022-07-29

### Fixed

- 修复 Linear 色彩空间下存在错误色阶的问题

## [0.6.9] - 2022-07-25

### Added

- xr 支持 TrackingOriginMode 设置

## [0.6.8] - 2022-07-19

### Fixed

- inputsystem 中手柄获取菜单键及 Home 键失败
- 在 XRRig 中使用 CompositeLayer 时画面出错
- 解决 YVRInput 中 Update 和其他 MonoBehavior 的执行顺序不确定的问题。

## [0.6.7] - 2022-07-05

### Added

- 支持在 URP 环境下分别为左右眼渲染不同的 Layer。

## [0.6.6] - 2022-06-22

### Fixed

- 修复应用无 Splash 时启动 Crash 问题

## [0.6.5] - 2022-06-21

### Added

- 可在运行时动态修改 Composite Layer Depth 数据

### Fixed

- 修复偶现 RenderLayer Index 超过 Layer Count 的问题

## [0.6.4] - 2022-06-17

### Fixed

- 修复 unity 2019 的不支持问题

## [0.6.3] - 2022-05-26

## Added

- 在 Layer 被隐藏/Pause 时释放 SwapChain，以节省内存开销

## [0.6.2] - 2022-05-13

### Fixed

- 修复 Display Rate 偶现错误变为 72 帧问题

## [0.6.1] - 2022-05-12

### Fixed

- 修复 RamLog so 文件重复的问题

## [0.6.0] - 2022-05-12

### Changed

- 正式发布 0.6.0

## [0.6.0-preview.0] - 2022-05-12

### Added

- 增加 YVRNative2YLogAdapter 支持 Native Log 传输至 YLog 输出

### Fixed

- 修复了单 Buffer Layer 的 Index 错误问题

### Removed

- 从 Native 删除 YLog

## [0.5.3] - 2022-05-11

### Added

- YVRInput 中增加获取手柄充电状态接口

## [0.5.2-preview.0] - 2022-05-10

### Fixed

- 修复 Layer Handle 相关代码在 Unity 2019 中编译失败的问题

## [0.5.1] - 2022-04-27

### Added

- 增加对 Composite Layer 生命周期 Callback 的测

### Changed

- 移动 Object Reflection 相关测试进 Object 文件夹

### Fixed

- 修复被销毁的 Layer 导致的 NullReference

## [0.5.0] - 2022-04-19

### Changed

- 更改 YVRBaseRig 中关于位置更新方法的访问修饰符为 public。让它可以在外部被取消订阅（满足自动化测试等需求）

## [0.5.0-preview.2] - 2022-04-16

### Added

- 增加 OnPostSubmitGfx 事件

## [0.5.0-preview.1] - 2022-04-15

### Fixed

- 修复 Composite Layer 偶现数据错误问题（包括无内容/位置错误）

## [0.5.0-preview.0] - 2022-04-13

### Changed

- 将 Composite Layer 的 UpdateLayerContent 的操作移至 LateUpdate 中调用，更加直观
- 更新 PreRender 时同时更新 CompositeLayer 的 Matrices。

## [0.4.37-preview.0] - 2020-4-08

### Added

- 将 Composite Layer 部分初始化移至 Awake 函数中

## [0.4.37-preview.0] - 2020-4-08

### Added

- 增加 LayerHandler 封装 Layer 相关操作
- 增加 Events Manager 封装关于事件的回调
- 增加关于 Composite Layer 的单元测试

### Changed

- 调整 Composite Layer Demo 场景，提供静态及动态展示

## [0.4.36] - 2022-03-31

### Fixed

- 修复由 native 事件造成的 crash

## [0.4.35] - 2022-03-15

### Changed

- 将所有与 Layer 相关的操作都移至 Render 线程操作。

## [0.4.34] - 2022-03-03

### Fixed

- 修复由 `RamLog` 造成的 crash

## [0.4.33] - 2022-02-21

### Added

- 保存 Core 版本号，并在 YVRManager 初始化时打印 Core 和 Utilities 的版本号
- 将 Utilities 的依赖版本改为 0.1.18

## [0.4.32] - 2022-02-14

### Added

- 删除 CompositeLayer 的时候释放底层 compositelayer 和 RTSwapChain
- C# 以回调方式监听 C++ 事件，现有支持事件 onRecenterOccurred、onFocusGained、onFocusLost、onVisibilityGained、onVisibilityLost

### Fixed

-修复当使用 Separate Eyes 时 monoscopic 失效的问题

## [0.4.31] - 2022-01-19

### Revert

- 回退 "修复 `YVRCompositeLayer` 在`RenderTexture`还没有被`Camera`渲染完成时就将数据传递给 Native，从而导致`CompositeLayer`绘制的画面会比`Unity`的实际画面晚一帧的问题。"

## [0.4.30] - 2022-01-18

### Added

- 在 `YVRInputModule` 中添加选项，勾上后当接收到 `onFocusLost` 回调就停止 `YVRInputModule` 的功能

### Fixed

- 修复 `RamLog` 输出 `logcat` 及保存到本地时 `tag` 错误的问题。
- 修复 `YVRCompositeLayer` 在`RenderTexture`还没有被`Camera`渲染完成时就将数据传递给 Native，从而导致`CompositeLayer`绘制的画面会比`Unity`的实际画面晚一帧的问题。

## [0.4.29] - 2022-01-14

### Changed

- 将 `YVRCameraRig` 预制体的 center camera `nearclip` 改为 0.1

### Fixed

- 修复 `YVRCompositeLayer` 在申请贴图时、会乘两次`RenderScale`，导致贴图尺寸异常、过大的问题。

## [0.4.28] - 2022-01-07

### Fixed

- 修复 YVR Manager 中 onFocusLost 和 onVisibiltyLost 第一次没有执行
- 修复 GetControllerBattery 传参为 ControllerType.Touch/Active/All 时结果异常

## [0.4.27] - 2022-01-05

### Fixed

- 修复 Visibility 相关事件未被触发的 Bug
- 修复 CompositeLayer 被禁用、恢复后，其在 OnBeforeRender 里的注册的行为会出错的 Bug

## [0.4.26] - 2022-01-04

### Added

- 增加获取 Runtime 版本的接口

### Changed

- 在 compositeLayer 被禁用时、取消其在 OnBeforeRender 中注册的行为，以减少消耗

### Fixed

- 修复由于传输给 Native 的 Layer 数量错误导致的 Crash 问题

## [0.4.25] - 2021-12-30

### Added

- 增加手柄预测状态接口，供内部使用
- 增加获取 Runtime Service/Client 版本号接口，供内部使用

## [0.4.24] - 2021-12-29

### Added

- 增加 Focus/Visibility gained/lost 事件

## [0.4.23] - 2021-12-23

### Added

- 基于 RamLog 封装 YLog 模块
- 将 yvrPoseState 里的所有数据转换到 Unity 坐标系

### Changed

- platformSDK 版本更新至 0.1.5
- 修改 Api Documentation 的第一页内容
- update projection unit version to 2020.3.25
- udpate project utilities to 0.1.10

### Fixed

- 修复多线程同时访问 LayerVec 时可能造成的内存错误问题

## [0.4.22] - 2021-12-16

### Changed

- 移除对安卓面板的支持，修改一些变量的访问权限。

## [0.4.21] - 2021-12-16

### Changed

- 将 Utilities 的依赖版本提升至 0.1.10
- 手柄材质球丢失 shader 引用

## [0.4.20] - 2021-12-16

### Fixed

- 修复 C++ 侧 RenderLayer 初始化时可能存在的 ColorHandle 脏内存
- 修改 SDK 的说明文档和接口注释

## [0.4.19] - 2021-12-13

### Fixed

- 修改 Boundary 接口 GetGemetry 数据和安全边界显示的不一致

### Added

- 增加 UnderlayPuncher_Transparent_KeepColor shader，该 Shader 可在打洞的基础上保留有色彩缓冲原先的颜色

## [0.4.18] - 2021-12-07

### Fixed

- 修改 2DLauncher 在绘制 GL_TEXTURE_EXTERNAL_OES 类型纹理时概率性 crash

## [0.4.17] - 2021-12-06

### fixed

- 修复 YVRGetBoundaryConfigured 一直返回 true
- OnlyVR 第一次导入的时候默认设置为 Ture 没有生效

### Added

- 增加接口 YVRGetBoundaryGeometryPointsCount，获取安全边界顶点数量

## [0.4.16] - 2021-12-02

### Added

- 增加 onRecenterOccurred 事件，表示在当前帧发生了重定位

### Changed

- 使用 GetClickedController / GetTouchedController 取代 GetUsedController

### Fixed

- 修复 YVRCameraRig 上的丢失脚本

## [0.4.15] - 2021-12-01

### Added

- YVRInputModule 中添加 GetFirstRaycast / inputDataProviderSource 数据

### Changed

- 适配 RectTransform 的拓展函数 RayIntersects
- 将 Utilities 的依赖版本提升至 0.1.19

## [0.4.14] - 2021-11-30

### Changed

- 当左右手柄都连接时，默认使用右手柄作为 Raycaster 的数据提供者

### Fixed

- 修复多 Canvas 时交互错误的问题
- 修复应用切换后，屏幕刷新率改动失效的问题

## [0.4.13] - 2021-11-29

### Added

- 增加 usedController 接口表示最新使用的手柄
- 在 YVRInputModule 中增加对 Drop Event 的支持

### Changed

- yvrDataControllerProvider 中默认以 Controller Anchor 作为射线七点

### Fixed

- 修复当一个 Graphic Raycaster 无 Event Camera 时导致所有 Graphic Raycasters 失效的问题。

## [0.4.12] - 2021-11-23

### Added

- YVRInputModule 添加 customProvider 支持自定义输入数据。

## [0.4.11] - 2021-11-18

### Changed

- Internal YVRSetBoundaryTypeVisible 接口增加关于是否是退出的 bool 值判断。
- 为 CompositeLayer 示例场景增加 Discard / Transparent Underlay Puncher 示例场景。

### Fixed

- 修复在 Unity EyeBuffer 创建前，修改它们 FFR 系数导致异常的问题
- 非 Raycast Target 的 UI 元素仍然会被交互

## [0.4.10] - 2021-11-17

### Added

- 增加初始化 CompositeLayer 时，指定 CompositeDepth 的接口。

## [0.4.9] - 2021-11-09

### Added

- 增加内部 API 接口 YVRSetBoundaryTypeVisible(yvrlib_internal_SetThisBoundaryTypeVisible)

## [0.4.8] - 2021-11-04

### Added

- 在打包的时候自动在 androidmanifest 文件中添加 vr_only

### Changed

- 更新 API_LIB release 仓库

### Fixed

- 修复非 Dynamic Composite Layer 无法渲染的问题

### Removed

- 删除 Tracking Mode 相关接口

## [0.4.7] - 2021-11-01

### Added

- 增加 URP 手材质为半透明描边

### Changed

- 优化手部动画状态机

### Fixed

- 修复头盔速度，加速度无法获取的问题
- 修复使用 Dynamic Composite Layer 时，画面撕裂问题

## [0.4.6] - 2021-11-01

### Added

- Composite Layer 支持多块 Swapchain Buffer，用以解决画面撕裂问题

### Changed

- 减少 Unity Eye Buffer 内存消耗，之前 SwapChain 的 Buffer 数为 4，先改为最低满足要求的 Triple Buffer。

## [0.4.5] - 2021-10-30

### Added

- 增加编译内部文档的支持，当执行命令 BuildDocument.bat 3 时即为编译内部文档。
- 支持动态切换 Extra Latency 模式

### Changed

- 将 手势相关的 Mesh 数据移动到 Mesh 文件夹中
- 将文件夹命名从 document 调整为 documentation
- 使用 C# ??= 关键字简化初始化流程

### Fixed

- 修复文档中关于 Package 的错误说明
- 修复当 ControllerType 为 None 时，返回值错误的问题。之前当为 None 时，返回的为 Int.MinValue 或 Float.MinValue，现在统一调整为 0。
- 修复当 Target ControllerType 是 None 或 All 时 IsControllerConnect 返回值错误的问题。
- 修复手柄断开连接后，按键数据错误的问题。

### Removed

- 删除 GetAppFrameRate 接口，后续开发者可以通过 System UI 查看帧率
- 删除无用 Dominant Hand 接口，目前 Launcher 内并无设计相关 UI

## [0.4.4] - 2021-10-23

### Added

- 暴露颞部接口 OnGuardianEnter

### Changed

- 更新 Submodule URL

## [0.4.3] - 2021-10-22

### Added

- 增加内部 API 接口 YVRGetBoundaryGameTypeDataStatus
- 支持直接将 Unity 的 RT 直接绑定到 SwapChain 上。

### Removed

- 修复 Boundary 相关 API 不生效的问题

## [0.4.2] - 2021-10-22

### Fixed

- 修复 SetLayerFlags 失效的问题，且重命名为 LockLayerFlags

## [0.4.1] - 2021-10-21

### Added

- 支持运行时动态切换 Composite Layer 显示状态
- 增加 CompositeLayer Demo 场景

### Changed

- 工程包名修改为全小写
- 删除部分无用资源，将 Demo 场景相关资源移动到 Scene 中
- 为 YVRHandAnimData 脚本添加命名空间

### Removed

- 删除 IsRecenterOccurred 查询时的 Log 输出

## [0.4.0] - 2021-10-14

### Added

- 支持 Quad Composite Layer，包括 Overlay 及 Underlay
- 增加 手+手柄 模型的 URP 材质

### Changed

- Native 重构渲染模块，进一步封装各渲染操作

## [0.3.27] - 2021-10-08

### Added

- 在 EnterVR 时默认开启 ExtraLatencyMode

## [0.3.26] - 2021-10-06

### Changed

- 更新 API_LIB 版本至 1a3b1d655a4c04af

## [0.3.25] - 2021-09-30

### Changed

- 更新 API_LIB 版本至 4c9789b70d91eb8d3b918de7b78d50e3761ff122

## [0.3.24] - 2021-09-29

### Changed

- 更新 API-LIB 版本至 0.3.24
- 手柄模型设置为 IsReadAble

## [0.3.23] - 2021-09-28

### Added

- 新增 SetLayerMatrix 内部接口

### Changed

- 更新 API_LIB 至 1.0.1.1

## [0.3.22] - 2021-09-26

### Changed

- 更新 API_LIB 至版本 11a3fb697d216fcba628e3ba4adfd595d2b5c9

## [0.3.21] - 2021-09-25

### Changed

- 调整手柄手势贴图文件大小
- Native 不再进行手柄坐标系转换，默认数据为世界坐标

## [0.3.20] - 2021-09-23

### Added

- 新增内部 Get/Set BoundaryType 接口
- 增加手柄手势相关模型及动画

### Fixed

- 修复 GetPositionTracked 数据错误问题

## [0.3.19] - 2021-09-16

### Changed

- 更新 API_LIB, 主要修复手柄 Track 状态的获取问题

## [0.3.18] - 2021-09-16

### Changed

- 更新 API_LIB, 主要提升部分接口性能问题

## [0.3.17] - 2021-09-13

### Changed

- SetTrackingMode, Recenter 调整为 Internal 接口
- isUserPresent 调整为 bool 值范围

### Removed

- C# 端删除 SetTrackingMode，Recenter 接口暴露

## [0.3.16] - 2021-09-13

### Changed

- 减少 Input 和 ControllerRig 更新函数造成的内存分配

### Fixed

- 修复无速度，加速度等数据的问题
- 修复 isUserPresent 返回值错误问题

### Removed

- 删除 resetOnRelaoded 接口
- 暂时删除 UserPresent 检测

## [0.3.15] - 2021-09-08

### Changed

- 使用 4 float 表示 Render Layer 的顶点

## [0.3.14] - 2021-09-06

### Added

- 增加 YVREventsMgr 管理 YVR 相关事件，目前仅内部暴露 Recenter Occurred 事件。

### Fixed

- 修复左手柄无法触发 All 按键的问题。
- 修复 None 按键会被触发的问题

### Removed

- 目前手柄侧键是按键而非是 Trigger，因此从 API 中删除相关数据。

## [0.3.13] - 2021-08-28

### Added

- 增加内部接口 YVRClearBoundaryData 清除所有 Boundary 数据

## [0.3.12] - 2021-08-28

### Added

- 增加 YVRForceBoundaryNoneVisible API 来强制管理安全边界（无视当前是否碰撞到安全边界）

## [0.3.11] - 2021-08-26

### Fixed

- 修复 IPD Tracking 失效的问题

## [0.3.10] - 2021-08-25

### Added

- 初步实现 Overlay 功能，已知问题：
  1. Overlay 位置与 EyeBuffer 不完美匹配
  2. Overlay 在位置变换时 UV 计算错误
  3. 不支持动态修改 Overlay 内容

### Fixed

- 修复 Tracking Space 失效问题

## [0.3.9] - 2021-08-21

### Fixed

- 修复 YVRSetLayerFlags API 失效的问题

## [0.3.8] - 2021-08-19

### Changed

- 重构 Unity Native 代码结构，拆分功能至对应模块，如 Rendering，Tracking，UnityXR
- 增加 YVRRenderLayersMgr 管理 Frame Layers
- 适配 API LIB 关于 TextureLayer 的修改，目前以 4 个顶点修饰对应的 Layer

### Fixed

- 修复无启动 Splash 时 SDK Crash 的问题

## [0.3.7] - 2021-08-16

### Changed

- 更新 APILIB 至版本 237c98a0

## [0.3.6] - 2021-08-11

### Added

- 增加 GetPositionTracked / GetOrientationTracked 接口判断手柄追踪状态

### Fixed

- 修复 MultiView 依赖过时 XR Settings 的问题

## [0.3.5] - 2021-08-09

### Added

- 增加 ControllerTracked 接口判断手柄是否正在被追踪

### Fixed

- 修复程序从休眠唤醒后重复添加 Render Layers 的问题

## [0.3.4] - 2021-08-06

### Added

- 增加 SetBoundaryVisible API_LIB
- Project 增加 vr-only 标记

### Changed

- 增加 YVRAPILib_release 作为提供 AAR 编译需要的 so 和头文件的 Submodule，并适配对应编译方式

### Fixed

- 修改由 Native 坐标系修改导致的手柄坐标错误问题
- 修复由 System.Net 依赖导致的编译错误问题
- 修复由 API Lib 导致的预测时间错误问题

## [0.3.3] - 2021-08-04

### Added

- 支持 Gamma /Linear 切换
- 支持 FFR 渲染
- 支持在 YVR XR Settings 中设置 Tracking Mode。运行时的 Tracking mode 设置仍通过 TrackingStateManager 修改
- 支持 Tracking Space 相关设置
- 当开启 RecommendedMSAALevel 时，自动设置 MSAA Level
- 在 InputDataProvider 中添加属性 用来读取当前控制器摇杆的上下拨动

### Changed

- 适配 API_LIB 中所有接口的重命名
- 适配 Server 中头盔坐标系的调整

### Fixed

- 修复开启 Single Pass 时仅左眼部分有画面问题

### Removed

- 删除 C# 端无用设置

## [0.3.2] - 2021-07-30

### Added

- 增加 Render Scale 支持
- 增加 16-bit depth Buffer 支持
- 增加选择是否要使用 IPD 区分双眼的支持

### Fixed

- 修复 Layer / Frame 相关设置不生效的问题
- 修复 PC Emulator 不生效的问题

## [0.3.1] - 2021-07-28

### Added

- 增加 YVRGetRecenterPose 接口
- 支持 Multi Passes 和 Single Pass 的切换，但开启 Single Pass 时仍然需要依赖 Deprecated XR Settings

### Changed

- 替换左手柄模型，更加符合更新后的实际手柄

## [0.3.0] - 2021-07-26

### Added

- BREAKING! 渲染和追踪模块接入 Unity XR Subsystem

### KNOWN ISSUE

- FFR / Render Scale/ Overlay 暂不支持
- 目前强制开启 Single Pass，暂不支持切换

## [0.2.7] - 2021-07-20

### Added

- CreateSwapChain 时增加对 ArraySize 的支持

### Changed

- 更新手柄模型

## [0.2.6] - 2021-07-19

### Added

- 增加 SetPassThrough 的 Internal 接口

### Fixed

- 修复 Layer Flag 不生效的问题

## [0.2.5] - 2021-07-15

### Added

- 暴露部分接口给 Guardian 和 Controller Binding 使用

## [0.2.4] - 2021-07-12

### Added

- 提供一个可以设置 InputDataProvider 的方法

## [0.2.3] - 2021-07-10

### Added

- Add item

### Changed

- 在 BeginVR 时默认设置 CPU/GPU Level

### Fixed

- 当使用非对称 FOV 时，渲染错误的问题

## [0.2.2] - 2021-07-09

### Changed

- 更新版本 API LIB 版本至 15e7e3188a6cbfbdb8c494d5e390418947e96a35
- 将 EnterVR 调整为同步 API

### Fixed

- 修复在进入 VR 模式前，会渲染几帧普通 2D 画面的问题

## [0.2.1] - 2021-07-07

### Changed

- 更新 API_LIB AAR 版本，修改 internal 函数的接口命名
- 增加 CHANGELOG_User_Eng，为供用户查看的文档

## [0.2.0] - 2021-07-07

### Added

- 文档中增加 Global Search 功能

### Changed

- BREAKING! 修改 Native 接口为 VR Runtime 版本

### Fixed

- 修复手柄 Index 定义错误导致手柄不震动的问题

## [0.1.15] - 2021-06-24

### Changed

- 更新 Native AAR 至 b5b7fbffd26 版本

## [0.1.14] - 2021-06-19

### Added

- 增加 SetBoundaryData 和 GetRawHeadPose 接口

### Changed

- 调整部分代码访问修饰符，满足自动化测试要求

## [0.1.13] - 2021-06-18

### Added

- 新增 FrameOption 接口，可用来配置渲染帧状态，如是否需要 ATW

### Changed

- 更新 YVR Utilities 依赖至 0.1.5 版本
- 无视 Rider 编辑器自动生成的文件夹

## [0.1.12] - 2021-06-07

### Added

- YVRRenderLayer 增加修改 Composition Depth 接口
- 新增 SetBeginVROption 和 UnsetBeginVROption 接口，可用来修改 BeginVR 启动参数

### Changed

- 修改 BeginVR 参数传递方式

## [0.1.11] - 2021-06-07

### Added

- Native 新增手柄配对接口

## [0.1.10] - 2021-06-04

### Changed

- 更新 YVR API Lib

## [0.1.9] - 2021-05-27

### Changed

- 替换 Oculus 手柄模型为 YVR 手柄

## [0.1.8] - 2021-05-26

### Added

- Input Scene 增加更多调试信息
- 支持非对称 FOV 渲染
- 修复 Cursor 法线方向为 zero 时产生 Warning 信息

### Fixed

- 修复 Input Scene 场景中文字过长时，Debug Panel 空白问题

## [0.1.7] - 2021-05-13

### Changed

- 更新 YVR_API_LIB

### Fixed

- 修复摇杆数据没法返回负值的问题

## [0.1.6] - 2021-05-11

### Added

- 增加 enableHMDRayAgent Flag。当该 Flag 开启且双手柄都未连接时，会自动切换头盔作为交互射线的 Anchor，且 默认每 2 秒自动实现一次点击。

### Fixed

- 修复当 CameraRig 的旋转角度不为 0 时，模拟的手柄位置错误的问题
- 修复在左右手柄连接且未指定目标手柄时，所有的获取手柄状态的接口，都返回左手边数据。

## [0.1.5] - 2021-04-30

### Added

- 增加配置文件对 gUsingCustomDistort 的解析，用来切换畸变算法
- 增加 YVR Controller Emulator 中 TargetController，用来切换模拟的手柄
- 增加头盔/手柄模拟器相关文档
- 增加 Fixed Foveated Rendering 文档
- 增加 Single Pass 文档

### Changed

- 优化 Update/LateUpdate 时的内存分配
- 文档中 Debug Scenes 改名为 Demo Scenes

### Fixed

- 修复重定位后，手柄姿态错误问题

## [0.1.4] - 2021-04-26

### Added

- 增加对于 Unity Utilities 的文档引用
- 增加文档对于 PlantUML 的支持
- 增加 ExcludeFromDocsAttribute Attribute，可用于让特定内容不被文档引用
- 增加关于 VYRManager 的说明文档
- 增加 Single Pass 功能
- 增加 GL 宏，简化 Native 中 Check OpenGL Error 的流程
- 增加手柄位置调试接口

### Changed

- YVR Utilities 的依赖版本为 0.1.4
- 调整工程目录

### Fixed

- 修复文档无法编译的问题
- 修复手柄摇杆和扳机数据错误的问题
- 修复渲染相关的内容设置，在 Inspector 窗口中不显示的问题

## [0.1.3] - 2021-03-31

### Fixed

- 修复手柄按键无效的问题

## [0.1.2] - 2021-03-31

### Added

- 增加获取/设置 CPU / GPU 等级的接口
- 增加获取 CPU / GPU 利用率的接口
- 增加 Change Log 管理每一次更新内容

### Changed

- 使用 Package 方式管理依赖的 Utilities 包，依赖版本为 0.1.3

### Fixed

- 修复手柄纹理错误问题
