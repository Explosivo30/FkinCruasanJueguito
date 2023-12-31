using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hedenrag
{
    namespace FnH
    {
        public static class ReflectiveEnumerator
        {
            static ReflectiveEnumerator() { }

            public static List<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
            {
                List<T> objects = new List<T>();
                foreach (Type type in
                    Assembly.GetAssembly(typeof(T)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
                {
                    objects.Add((T)Activator.CreateInstance(type, constructorArgs));
                }
                return objects;
            }

            public static List<Type> GetDerivedTypes<T>() where T : class
            {
                List<Type> objects = new List<Type>();
                foreach(Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    objects.AddRange((List<Type>)asm.GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))));
                }
                return objects;
            }
        }
    }
}