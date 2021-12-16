using RSG;
using System.Collections;
using UnityEngine;

public class CutsManager : MonoBehaviour
{
    public GameObject[] cuts;
    public int cutIndex = 0;

    private void Start()
    {
        if (cuts.Length > 0) { cuts[0].SetActive(true); }
    }

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
