using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdificioDecorations : MonoBehaviour
{
    static EdificioDecorations instance;

    [SerializeField] Transform edificioCenter;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameObject CreateDecorations(GameObject prefab)
    {
        return Instantiate(prefab, instance.edificioCenter);
    }
}
