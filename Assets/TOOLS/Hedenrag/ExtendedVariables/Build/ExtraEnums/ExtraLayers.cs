using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hedenrag
{
    namespace ExVar
    {
        [System.Serializable]
        public struct ExtraLayers : ISerializationCallbackReceiver
        {
            [SerializeField, HideInInspector] ExLayer layer;
            [SerializeField, HideInInspector] int value;
            public int Value => value;

            void OnValidate() { }
            void ISerializationCallbackReceiver.OnBeforeSerialize() => OnValidate();
            void ISerializationCallbackReceiver.OnAfterDeserialize() { }

            public ExtraLayers(ExLayer layer, int val)
            {
                this.layer = layer;
                value = val;
            }

            public bool GetLayer(int index)
            {
                return (value & (1 << index)) != 0;
            }
            public void SetLayer(int index, bool val)
            {
                value |= (1 << index);
            }

            public bool this[int index]
            {
                get => GetLayer(index);
                set => SetLayer(index, value);
            }

            public static ExtraLayers operator &(ExtraLayers a, ExtraLayers b)
            {
                return new ExtraLayers(a.layer, a.value & b.value);
            }
            public static ExtraLayers operator |(ExtraLayers a, ExtraLayers b)
            {
                return new ExtraLayers(a.layer, a.value | b.value);
            }

            public static ExtraLayers operator +(ExtraLayers a, ExtraLayers b)
            {
                return new ExtraLayers(a.layer, a.value | b.value);
            }
            public static ExtraLayers operator -(ExtraLayers a, ExtraLayers b)
            {
                return new ExtraLayers(a.layer, a.value & (~b.value));
            }

            public static ExtraLayers operator +(ExtraLayers a, ExtraLayer val)
            {
                return new ExtraLayers(a.layer, a.value | val.Value);
            }
            public static ExtraLayers operator -(ExtraLayers a, ExtraLayer val)
            {
                return new ExtraLayers(a.layer, a.value & (~val.Value));
            }

            public bool Contains(ExtraLayer val)
            {
                int res = val.Value & value;
                return res != 0;
            }
        }
    }
}