using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCaller : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] float volume = 1f;
    [SerializeField] float randomvolume = 0.05f;
    [SerializeField] float pitch = 1f;
    [SerializeField] float randomPitch = 0.05f;
    [Space(10f)]
    [SerializeField] GameObject soundObject;

    public void CallSound() 
    {
        SmallSound soundEmmiter = Instantiate(soundObject).GetComponent<SmallSound>();
        soundEmmiter.source.clip = sound;
        soundEmmiter.source.volume = volume + Random.Range(-randomvolume, randomvolume);
        soundEmmiter.source.pitch = pitch + Random.Range(-randomPitch, randomPitch);
    }
}
