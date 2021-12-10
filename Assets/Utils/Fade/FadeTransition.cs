using UnityEngine;
using UnityEngine.UI;
using RSG;

public class FadeTransition : MonoBehaviour
{
    public float speed = 1f;
    private Animator anim;
    private Image screen;
    private bool inProgress = false;
    private Promise curProm;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        screen = GetComponent<Image>();
        anim.SetFloat("speed", speed);
    }

    public IPromise FadeIn()
    {
        if (!inProgress)
        {
            inProgress = true;
            curProm = new Promise();
            anim.SetTrigger("in");
        }
        return curProm;
    }

    protected void FadeInEnd()
    {
        screen.enabled = false;
        inProgress = false;
        if (curProm != null)
        {
            curProm.Resolve();
        }
    }

    public IPromise FadeOut()
    {
        if (!inProgress)
        {
            screen.enabled = true;
            inProgress = true;
            curProm = new Promise();
            anim.SetTrigger("out");
        }
        return curProm;
    }

    protected void FadeOutEnd()
    {
        inProgress = false;
        if (curProm != null)
        {
            curProm.Resolve();
        }
    }

    public void SetSpeed(float newSpeed)
    {
        anim.SetFloat("speed", newSpeed);
    }
}
