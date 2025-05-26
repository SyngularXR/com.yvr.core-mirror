# Camera

介绍在 PFDM 中如何使用 AR Foundation 组件开启视频透视功能

## 透视设置

1. 场景中添加 `XROrigin` 对象后，将 `AR Camera Manager` 组件添加到 `Camera` 组件对象中
2. 选择 `Camera` 组件 将 `Environment` 中 `Background Type` 设置为 `Clear Flags`
3. 设置 `Background` 为 **RGBA (0000) / Hexadecimal 000000。**
4. `HDR Rendering` 设置为 **off**

    <img src="./Image/Camera.png" alt="Camera" style="width: 50%;">
