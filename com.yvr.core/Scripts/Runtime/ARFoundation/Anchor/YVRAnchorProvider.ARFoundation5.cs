#if XR_ARFOUNDATION_5 || XR_ARFOUNDATION_6
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace YVR.Core.ARFoundation.Anchor
{
    public partial class YVRAnchorProvider : XRAnchorSubsystem.Provider
    {
#if XR_ARFOUNDATION_5
        private async Task<XRAnchor> CreateSpatialAnchorAsync(Pose pose)
        {
            TaskCompletionSource<XRAnchor> completionSource = new();
            XRAnchor createAnchor = default;
            m_SpatialAnchor.CreateSpatialAnchor(pose.position, pose.rotation, onCreateResult);

            void onCreateResult(YVRSpatialAnchorResult anchorResult, bool success)
            {
                if (success)
                {
                    createAnchor = CreateXRAnchor(GenerateTrackableId(anchorResult.uuid), pose,
                        anchorResult.anchorHandle, TrackingState.Tracking);
                    m_TrackableIdToHandleMap.TryAdd(createAnchor.trackableId, anchorResult.anchorHandle);
                    m_HandleToXRAnchorMap.TryAdd(anchorResult.anchorHandle, createAnchor);
                }

                completionSource.SetResult(createAnchor);
            }

            return await Task.Run(async () =>
            {
                while (true)
                {
                    YVRPlugin.Instance.PollEvent();
                    if (completionSource.Task.IsCompleted)
                        return createAnchor;

                    await Task.Delay(11);
                }
            });
        }

        public override bool TryAddAnchor(Pose pose, out XRAnchor anchor)
        {
            var tcs = new TaskCompletionSource<XRAnchor>();
            Task.Run(() =>
            {
                var anchorResult = CreateSpatialAnchorAsync(pose).Result;
                tcs.SetResult(anchorResult);
            });

            anchor = tcs.Task.Result;
            var result = anchor.nativePtr != IntPtr.Zero;
            return result;
        }

        private async Task<bool> EraseAnchorAsync(ulong handle)
        {
            TaskCompletionSource<bool> completionSource = new();
            m_SpatialAnchor.EraseSpatialAnchor(handle, YVRSpatialAnchorStorageLocation.Local,
                (result, success) => { completionSource.SetResult(success); });

            return await Task.Run(async () =>
            {
                while (true)
                {
                    YVRPlugin.Instance.PollEvent();
                    if (completionSource.Task.IsCompleted)
                        return completionSource.Task.Result;

                    await Task.Delay(11);
                }
            });
        }

        public override bool TryRemoveAnchor(TrackableId anchorId)
        {
            if (!m_TrackableIdToHandleMap.TryGetValue(anchorId, out ulong handle))
                return false;

            var completionSource = new TaskCompletionSource<bool>();

            Task.Run(() =>
            {
                var result = EraseAnchorAsync(handle).Result;
                if (result)
                {
                    m_HandleToXRAnchorMap.Remove(handle);
                    m_TrackableIdToHandleMap.Remove(anchorId);
                }

                completionSource.SetResult(result);
            });

            return completionSource.Task.Result;
        }
#endif
    }
}
#endif