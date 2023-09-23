using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomPropertyDrawer(typeof(AdditiveLoader))]
public class AdditiveLoaderDrawer : PropertyDrawer
{
    bool foldout = false;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var workingProperty = property.FindPropertyRelative("working");
        var asset = property.FindPropertyRelative("asset");
        var sceneToLoadProperty = property.FindPropertyRelative("sceneToLoad");
        if(asset.objectReferenceValue != null)
        {
            int sceneToLoad = SceneUtility.GetBuildIndexByScenePath(AssetDatabase.GetAssetPath(asset.objectReferenceValue));
            workingProperty.boolValue = (sceneToLoad != -1);
            sceneToLoadProperty.stringValue = asset.objectReferenceValue.name;
        }
        else
        {
            workingProperty.boolValue = false;
            sceneToLoadProperty.stringValue = "";
        }
        
        
        
        foldout = EditorGUILayout.BeginFoldoutHeaderGroup(foldout, label);
        if (foldout)
        {   
            EditorGUI.indentLevel++;
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(asset);
            EditorGUILayout.PropertyField(workingProperty);
            EditorGUI.indentLevel--;
            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        property.serializedObject.ApplyModifiedProperties();
    }
}
