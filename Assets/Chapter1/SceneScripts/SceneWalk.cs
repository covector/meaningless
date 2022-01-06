using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWalk : MonoBehaviour
{
    public Dialogue thoughts;
    public Dialogue dialogue;
    SceneUtils utils;
    FadeTransition fade;
    public GameObject walk;
    public InfSprite[] bgSprites;
    public WalkAnimation sean;
    public WalkAnimation me;

    void Start()
    {
        utils = GetComponent<SceneUtils>();
        fade = FindObjectOfType<FadeTransition>();
    }
}
