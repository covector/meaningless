using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    public float speed = 1f;
    private Animator anim;
    private Image screen;
    private bool inProgress = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        screen = GetComponent<Image>();
        anim.SetFloat("speed", speed);
    }

    public async Task FadeIn()
    {
        inProgress = true;
        anim.SetTrigger("in");
        while (inProgress)
        {
            await Task.Delay(25);
        }
        screen.enabled = false;
    }

    public async Task FadeOut()
    {
        screen.enabled = true;
        inProgress = true;
        anim.SetTrigger("out");
        while (inProgress)
        {
            await Task.Delay(25);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        anim.SetFloat("speed", newSpeed);
    }

    protected void AnimationEnd()
    {
        inProgress = false;
    }
}
