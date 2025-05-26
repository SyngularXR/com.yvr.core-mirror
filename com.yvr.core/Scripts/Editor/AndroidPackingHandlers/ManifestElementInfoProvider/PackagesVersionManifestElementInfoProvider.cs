using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    public class PackagesVersionManifestElementInfoProvider : ManifestElementInfoProvider
    {
        private static PackagesVersionManifestElementInfoProvider s_Instance;

        private static CancellationTokenSource s_CancellationTokenSource;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            s_Instance ??= new PackagesVersionManifestElementInfoProvider();
            AndroidManifestHandler.manifestElementInfoProviders.Add(s_Instance);
        }

        public override string manifestElementName => "yvr.sdk.version";

        public override void HandleManifestElementInfo()
        {
            s_CancellationTokenSource?.Cancel();
            s_CancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = s_CancellationTokenSource.Token;

            ListRequest listRequest = Client.List(false, false);

            EditorApplication.update += OnUpdate;
            
            void OnUpdate()
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    EditorApplication.update -= OnUpdate;
                    return;
                }

                if (listRequest.IsCompleted)
                {
                    EditorApplication.update -= OnUpdate;

                    if (listRequest.Status == StatusCode.Success)
                        ProcessPackageInfo(listRequest.Result);
                }
            }
        }
        private void ProcessPackageInfo(PackageCollection packages)
        {
            string[] yvrPackagesInfo = packages
                                      .Where(item => item.name.Contains("com.yvr"))
                                      .Select(item => $"Unity_{item.name["com.yvr.".Length..]}_{item.version}")
                                      .ToArray();

            string packageInfoStr = string.Join("|", yvrPackagesInfo);
            var info = new ManifestTagInfo("/manifest/application", "meta-data", "name", manifestElementName,
                                           new[] { "value", packageInfoStr });
            AndroidManifestHandler.UpdateManifestElement(manifestElementName, info);
        }
    }
}