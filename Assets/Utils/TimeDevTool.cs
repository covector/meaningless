using UnityEngine;

public class TimeDevTool : MonoBehaviour
{
    public float scale = 10f;
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Time.timeScale = scale;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
