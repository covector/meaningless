using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class HeartPound : MonoBehaviour
{
    public bool fast;
    public AudioManager audioManager;

    async void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (!fast)
        {
            await FindObjectOfType<FadeTransition>().FadeIn();
            await Task.Delay(5000);
            FindObjectOfType<CutsManager>().incrementCut();
        } else
        {
            GetComponent<Animator>().speed = 2f;
            await Task.Delay(4000);
            // start dialogue
            await Task.Delay(500);
            FindObjectOfType<CutsManager>().incrementCut();
        }
    }

    protected void PlayHeartBeat()
    {
        audioManager.PlayAudio(0, 2);
    }
}
