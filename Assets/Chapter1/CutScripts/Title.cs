using System;
using System.Threading.Tasks;
using UnityEngine;

public class Title : MonoBehaviour
{
    async void Start()
    {
        await FindObjectOfType<FadeTransition>().FadeIn();
        await Task.Delay(3000);
        await FindObjectOfType<FadeTransition>().FadeOut();
        FindObjectOfType<CutsManager>().incrementCut();
    }
}
