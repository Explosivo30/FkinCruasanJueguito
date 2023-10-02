using Hedenrag.SceneLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenFullTransition : MonoBehaviour
{
    [SerializeField] SceneLoaderAsync _sceneLoader;
    public void MakeTransition()
    {
        DontDestroyOnLoad(_sceneLoader);
        Time.timeScale = 0f;
        BlackScreenLoader.FadeToBlack(() => { _sceneLoader.LoadScene(() => { BlackScreenLoader.FadeToInvisible(() => { Time.timeScale = 1f; Destroy(_sceneLoader); }); }); });
    }
}
