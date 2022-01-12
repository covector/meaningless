using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int nextInd;

    protected void Change()
    {
        SceneManager.LoadScene(nextInd);
    }
}
