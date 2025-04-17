using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.XR.Management;
using UnityEngine.XR.Management;

namespace YVR.Core.XR
{
    public class YVRXRBuildProcess : XRBuildHelper<YVRXRSettings>
    {
        public override string BuildSettingsKey => "YVR.Core.XR.YVRXRSettings";

        private readonly string[] m_PackageNames =
        {
            "com.yvr.core",
            "com.yvr.utilities"
        };

        public static bool isLoaderEnabled
        {
            get
            {
                bool isAndroidBuildTarget = EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android;
                XRGeneralSettings settings
                    = XRGeneralSettingsPerBuildTarget.XRGeneralSettingsForBuildTarget(BuildTargetGroup.Android);
                return isAndroidBuildTarget && settings != null &&
                       settings.Manager.activeLoaders.Any(t => t as YVRXRLoader != null);
            }
        }

        /// <summary>OnPreprocessBuild override to provide XR Plugin specific build actions.</summary>
        /// <param name="report">The build report.</param>
        public override void OnPreprocessBuild(BuildReport report)
        {
            if (isLoaderEnabled)
                base.OnPreprocessBuild(report);

            PluginImporter[] allPlugins = PluginImporter.GetAllImporters();
            foreach (PluginImporter plugin in allPlugins)
            {
                if (!plugin.isNativePlugin) continue;
                if (m_PackageNames.Any(pluginName => plugin.assetPath.Contains(pluginName)))
                {
                    plugin.SetIncludeInBuildDelegate(_ => isLoaderEnabled);
                }
            }
        }
    }
}