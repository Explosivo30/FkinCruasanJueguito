using Hedenrag.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificio : ScriptableObject
{
    [SerializeField] AdditiveLoader loader;

    void LoadScene()
    {
        loader.AddScene();
    }
}
