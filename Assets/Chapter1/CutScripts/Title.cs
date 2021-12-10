using UnityEngine;

public class Title : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<BGMusicManager>().SetVolume(0.35f);
        FindObjectOfType<BGMusicManager>().PlayAudio(0);
        FindObjectOfType<FadeTransition>().FadeIn()
        .Then(() => FindObjectOfType<CutsManager>().WaitForSeconds(3))
        .Then(() => FindObjectOfType<FadeTransition>().FadeOut())
        .Then(() => FindObjectOfType<CutsManager>().incrementCut());
    }
}
