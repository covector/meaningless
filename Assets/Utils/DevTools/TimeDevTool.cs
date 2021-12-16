using UnityEngine;

public class TimeDevTool : MonoBehaviour
{
    CutsManager cuts;

    void Start()
    {
        cuts = FindObjectOfType<CutsManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { AddCuts(1); }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { AddCuts(-1); }
    }

    private void AddCuts(int offset)
    {
        int ind = cuts.cutIndex;
        if (ind + offset < cuts.cuts.Length && ind + offset >= 0)
        {
            FindObjectOfType<FadeTransition>().SetTransparency(true);
            FindObjectOfType<Dialogue>().FullReset();
            FindObjectOfType<BGMusicManager>().StopAllCoroutines();
            cuts.StopAllCoroutines();
            cuts.cuts[ind].SetActive(false);
            cuts.cuts[ind + offset].SetActive(true);
            cuts.cutIndex += offset;
        }
    }
}
