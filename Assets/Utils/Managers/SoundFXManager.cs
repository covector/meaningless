using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public string[] names;
    public AudioClip[] clips;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    } 

    public void SetVolume(float newVolume)
    {
        audioSource.volume = newVolume;
    }

    public void PlayAudio(string clip)
    {

        audioSource.clip = clips[Array.IndexOf(names, clip)];
        audioSource.Play();
    }

    public void PlayAudio(string clip, int amount)
    {
        audioSource.clip = clips[Array.IndexOf(names, clip)];
        StartCoroutine(PlayAudioMultiple(amount));
    }

    IEnumerator PlayAudioMultiple(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (i != 0)
            {
                yield return new WaitForSeconds(audioSource.clip.length);
            }
            audioSource.Play();
        }
    }
}
