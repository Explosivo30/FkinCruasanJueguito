using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hedenrag
{
    namespace ExVar
    {
        [Serializable]
        public struct RangeFloatValue
        {
            [SerializeField] float currentVal;

            [SerializeField] float minVal;
            [SerializeField] float maxVal;

            public readonly float value => currentVal;
            public readonly float possibleValue => UnityEngine.Random.Range(minVal, maxVal);

            public void RecalculateValue()
            {
                currentVal = possibleValue;
            }


            public RangeFloatValue(float minVal = 0f, float maxVal = 1f)
            {
                this.minVal = minVal;
                this.maxVal = maxVal;

                currentVal = UnityEngine.Random.Range(minVal, maxVal);
                Debug.Log("Object Created");
            }
            public RangeFloatValue(RangeFloatValue rangeIntValue)
            {
                currentVal = rangeIntValue.value;
                minVal = rangeIntValue.minVal;
                maxVal = rangeIntValue.maxVal;
            }
        }
    }
}