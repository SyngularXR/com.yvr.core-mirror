using UnityEditor;
using UnityEngine;
using System.IO;

namespace YVR.Core.ImageTracking.EditorTools
{
    public static class ToTrackImageListDrawer
    {
        public static void DrawList(SerializedObject so, SerializedProperty listProp)
        {
            so.Update();

            for (int i = 0; i < listProp.arraySize; i++)
            {
                EditorGUILayout.BeginVertical("box");
                SerializedProperty element = listProp.GetArrayElementAtIndex(i);
                SerializedProperty imageProp = element.FindPropertyRelative("image");
                SerializedProperty imageFilePathProp = element.FindPropertyRelative("imageFilePath");

                EditorGUI.BeginChangeCheck();

                SerializedProperty imageIdProp = element.FindPropertyRelative("imageId");
                string imageId = imageIdProp != null ? imageIdProp.stringValue : "";
                EditorGUILayout.PropertyField(element, new GUIContent($"{imageId}"), true);

                if (EditorGUI.EndChangeCheck())
                {
                    if (imageProp.objectReferenceValue != null)
                    {
                        string path = AssetDatabase.GetAssetPath(imageProp.objectReferenceValue);
                        imageFilePathProp.stringValue = $"it_{Path.GetFileName(path)}";
                    }
                }

                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("-", GUILayout.Width(22), GUILayout.Height(18)))
                {
                    listProp.DeleteArrayElementAtIndex(i);
                    so.ApplyModifiedProperties();
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.EndVertical();
                    break;
                }

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }

            if (GUILayout.Button("Add new image"))
            {
                listProp.InsertArrayElementAtIndex(listProp.arraySize);
            }

            so.ApplyModifiedProperties();

            if (!GUI.changed) return;
            EditorUtility.SetDirty(so.targetObject);
            AssetDatabase.SaveAssets();
        }
    }
}