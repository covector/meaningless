using UnityEngine;

public class HeartPound : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<CutsManager>().scheduleIncrement(3);
    }
}
