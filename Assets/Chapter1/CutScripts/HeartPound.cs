using UnityEngine;

public class HeartPound : MonoBehaviour
{
    public SoundFXManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<SoundFXManager>();
    }

    void OnEnable()
    {
        audioManager.SetVolume(1f);
        FindObjectOfType<FadeTransition>().SetTransparency(true);
        FindObjectOfType<CutsManager>().WaitForSeconds(5)
        .Then(() => FindObjectOfType<CutsManager>().incrementCut());
    }

    protected void PlayHeartBeat()
    {
        audioManager.PlayAudio(0, 2);
    }
}
