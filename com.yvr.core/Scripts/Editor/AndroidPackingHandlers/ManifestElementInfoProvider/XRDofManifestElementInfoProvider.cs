using UnityEditor;
using YVR.Core.XR;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class XRDofManifestElementInfoProvider : ManifestElementInfoProvider
    {
        private static XRDofManifestElementInfoProvider s_Instance = null;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new XRDofManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        private XRDofManifestElementInfoProvider()
        {
            ManifestTagInfo existInfo = AndroidManifestHandler.GetManifestTagInfo(manifestElementName);
            YVRXRSettings.instance.require6Dof = existInfo is {attrs: not null} && existInfo.attrValue.Length >= 4
                && existInfo.attrs[3].Equals("true");
        }

        public sealed override string manifestElementName => "android.hardware.vr.headtracking";

        public override void HandleManifestElementInfo()
        {
            bool is6Dof = YVRXRSettings.instance.require6Dof;

            var info = new ManifestTagInfo("/manifest", "uses-feature", "name", manifestElementName,
                                           new[] {"version", "1", "required", is6Dof ? "true" : "false"});

            AndroidManifestHandler.UpdateManifestElement(manifestElementName, info);
        }
    }
}