using RSG;
using System.Collections;
using UnityEngine;

public class CutsManager : MonoBehaviour
{
    public GameObject[] cuts;
    private int cutIndex = 0;

    public void incrementCut()
    {
        if (cutIndex < cuts.Length - 1)
        {
            cuts[cutIndex].SetActive(false);
            cutIndex++;
            cuts[cutIndex].SetActive(true);
        }
    }

    public IPromise WaitForSeconds(float seconds)
    {
        Promise prom = new Promise();
        StartCoroutine(_WaitForSeconds(prom, seconds));
        return prom;
    }

    IEnumerator _WaitForSeconds(Promise prom, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        prom.Resolve();
    }
}
