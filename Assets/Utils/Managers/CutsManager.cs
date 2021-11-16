using System.Collections;
using UnityEngine;

public class CutsManager : MonoBehaviour
{
    public GameObject[] cuts;
    public int cutIndex = 0;
    public bool strict = true;
    private IEnumerator coroutine;

    void Start()
    {
        if (strict)
        {
            cutIndex = 0;
            for (int i = 0; i < cuts.Length; i++)
            {
                cuts[i].SetActive(i == 0);
            }
        }
    }

    public void scheduleIncrement(float delay)
    {
        coroutine = IncrementCutCoroutine(delay);
        StartCoroutine(coroutine);
    }

    public void incrementCut()
    {
        if (cutIndex >= cuts.Length - 1)
        {
            cuts[cutIndex].SetActive(false);
            cutIndex++;
            cuts[cutIndex].SetActive(true);
        }
        cancelCoroutine();
    }

    public void cancelCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    IEnumerator IncrementCutCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        incrementCut();
    }
}
