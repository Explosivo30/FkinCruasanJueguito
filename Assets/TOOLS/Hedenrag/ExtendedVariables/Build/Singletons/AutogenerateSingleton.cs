using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Hedenrag
{
    namespace ExVar
    {
        interface AutogenerateSingleton<T> where T : SingletonScriptableObject<T>
        {
            protected static T instance;

            public static T Instance;


        }
#if UNITY_EDITOR
        public class GenerateSingletons
        {
            public static void Generate()
            {
                // Get all types in the current assembly that implement IMyInterface
                var types = Assembly.GetExecutingAssembly()
                                    .GetTypes()
                                    .Where(type => typeof(AutogenerateSingleton<>).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                                    .ToList();


                // Call the static function on each class that implements IMyInterface
                foreach (var type in types)
                {
                    Debug.Log(type);
                    var staticMethod = type.GetMethod("GenerateSingletons", BindingFlags.Public | BindingFlags.Static);
                    if (staticMethod != null)
                    {
                        staticMethod.Invoke(null, null);
                    }
                }
            }
        }
#endif
    }
}