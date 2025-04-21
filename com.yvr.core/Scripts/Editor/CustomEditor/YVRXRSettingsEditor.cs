using System.IO;
using UnityEditor;
using UnityEngine;
using YVR.Core;
using YVR.Core.Editor.Packing;
using YVR.Core.XR;

// Notes: Unity XR Management doest not support UIToolkit for custom editor

[CustomEditor(typeof(YVRXRSettings))]
public class YVRXRSettingsEditor : Editor
{
    public void OnValidate()
    {
        var settings = (YVRXRSettings) target;

        if (settings.OSSplashScreen != null)
        {
            string path = AssetDatabase.GetAssetPath(settings.OSSplashScreen);
            if (Path.GetExtension(path).ToLower() != ".png")
            {
                settings.OSSplashScreen = null;
                Debug.LogError("system splash screen file is not PNG format: " + path);
            }
        }

        AndroidManifestHandler.RefreshManifestElementInfo();
    }

    public override void OnInspectorGUI()
    {
        var settings = (YVRXRSettings) target;

        settings.use16BitDepthBuffer = EditorGUILayout.Toggle("Use 16-bit Depth Buffer", settings.use16BitDepthBuffer);
        settings.useMonoscopic = EditorGUILayout.Toggle("Use Monoscopic", settings.useMonoscopic);
        settings.optimizeBufferDiscards
            = EditorGUILayout.Toggle("Optimize Buffer Discards", settings.optimizeBufferDiscards);
        settings.useAppSW = EditorGUILayout.Toggle("Use AppSW", settings.useAppSW);


        RenderStereoRenderingSettings(settings);

        settings.passthroughProvider = EditorGUILayout.Toggle("Passthrough Provider", settings.passthroughProvider);
        settings.autoResolve = EditorGUILayout.Toggle("Auto Resolve", settings.autoResolve);

        settings.isP3 = EditorGUILayout.Toggle("Is P3 Color Space", settings.isP3);

        RenderFeatureRequestSettings(settings);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(settings);
            OnValidate();
        }
    }


    private void RenderStereoRenderingSettings(YVRXRSettings settings)
    {
        settings.extraRenderPass = EditorGUILayout.Toggle("Extra Render Pass", settings.extraRenderPass);
        if (settings.extraRenderPass)
        {
            settings.extraRenderPassDepth
                = EditorGUILayout.IntField("Extra Render Pass Depth", settings.extraRenderPassDepth);
        }

        settings.stereoRenderingMode
            = (StereoRenderingMode) EditorGUILayout.EnumPopup("Stereo Rendering Mode", settings.stereoRenderingMode);

        if (settings.stereoRenderingMode == StereoRenderingMode.QuadViews)
        {
            EditorGUI.indentLevel++;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("QuadViews Settings", EditorStyles.boldLabel);
            settings.outerPassRenderScale
                = EditorGUILayout.FloatField("Outer Pass Render Scale", settings.outerPassRenderScale);
            settings.innerPassRenderScale
                = EditorGUILayout.FloatField("Inner Pass Render Scale", settings.innerPassRenderScale);

            if (settings.extraRenderPass)
            {
                settings.outerExtraPassRenderScale
                    = EditorGUILayout.FloatField("Outer Extra Pass Render Scale", settings.outerExtraPassRenderScale);
                settings.innerExtraPassRenderScale
                    = EditorGUILayout.FloatField("Inner Extra Pass Render Scale", settings.innerExtraPassRenderScale);
            }

            EditorGUILayout.Space();
            EditorGUI.indentLevel--;
        }
    }

    private void RenderFeatureRequestSettings(YVRXRSettings settings)
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Feature Request", EditorStyles.boldLabel);

        EditorGUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("OS Splash Screen", GUILayout.Width(EditorGUIUtility.labelWidth - 4));
        settings.OSSplashScreen
            = (Texture2D) EditorGUILayout.ObjectField(settings.OSSplashScreen, typeof(Texture2D), false);
        GUILayout.EndHorizontal();

        settings.require6Dof = EditorGUILayout.Toggle("Require 6DoF", settings.require6Dof);
        settings.handTrackingSupport = (HandTrackingSupport) EditorGUILayout.EnumPopup("Hand Tracking Support",
             settings.handTrackingSupport);
        settings.eyeTrackingSupport = (YVRFeatureSupport) EditorGUILayout.EnumPopup("Eye Tracking Support",
             settings.eyeTrackingSupport);
        if (settings.requireSceneAnchor)
        {
            settings.requireSpatialAnchor = true;
            GUI.enabled = false;
        }

        settings.requireSpatialAnchor = EditorGUILayout.Toggle("Require Spatial Anchor", settings.requireSpatialAnchor);
        GUI.enabled = true;
        settings.requireSceneAnchor = EditorGUILayout.Toggle("Require Scene Anchor", settings.requireSceneAnchor);
        settings.LBESupport = EditorGUILayout.Toggle("LBE Support", settings.LBESupport);

        EditorGUILayout.EndVertical();
    }
}