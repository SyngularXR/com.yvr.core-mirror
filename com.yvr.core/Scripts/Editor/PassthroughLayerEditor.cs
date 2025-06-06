using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YVR.Core;
using Object = UnityEngine.Object;

[CustomEditor(typeof(PassthroughLayer))]
public class PassthroughLayerEditor : Editor
{
    internal static readonly string[] ColorMapNames =
    {
        "None",
        "ColorLut",
    };

    internal static readonly string[] SelectableColorMapNames =
    {
        ColorMapNames[0],
        ColorMapNames[1],
    };

    internal static readonly PassthroughColorMapType[] ColorMapTypes =
    {
        PassthroughColorMapType.None,
        PassthroughColorMapType.ColorLut,
    };

    private SerializedProperty m_PropColorLutSourceTexture;
    private SerializedProperty m_PropLutWeight;
    private SerializedProperty m_PropFlipLutY;

    void OnEnable()
    {
        m_PropColorLutSourceTexture = serializedObject.FindProperty("m_ColorLutSourceTexture");
        m_PropLutWeight = serializedObject.FindProperty("m_LutWeight");
        m_PropFlipLutY = serializedObject.FindProperty("m_FlipLutY");
    }

    public override void OnInspectorGUI()
    {
        PassthroughLayer layer = (PassthroughLayer)target;

        serializedObject.Update();

        EditorGUILayout.Space();

        if (serializedObject.ApplyModifiedProperties())
        {
            layer.SetStyleDirty();
        }

        EditorGUILayout.Space();

        // Custom popup for color map type to control order, names, and visibility of types
        int colorMapTypeIndex = Array.IndexOf(ColorMapTypes, layer.colorMapType);
        if (colorMapTypeIndex == -1)
        {
            Debug.LogWarning("Invalid color map type encountered");
            colorMapTypeIndex = 0;
        }

        // Dropdown list contains "Custom" only if it is currently selected.
        string[] colorMapNames = SelectableColorMapNames;
        GUIContent[] colorMapLabels = new GUIContent[colorMapNames.Length];
        for (int i = 0; i < colorMapNames.Length; i++)
            colorMapLabels[i] = new GUIContent(colorMapNames[i]);
        bool modified = false;
        SetupPopupField(target,
            new GUIContent("Color Control", "The type of color controls applied to this layer"),
            ref colorMapTypeIndex,
            colorMapLabels,
            ref modified);
        layer.colorMapType = ColorMapTypes[colorMapTypeIndex];

        if (layer.colorMapType == PassthroughColorMapType.ColorLut)
        {
            var sourceLutLabel = layer.colorMapType == PassthroughColorMapType.ColorLut
                ? "LUT"
                : "Source LUT";
            EditorGUILayout.PropertyField(m_PropColorLutSourceTexture, new GUIContent(sourceLutLabel));
            PerformLutTextureCheck((Texture2D)m_PropColorLutSourceTexture.objectReferenceValue);

            var flipLutYTooltip = "Flip LUT textures along the vertical axis on load. This is needed for LUT " +
                                  "images which have color (0, 0, 0) in the top-left corner. Some color grading systems, " +
                                  "e.g. Unity post-processing, have color (0, 0, 0) in the bottom-left corner, " +
                                  "in which case flipping is not needed.";
            EditorGUILayout.PropertyField(m_PropFlipLutY, new GUIContent("Flip Vertically", flipLutYTooltip));

            var weightTooltip = layer.colorMapType == PassthroughColorMapType.ColorLut
                ? "Blend between the original colors and the specified LUT. A value of 0 leaves the colors unchanged, a value of 1 fully applies the LUT."
                : "Blend between the source and the target LUT. A value of 0 fully applies the source LUT and a value of 1 fully applies the target LUT.";
            EditorGUILayout.PropertyField(m_PropLutWeight, new GUIContent("Blend", weightTooltip));
        }

        serializedObject.ApplyModifiedProperties();
    }

    internal static void PerformLutTextureCheck(Texture2D texture)
    {
        if (texture != null)
        {
            if (!PassthroughColorLut.IsTextureSupported(texture, out var message))
            {
                EditorGUILayout.HelpBox(message, MessageType.Error);
            }

            CheckLutImportSettings(texture);
        }
    }

    private static void CheckLutImportSettings(Texture lut)
    {
        if (lut != null)
        {
            var importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(lut)) as TextureImporter;

            // Fails when using an internal texture as you can't change import settings on
            // builtin resources, thus the check for null
            if (importer != null)
            {
                bool isReadable = importer.isReadable == true;
                bool isUncompressed = importer.textureCompression == TextureImporterCompression.Uncompressed;
                bool valid = isReadable && isUncompressed;

                if (!valid)
                {
                    string warningMessage = ""
                                            + (isReadable ? "" : "Texture is not readable. ")
                                            + (isUncompressed ? "" : "Texture is compressed.");
                    DrawFixMeBox(warningMessage, () => SetLutImportSettings(importer));
                }
            }
        }
    }

    private static void SetLutImportSettings(TextureImporter importer)
    {
        importer.isReadable = true;
        importer.textureCompression = TextureImporterCompression.Uncompressed;
        importer.SaveAndReimport();
        AssetDatabase.Refresh();
    }

    private static void DrawFixMeBox(string text, Action action)
    {
        EditorGUILayout.HelpBox(text, MessageType.Warning);

        GUILayout.Space(-32);
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Fix", GUILayout.Width(60)))
                action();

            GUILayout.Space(8);
        }

        GUILayout.Space(11);
    }

    public static void SetupPopupField(Object target, GUIContent name, ref int selectedIndex, GUIContent[] options,
        ref bool modified)
    {
        EditorGUI.BeginChangeCheck();
        var value = EditorGUILayout.Popup(name, selectedIndex, options);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed " + name.text);
            selectedIndex = value;
            modified = true;
        }
    }
}