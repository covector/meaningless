using UnityEngine;

public class StopSpacingOut : MonoBehaviour
{
    void OnEnable()
    {
        FindObjectOfType<BGMusicManager>().FadeOutVolume(1.2f);
        FindObjectOfType<Dialogue>().StartDialogue("Paul", "..Hey.....Hey...")
        .Then(() => FindObjectOfType<CutsManager>().incrementCut());
    }
}
