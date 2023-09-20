using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hedenrag
{
    namespace ExVar
    {
        public class SingletonScriptableObjectCreator : SingletonScriptableObject<SingletonScriptableObjectCreator>, ICallOnAll
        {

            [UnityEditor.MenuItem("Hedenrag/Generate Singletons")]
            static void GenerateSingletons()
            {
                GenerateAllSingletons();
            }

        }
    }
}

