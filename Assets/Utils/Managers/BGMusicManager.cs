using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicManager : MonoBehaviour
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

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void FadeInVolume(float seconds, float volume)
    {
        StartCoroutine(_FadeInVolume(seconds, volume));
    }

    public void FadeOutVolume(float seconds)
    {
        StartCoroutine(_FadeOutVolume(seconds));
    }

    IEnumerator _FadeInVolume(float seconds, float volume)
    {
        float elapsed = 0f;
        while (elapsed < seconds)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = volume * elapsed / seconds;
            yield return null;
        }
    }

    IEnumerator _FadeOutVolume(float seconds)
    {
        float elapsed = 0f;
        float volume = audioSource.volume;
        while (elapsed < seconds)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = volume * (1 - elapsed / seconds);
            yield return null;
        }
        StopAudio();
    }
}
