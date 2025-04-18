using System.IO;
using UnityEngine.Internal;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Android;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using YVR.Utilities;
using YVR.Utilities.Editor.PackingProcessor;

namespace YVR.Core.Editor.Packing
{
    [ExcludeFromDocs]
    public class AndroidManifestHandler : IPreprocessBuildWithReport, IPostGenerateGradleAndroidProject
    {
        private static YVRSDKSettingAsset asset => YVRSDKSettingAsset.instance;

        public int callbackOrder => 9000;

        public static HashSet<ManifestElementInfoProvider> manifestElementInfoProviders = new();

        public void OnPreprocessBuild(BuildReport _) { RefreshManifestElementInfo(); }

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            string inApkManifestPath = Path.Combine(path, "src/main/AndroidManifest.xml");
            ManifestProcessor.PatchAndroidManifest(asset.manifestTagInfosList, inApkManifestPath);
        }

        public static void RefreshManifestElementInfo()
        {
            manifestElementInfoProviders.ForEach(provider => provider.HandleManifestElementInfo());
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            string projectAndroidManifestPath = "Assets/Plugins/Android/AndroidManifest.xml";
            if (File.Exists(projectAndroidManifestPath))
                ManifestProcessor.PatchAndroidManifest(asset.manifestTagInfosList, projectAndroidManifestPath);
        }

        public static void UpdateManifestElement(string attrValue, ManifestTagInfo elementInfo)
        {
            asset.manifestTagInfosList.RemoveAll(info => info.attrValue == attrValue);
            asset.manifestTagInfosList.Add(elementInfo);
        }

        public static ManifestTagInfo GetManifestTagInfo(string attrValue)
        {
            return asset.manifestTagInfosList.Find(info => info.attrValue == attrValue);
        }
    }
}