using System;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    public float speed = 1f;
    private Animator anim;
    private Image screen;
    private Action fadeInCallback;
    private Action fadeOutCallback;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        screen = GetComponent<Image>();
        anim.SetFloat("speed", speed);
    }

    public void FadeIn(Action callback)
    {
        fadeInCallback = callback;
        anim.SetTrigger("in");
    }

    public void FadeIn()
    {
        FadeIn(delegate () {; });
    }

    public void FadeOut(Action callback)
    {
        fadeOutCallback = callback;
        anim.SetTrigger("out");
    }

    public void FadeOut()
    {
        FadeOut(delegate () {; });
    }

    public void SetOpacity(float opacity)
    {
        screen.color = new Color(0, 0, 0, opacity);
    }

    public void SetSpeed(float newSpeed)
    {
        anim.SetFloat("speed", newSpeed);
    }

    protected void CallFadeOutCallback()
    {
        fadeOutCallback();
    }

    protected void CallFadeInCallback()
    {
        fadeInCallback();
    }
}
