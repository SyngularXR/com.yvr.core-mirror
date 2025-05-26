using UnityEditor;
using UnityEngine;
using YVR.Core.ImageTracking;
using YVR.Core.ImageTracking.EditorTools;

[CustomEditor(typeof(ImageTrackingMgr))]
public class ImageTrackingMgrEditor : Editor
{
    private SerializedObject m_SOCollection;
    private SerializedProperty m_ToTrackImagesProp;

    private void OnEnable()
    {
        var collection = ToTrackImagesCollectionSO.instance;
        if (collection == null)
        {
            Debug.LogError("Can not find ToTrackImagesCollectionSO instance.");
            return;
        }

        m_SOCollection = new SerializedObject(collection);
        m_ToTrackImagesProp = m_SOCollection.FindProperty("toTrackImages");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("To Track Image Info", EditorStyles.boldLabel);

        if (m_SOCollection == null || m_ToTrackImagesProp == null)
        {
            EditorGUILayout.HelpBox("There is no to track image info.", MessageType.Warning);
            return;
        }

        ToTrackImageListDrawer.DrawList(m_SOCollection, m_ToTrackImagesProp);
    }
}