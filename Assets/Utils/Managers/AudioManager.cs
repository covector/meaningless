using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    } 

    public void PlayAudio(int clip)
    {
        audioSource.clip = clips[clip];
        audioSource.Play();
    }

    public void PlayAudio(int clip, int amount)
    {
        audioSource.clip = clips[clip];
        StartCoroutine(playAudioMultiple(amount));
    }

    IEnumerator playAudioMultiple(int amount)
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
