using UnityEngine;

public class SceneHeartPound : MonoBehaviour
{
    public SoundFXManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<SoundFXManager>();
        audioManager.SetVolume(0.75f);
    }

    protected void PlayHeartBeat()
    {
        audioManager.PlayAudio("heartbeat", 2);
    }
}
