using UnityEngine;

public class HeartPound : MonoBehaviour
{
    public bool fast;
    public SoundFXManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<SoundFXManager>();
        if (!fast)
        {
            FindObjectOfType<FadeTransition>().FadeIn()
            .Then(() => FindObjectOfType<CutsManager>().WaitForSeconds(5))
            .Then(() => FindObjectOfType<CutsManager>().incrementCut());
        } else
        {
            GetComponent<Animator>().speed = 2f;
            FindObjectOfType<CutsManager>().WaitForSeconds(4)
            .Then(() => FindObjectOfType<CutsManager>().incrementCut());
        }
    }

    protected void PlayHeartBeat()
    {
        audioManager.PlayAudio(0, 2);
    }
}
