using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaConCrossfade : MonoBehaviour
{
    public static List<MusicaConCrossfade> musicaConCrossfades = new List<MusicaConCrossfade>();

    [SerializeField] AudioSource musicaSource;

    [SerializeField, Range(0.05f,10f)] float crossTime = 1f;

    private void Awake()
    {
        foreach(var musica in musicaConCrossfades)
        {
            musica.EliminarMusica(crossTime);
        }
        musicaConCrossfades.Clear();
        DontDestroyOnLoad(gameObject);
        musicaConCrossfades.Add(this);
        StartCoroutine(MusicUp(crossTime));
    }

    public void EliminarMusica(float crossTime)
    {
        StartCoroutine(MusicDown(crossTime));
    }

    IEnumerator MusicUp(float time)
    {
        musicaSource.volume = 0f;
        while(musicaSource.volume <= 0.99f)
        {
            musicaSource.volume += Time.unscaledDeltaTime/time;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MusicDown(float time)
    {
        time *= musicaSource.volume;
        while (musicaSource.volume >= 0.01f)
        {
            musicaSource.volume -= Time.unscaledDeltaTime / time;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
