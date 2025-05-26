using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YVR.Core.ImageTracking;
using YVR.Core.ImageTracking.EditorTools;

[CustomEditor(typeof(ToTrackImagesCollectionSO))]
public class ToTrackImagesCollectionSOEditor : Editor
{

    private SerializedProperty m_ToTrackImagesProp;

    private void OnEnable() { m_ToTrackImagesProp = serializedObject.FindProperty("toTrackImages"); }


    public override void OnInspectorGUI()
    {
        ToTrackImageListDrawer.DrawList(serializedObject, m_ToTrackImagesProp);
    }
}