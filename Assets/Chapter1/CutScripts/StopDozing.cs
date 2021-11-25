using UnityEngine;

public class StopDozing : MonoBehaviour
{
    async void Start()
    {
        await FindObjectOfType<Dialogue>().StartDialogue("Paul", "..Hey.....Hey...");
        FindObjectOfType<CutsManager>().incrementCut();
    }
}
