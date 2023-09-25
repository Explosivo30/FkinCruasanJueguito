using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSound : MonoBehaviour
{
    public AudioSource source;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        transform.parent = null;
        source.Play();
        StartCoroutine(WaitForSoundEnd(source.clip.length));
    }

    IEnumerator WaitForSoundEnd(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
