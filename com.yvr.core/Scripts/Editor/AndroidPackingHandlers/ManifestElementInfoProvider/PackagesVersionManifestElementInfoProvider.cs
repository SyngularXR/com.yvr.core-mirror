using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
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

            ListRequest listRequest = Client.List(true, true);
            Task.Run(() =>
            {
                int waitCount = 0;
                while (listRequest.Status != StatusCode.Success && waitCount < 10)
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    waitCount++;
                    Thread.Sleep(1000);
                }

                if (listRequest.Status != StatusCode.Success) return;

                string[] yvrPackagesInfo = listRequest.Result.Where(item => item.name.Contains("com.yvr"))
                                                      .Select(item =>
                                                                  $"Unity_{item.name["com.yvr.".Length..]}_{item.version}")
                                                      .ToArray();
                string packageInfoStr = string.Join("|", yvrPackagesInfo);

                var info = new ManifestTagInfo("/manifest/application", "meta-data", "name", manifestElementName,
                                               new[] {"value", packageInfoStr});

                AndroidManifestHandler.UpdateManifestElement(manifestElementName, info);
            }, cancellationToken);
        }
    }
}