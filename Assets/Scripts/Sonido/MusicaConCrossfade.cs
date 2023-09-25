using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaConCrossfade : MonoBehaviour
{
    public static List<MusicaConCrossfade> musicaConCrossfades = new List<MusicaConCrossfade>();

    [SerializeField] AudioSource musicaSource;

    [SerializeField] float crossTime = 1f;

    private void Awake()
    {
        foreach(var musica in musicaConCrossfades)
        {
            musica.StartCoroutine(MusicDown(crossTime));
        }
        musicaConCrossfades.Clear();
        musicaConCrossfades.Add(this);
        StartCoroutine(MusicUp(crossTime));
    }

    IEnumerator MusicUp(float time)
    {
        musicaSource.volume = 0f;
        for (float volume = 0f; volume <= 1f; volume += Time.unscaledDeltaTime * time)
        {
            musicaSource.volume = Mathf.Clamp01(volume);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MusicDown(float time)
    {
        time *= musicaSource.volume;
        for (float volume = musicaSource.volume; volume >= 0f; volume -= Time.unscaledDeltaTime * time)
        {
            musicaSource.volume = Mathf.Clamp01(volume);
            yield return new WaitForEndOfFrame();
        }
    }
}
