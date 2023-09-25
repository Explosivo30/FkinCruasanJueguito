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
        Debug.Log("Awaking", this);
        foreach(var musica in musicaConCrossfades)
        {
            Debug.Log("Eliminando", musica);
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
            Debug.Log("subiendoSonido: " + musicaSource.volume, this);
            musicaSource.volume += Time.unscaledDeltaTime/time;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MusicDown(float time)
    {
        time *= musicaSource.volume;
        while (musicaSource.volume >= 0.01f)
        {
            Debug.Log("bajandoSonido: " + musicaSource.volume, this);
            musicaSource.volume -= Time.unscaledDeltaTime / time;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
