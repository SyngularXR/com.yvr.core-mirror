namespace YVR.Core
{
    public interface ILayerShapeHandler
    {
        public void HandleLayerPose(IYVRLayerHandle layerHandle, params object[] data);

        public void HandleLayerShape(IYVRLayerHandle layerHandle, params object[] data);
    }
}