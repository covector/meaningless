using System.Collections;
using UnityEngine;

public class DecayShake : MonoBehaviour
{
    public float defaultTime = 1f;
    public float defaultMagnitude = 1f;
    public float defaultSpeed = 1f;

    private IEnumerator DecayShakeSequence(float time, float magnitude, float speed)
    {
        float variation = Random.Range(0f, 1f);
        float timePassed = 0;
        Vector3 origin = transform.localPosition;
        while (timePassed < time)
        {
            transform.localPosition = origin + magnitude * (1 - timePassed / time) * new Vector3(Mathf.PerlinNoise(100 * variation + speed * timePassed, 0) - 0.5f, Mathf.PerlinNoise(0, 100 * variation + speed * timePassed) - 0.5f, 0);
            timePassed += Time.deltaTime;
            yield return null;
        }
    }

    public void InitShake(float time, float magnitude, float speed)
    {
        StartCoroutine(DecayShakeSequence(time, magnitude, speed));
    }

    public void InitShake()
    {
        StartCoroutine(DecayShakeSequence(defaultTime, defaultMagnitude, defaultSpeed));
    }
}
