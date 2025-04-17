namespace YVR.Core.Editor.Packing
{
    public abstract class ManifestElementInfoProvider
    {
        public abstract string manifestElementName { get; }
        public abstract void HandleManifestElementInfo();
    }
}