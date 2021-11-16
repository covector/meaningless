using System.Collections;
using UnityEngine;

public class CutsManager : MonoBehaviour
{
    public GameObject[] cuts;
    private int cutIndex = 0;
    private IEnumerator coroutine;

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
