using DG.Tweening;
using Hedenrag.ExVar;
using Hedenrag.SceneLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Edificio", menuName = "Scriptable Objects/Robbery Game/new Edificio")]
public class Edificio : ScriptableObject
{
    [SerializeField] AdditiveLoader loader;
    [SerializeField] GameObject roomPrefab;
    public float maximoRuido;

    static Optional<Scene> loadedRoomScene = new Optional<Scene>(default, false);

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
        yield return new WaitForEndOfFrame();
        imageTransitioned = false;
        loadedRoomScene = new(EdificioDecorations.CreateDecorations(roomPrefab).scene, true);
        Debug.Log("loaded scene" + loadedRoomScene.Value.name);
        BlackScreenLoader.FadeToInvisible(() => { imageTransitioned = true; });
        while (!imageTransitioned)
        {
            yield return new WaitForEndOfFrame();
        }
        onFinishLoading?.Invoke();
    }

    public static void UnloadScene(MonoBehaviour caller, Action onFinishAction)
    {
        if (loadedRoomScene)
            caller.StartCoroutine(UnloadSceneAsync(onFinishAction));
        else
            Debug.Log("this edificio was not loaded");
    }

    static IEnumerator UnloadSceneAsync(Action onFinishAction)
    {
        bool imageTransitioned = false;
        BlackScreenLoader.FadeToBlack(() => { imageTransitioned = true; });

        while (!imageTransitioned)
        {
            yield return new WaitForEndOfFrame();
        }

        CityObject.ActivateCity();
        imageTransitioned = false;
        AsyncOperation operation = SceneManager.UnloadSceneAsync(loadedRoomScene.Value);
        BlackScreenLoader.FadeToInvisible(() => { imageTransitioned = true; });

        while(!operation.isDone && !imageTransitioned)
        {
            yield return new WaitForEndOfFrame();
        }
        onFinishAction?.Invoke();
    }
}
