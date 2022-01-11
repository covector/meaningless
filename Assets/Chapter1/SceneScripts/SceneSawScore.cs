using UnityEngine;

public class SceneSawScore : MonoBehaviour
{
    protected void AnimationEnd()
    {
        FindObjectOfType<SceneScore>().SawScore();
        gameObject.SetActive(false);
    }
}
