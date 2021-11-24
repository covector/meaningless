using System;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public GameObject arrowButton;
    private Action onClickEvent;

    public void ShowButton(NextButtonLocation location, Action onClick)
    {
        switch (location)
        {
            case NextButtonLocation.DIALOGUE:
                arrowButton.transform.localPosition = new Vector3(0f, 0f, 0f);
                break;
            case NextButtonLocation.SCREEN:
                arrowButton.transform.localPosition = new Vector3(0f, 0f, 0f);
                break;
        }
        arrowButton.SetActive(true);
        onClickEvent = onClick;
    }

    public void runOnClick()
    {
        arrowButton.SetActive(false);
        onClickEvent();
    }
}

public enum NextButtonLocation
{
    DIALOGUE,
    SCREEN
}