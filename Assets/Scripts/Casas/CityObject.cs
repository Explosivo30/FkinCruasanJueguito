using Hedenrag.ExVar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityObject : MonoBehaviour
{
    static Optional<CityObject> instance = new Optional<CityObject>(null, false);

    GameObject city;

    private void Awake()
    {
        if (!instance)
        {
            instance = new Optional<CityObject> (this, true);

            city = gameObject;
        }
    }

    private void OnDestroy()
    {
        if (instance.Value == this) 
        {
            instance = new Optional<CityObject> (null, false);
        }
    }
}
