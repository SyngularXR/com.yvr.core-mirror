using System.Linq;
using System.Threading;
using UnityEditor;
using UnityEditor.Android;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using YVR.Utilities;

namespace YVR.Core.XR
{
    public class PackagesVersionManifestTagHandler : IPostGenerateGradleAndroidProject
    {
        private void GeneratePackageListMetaInfo()
        {
            ListRequest listRequest = Client.List(true, true);
            int waitCount = 0;
            while (listRequest.Status != StatusCode.Success && waitCount < 10)
            {
                waitCount++;
                Thread.Sleep(1000);
            }

            if (listRequest.Status != StatusCode.Success) return;

            var yvrPackagesInfo = listRequest.Result.Where(item => item.name.Contains("com.yvr"))
                                             .Select(item => string.Format("Unity_{0}_{1}",
                                                                           item.name.Substring("com.yvr.".Length),
                                                                           item.version)).ToArray();
            string packageInfoStr = string.Join("|", yvrPackagesInfo);

            ManifestTagInfo manifestTagInfo = YVRAndroidManifestHandler.GetOrCreateManifestTagInfo("yvr.sdk.version",
             CreateYVRPackageVersionInfo, packageInfoStr);
            manifestTagInfo.attrs = new[] {"value", packageInfoStr};

            EditorUtility.SetDirty(YVRAndroidManifestHandler.asset);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private ManifestTagInfo CreateYVRPackageVersionInfo(string packageInfoStr)
        {
            return new ManifestTagInfo()
            {
                nodePath = "/manifest/application",
                tag = "meta-data",
                attrName = "name",
                attrValue = "yvr.sdk.version",
                attrs = new[] {"value", packageInfoStr},
                required = true,
                modifyIfFound = true
            };
        }

        public int callbackOrder => 2000;

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            GeneratePackageListMetaInfo();
        }
    }
}