using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace Hedenrag
{
    namespace ExVar
    {
        public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
        {
            private static T instance;
            public static T Instance
            {
                get
                {
                    if (instance == null)
                    {
                        T[] assets = Resources.LoadAll<T>("");
                        if (assets == null || assets.Length < 1)
                        {
#if UNITY_EDITOR
                            GenerateSingletons();
                            assets = Resources.LoadAll<T>("");
                            if (assets == null || assets.Length < 1)
                            {
                                throw new System.Exception("could not generate automaticaly singleton");
                            }
#else
                    throw new System.Exception("Could not find any singleton scriptable object instances in the resources!");
#endif
                        }
                        else if (assets.Length > 1)
                        {
                            Debug.LogWarning(assets.Length + " instances of the singleton scriptable object found in cesources, using this", assets[0]);
                            instance = assets[0];
                        }
                    }
                    return instance;
                }
            }

#if UNITY_EDITOR
            public static void GenerateSingletons()
            {
                string path = "Assets/Resources/Singletons/";

                Debug.Log(typeof(T));

                if (instance != null) { return; }

                if (typeof(T).IsSubclassOf(typeof(SingletonScriptableObject<T>)))
                {
                    var a = ScriptableObject.CreateInstance<T>();

                    AssetDatabase.CreateAsset(a, path + typeof(T).Name + ".asset");
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    EditorUtility.FocusProjectWindow();
                    Selection.activeObject = a;
                }
            }
#endif
        }
    }
}