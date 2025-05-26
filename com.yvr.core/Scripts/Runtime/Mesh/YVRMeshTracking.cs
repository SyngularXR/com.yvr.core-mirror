using System;
using AOT;
using YVR.Utilities;

namespace YVR.Core
{
    public class YVRMeshTracking : Singleton<YVRMeshTracking>
    {
        public static Action<ulong, YVRMeshBlockChangeState> updateMeshBlockAction;

        protected override void OnInit()
        {
            YVRPlugin.Instance.SetMeshBlockUpdateCallback(SetMeshBlockUpdateCallback);
        }

        public void CreateMeshDetector()
        {
            YVRPlugin.Instance.CreateMeshDetector();
        }

        public void DestroyMeshDetector()
        {
            YVRPlugin.Instance.DestroyMeshDetector();
        }

        [MonoPInvokeCallback(typeof(Action<ulong, YVRMeshBlockChangeState>))]
        private static void SetMeshBlockUpdateCallback(ulong xrSpace, YVRMeshBlockChangeState state)
        {
            updateMeshBlockAction?.Invoke(xrSpace, state);
        }
    }
}