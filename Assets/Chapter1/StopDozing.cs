using UnityEngine;

public class StopDozing : MonoBehaviour
{
    async void Start()
    {
        await FindObjectOfType<Dialogue>().StartDialogue("Speaker A", "¡§Hey, what score did you get?¡¨");
        FindObjectOfType<CutsManager>().incrementCut();
    }
}
