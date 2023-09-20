using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AdditiveLoader
{
#if UNITY_EDITOR
    [SerializeField] SceneAsset asset;
    [SerializeField, Tooltip("if false add scene to build settings")] bool working;
    private void OnValidate()
    {
        int sceneToLoad = SceneUtility.GetBuildIndexByScenePath(AssetDatabase.GetAssetPath(asset));
        working = (sceneToLoad != -1);
    }
#endif
    [SerializeField, HideInInspector] string sceneToLoad;

    public AsyncOperation AddScene()
    {
        return SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
    }

    public AsyncOperation RemoveScene()
    {
        return SceneManager.UnloadSceneAsync(sceneToLoad, UnloadSceneOptions.None);
    }
}
