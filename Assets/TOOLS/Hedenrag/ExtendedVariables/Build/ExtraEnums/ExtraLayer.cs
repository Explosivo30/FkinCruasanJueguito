using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace Hedenrag
{
    namespace ExVar
    {
        [System.Serializable]
        public struct ExtraLayer : ISerializationCallbackReceiver
        {
            [SerializeField, HideInInspector] ExLayer layer;
            [SerializeField, HideInInspector] int value;

            public int Value => value;

            void OnValidate() { }
            void ISerializationCallbackReceiver.OnBeforeSerialize() => OnValidate();
            void ISerializationCallbackReceiver.OnAfterDeserialize() { }

            public ExtraLayer(ExLayer layer, int val)
            {
                this.layer = layer;
                value = val;
            }

            public ExtraLayer(ExtraLayer layer)
            {
                this.layer = layer.layer;
                this.value = layer.value;
            }

            public bool IsIn(ExtraLayers layers)
            {
                int res = layers.Value & value;
                return res != 0;
            }
        }
    }
}