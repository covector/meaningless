using UnityEngine;

public class StopSpacingOut : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<Dialogue>().StartDialogue("Paul", "..Hey.....Hey...")
        .Then(() => FindObjectOfType<CutsManager>().incrementCut());
    }
}
