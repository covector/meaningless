using UnityEngine;

public class Title : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<FadeTransition>().FadeIn();
        FindObjectOfType<CutsManager>().scheduleIncrement(3f);
    }
}
