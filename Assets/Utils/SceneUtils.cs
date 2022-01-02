using RSG;
using System.Collections;
using UnityEngine;

public class SceneUtils : MonoBehaviour
{
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
