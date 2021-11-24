using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class CutsManager : MonoBehaviour
{
    public GameObject[] cuts;
    public int cutIndex = 0;

    public void incrementCut()
    {
        if (cutIndex < cuts.Length - 1)
        {
            cuts[cutIndex].SetActive(false);
            cutIndex++;
            cuts[cutIndex].SetActive(true);
        }
    }
}
