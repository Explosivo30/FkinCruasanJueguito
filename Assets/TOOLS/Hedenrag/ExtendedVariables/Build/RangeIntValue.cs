using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hedenrag
{
    namespace ExVar
    {
        [Serializable]
        public struct RangeIntValue
        {
            [SerializeField] int currentVal;

            [SerializeField] int minVal;
            [SerializeField] int maxVal;

            public int value => currentVal;
            public int possibleValue => UnityEngine.Random.Range(minVal, maxVal);

            public void RecalculateValue()
            {
                currentVal = possibleValue;
            }


            public RangeIntValue(int minVal = 0, int maxVal = 1)
            {
                this.minVal = minVal;
                this.maxVal = maxVal;

                currentVal = UnityEngine.Random.Range(minVal, maxVal);
            }

            public RangeIntValue(RangeIntValue rangeIntValue)
            {
                currentVal = rangeIntValue.value;
                minVal = rangeIntValue.minVal;
                maxVal = rangeIntValue.maxVal;
            }
        }
    }
}