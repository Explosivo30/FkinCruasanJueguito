using Hedenrag.SceneLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneLoaderAsync))]
public class BlackScreenFullTransition : MonoBehaviour
{
    [SerializeField] SceneLoaderAsync _sceneLoader;
    public void MakeTransition()
    {
        DontDestroyOnLoad(_sceneLoader);
        BlackScreenLoader.FadeToBlack(() => { _sceneLoader.LoadScene(() => { BlackScreenLoader.FadeToInvisible(() => { Destroy(_sceneLoader); }); }); });
    }
}
