using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Music -----------")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("----------- Clips -----------")]
    public AudioClip musicClip;

    public void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}

