using UnityEngine;

public class ConstantShake : MonoBehaviour
{
    private float timePassed = 0f;
    public float magnitude = 1f;
    public float speed = 1f;
    public float variation = 1f;

    void Start()
    {
        timePassed = 0f;
    }

    void Update()
    {
        transform.localPosition = magnitude * new Vector3(Mathf.PerlinNoise(100 * variation + speed * timePassed, 0) - 0.5f, Mathf.PerlinNoise(0, 100 * variation + speed * timePassed) - 0.5f, 0);
        timePassed += Time.deltaTime;
    }
}
