using Hedenrag.SceneLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Edificio", menuName = "Scriptable Objects/Robbery Game/new Edificio")]
public class Edificio : ScriptableObject
{
    [SerializeField] AdditiveLoader loader;
    [SerializeField] GameObject roomPrefab;
    public void LoadScene(MonoBehaviour caller, Action onFinishLoading)
    {
        caller.StartCoroutine(LoadingScene(onFinishLoading));
    }

    IEnumerator LoadingScene(Action onFinishLoading)
    {
        AsyncOperation operation = loader.AddScene();
        operation.allowSceneActivation = false;

        bool imageTransitioned = false;
        BlackScreenLoader.FadeToBlack(() => { imageTransitioned = true; });       

        while (!imageTransitioned)
        {
            yield return new WaitForEndOfFrame();
        }
        CityObject.DeactivateCity();
        operation.allowSceneActivation = true;
        while (!operation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        imageTransitioned = false;
        BlackScreenLoader.FadeToInvisible(() => { imageTransitioned = true; });
        while (!imageTransitioned)
        {
            yield return new WaitForEndOfFrame();
        }
        onFinishLoading?.Invoke();
    }


}
