using System.Collections;
using UnityEngine;

public class HeartPound : MonoBehaviour
{
    public bool fast;

    void Start()
    {
        if (!fast)
        {
            FindObjectOfType<CutsManager>().scheduleIncrement(5f);
        } else
        {
            StartCoroutine(DelayDialogue());
            GetComponent<Animator>().speed = 2f;
        }
    }

    IEnumerator DelayDialogue()
    {
        yield return new WaitForSeconds(4f);
        FindObjectOfType<CutsManager>().scheduleIncrement(1f);
    }
}
