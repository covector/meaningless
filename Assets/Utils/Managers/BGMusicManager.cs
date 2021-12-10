using UnityEngine;

public class BGMusicManager : MonoBehaviour
{
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

    public void PlayAudio(int clip)
    {
        audioSource.clip = clips[clip];
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
