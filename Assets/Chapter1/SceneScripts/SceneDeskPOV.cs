using UnityEngine;

public class SceneDeskPOV : MonoBehaviour
{
    protected void AnimationEnd()
    {
        FindObjectOfType<SceneScore>().ThoughtCont();
        gameObject.SetActive(false);
    }
}
