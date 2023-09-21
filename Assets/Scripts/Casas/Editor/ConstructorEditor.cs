using Hedenrag.ExVar;
using Hedenrag.FnH;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Constructor;

[CustomPropertyDrawer(typeof(MuebleEstructura))]
public class ConstructorEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        

        var muebleProperty = property.FindPropertyRelative("mueble");
        var mueblesGrandeProperty = property.FindPropertyRelative("subMueblesGrandes");
        var mueblesPequeñoProperty = property.FindPropertyRelative("subMueblesPequeños");

        GameMueble target = (GameMueble)muebleProperty.boxedValue;

        EditorGUILayout.LabelField(target.gameObject.name);
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(muebleProperty);
        bool changedMueble = EditorGUI.EndChangeCheck();
        

        if (changedMueble)
        {
            mueblesGrandeProperty.ClearArray();
            mueblesPequeñoProperty.ClearArray();
            mueblesGrandeProperty.arraySize = target.EspacioGrande.Length;
            mueblesPequeñoProperty.arraySize = target.EspacioPequeño.Length;
        }

        EditorGUILayout.BeginFadeGroup(0.2f);
        EditorGUILayout.LabelField("Muebles Grandes");
        for (int i = 0; i<mueblesGrandeProperty.arraySize; i++)
        {
            EditorGUILayout.PropertyField(mueblesGrandeProperty.GetArrayElementAtIndex(i));
        }
        EditorGUILayout.EndFadeGroup();
        EditorGUILayout.BeginFadeGroup(0.2f);
        EditorGUILayout.LabelField("Muebles Pequeños");
        for (int i = 0; i < mueblesPequeñoProperty.arraySize; i++)
        {
            EditorGUILayout.PropertyField(mueblesPequeñoProperty.GetArrayElementAtIndex(i));
        }
        EditorGUILayout.EndFadeGroup();
    }
}
