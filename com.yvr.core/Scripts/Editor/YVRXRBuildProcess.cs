using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.XR.Management;
using UnityEngine;
using UnityEngine.XR.Management;

namespace YVR.Core.XR
{
    public class YVRXRBuildProcess : XRBuildHelper<YVRXRSettings>
    {
        public override string BuildSettingsKey
        {
            get { return "YVR.Core.XR.YVRXRSettings"; }
        }

        private bool IsCurrentBuildTargetVaild(BuildReport report)
        {
            return report.summary.platformGroup == BuildTargetGroup.Android;
        }

        private bool HasLoaderEnabledForTarget(BuildTargetGroup buildTargetGroup)
        {
            if (buildTargetGroup != BuildTargetGroup.Android)
                return false;

            XRGeneralSettings settings = XRGeneralSettingsPerBuildTarget.XRGeneralSettingsForBuildTarget(buildTargetGroup);
            if (settings == null)
                return false;

            bool loaderFound = false;
            for (int i = 0; i < settings.Manager.activeLoaders.Count; ++i)
            {
                if (settings.Manager.activeLoaders[i] as YVRXRLoader != null)
                {
                    loaderFound = true;
                    break;
                }
            }

            return loaderFound;
        }

        private readonly string[] packageNames = new string[]
        {
            "com.yvr.core",
            "com.yvr.utilities"
        };

        private bool ShouldIncludeRuntimePluginsInBuild(string path, BuildTargetGroup platformGroup)
        {
            return HasLoaderEnabledForTarget(platformGroup);
        }

        /// <summary>OnPreprocessBuild override to provide XR Plugin specific build actions.</summary>
        /// <param name="report">The build report.</param>
        public override void OnPreprocessBuild(BuildReport report)
        {
            if (IsCurrentBuildTargetVaild(report) && HasLoaderEnabledForTarget(report.summary.platformGroup))
                base.OnPreprocessBuild(report);

            var allPlugins = PluginImporter.GetAllImporters();
            foreach (var plugin in allPlugins)
            {
                if (plugin.isNativePlugin)
                {
                    foreach (var pluginName in packageNames)
                    {
                        if (plugin.assetPath.Contains(pluginName))
                        {
                            plugin.SetIncludeInBuildDelegate((path) => { return ShouldIncludeRuntimePluginsInBuild(path, report.summary.platformGroup); });
                            break;
                        }
                    }
                }
            }
        }
    }
}