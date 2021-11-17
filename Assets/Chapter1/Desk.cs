using UnityEngine;

public class Desk : MonoBehaviour
{
    protected void FinZoom()
    {
        FindObjectOfType<CutsManager>().incrementCut();
    }
}
