using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SceneUtils>().WaitForSeconds(1f)
        .Then(() =>
        {
            FindObjectOfType<BGMusicManager>().PlayAudio("other");
            FindObjectOfType<BGMusicManager>().FadeInVolume(1.5f, 0.5f);
            return FindObjectOfType<FadeTransition>().FadeIn();
        });
    }

    public void StartGame()
    {
        FindObjectOfType<BGMusicManager>().FadeOutVolume(1f);
        FindObjectOfType<FadeTransition>().FadeOut()
        .Then(() => SceneManager.LoadScene(2));
    }

    public void QuitGame()
    {
        FindObjectOfType<BGMusicManager>().FadeOutVolume(1f);
        FindObjectOfType<FadeTransition>().FadeOut()
        .Then(() => Application.Quit());
    }
}
