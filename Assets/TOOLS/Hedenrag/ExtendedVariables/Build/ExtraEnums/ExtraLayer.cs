using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hedenrag
{
    namespace ExVar
    {
        [System.Serializable]
        public struct ExtraLayer : ISerializationCallbackReceiver, IEquatable<ExtraLayer>
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
            public ExtraLayer(ExLayer layer)
            {
                this.layer = layer;
                value = 0;
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

            public override bool Equals(object obj)
            {
                return obj is ExtraLayer layer && Equals(layer);
            }

            public bool Equals(ExtraLayer other)
            {
                return EqualityComparer<ExLayer>.Default.Equals(layer, other.layer) &&
                       value == other.value &&
                       Value == other.Value;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(layer, value, Value);
            }

            public static bool operator ==(ExtraLayer left, ExtraLayer right) { return (left.layer == right.layer && left.value == right.value); }
            public static bool operator !=(ExtraLayer left, ExtraLayer right) { return !(left == right); }
        }
    }
}