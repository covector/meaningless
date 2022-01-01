using UnityEngine;

public class SceneScore : MonoBehaviour
{
    public Dialogue thoughts;
    public GameObject vignette;
    public GameObject title;
    public GameObject envelope;
    public GameObject heart;
    SceneUtils utils;
    FadeTransition fade;

    void Start()
    {
        utils = GetComponent<SceneUtils>();
        fade = FindObjectOfType<FadeTransition>();
        title.SetActive(true);
        vignette.SetActive(true);
        fade.FadeIn()
        .Then(() => FindObjectOfType<BGMusicManager>().FadeInVolume(1.5f, 0.5f))
        .Then(() => FindObjectOfType<BGMusicManager>().PlayAudio("king"))
        .Then(() => utils.WaitForSeconds(2f))
        .Then(() => fade.FadeOut())
        .Then(() => title.SetActive(false))
        .Then(() => fade.SetTransparency(true))
        .Then(() => utils.WaitForSeconds(1f))
        .Then(() => thoughts.StartDialogue("Score is just a number."))
        .Then(() => fade.FadeOut())
        .Then(() => thoughts.HideDialogue())
        .Then(() => fade.SetTransparency(true))
        .Then(() => envelope.SetActive(true));
    }

    public void ThoughtCont()
    {
        thoughts.StartDialogue("All that matters...")
        .Then(() => thoughts.StartDialogue("is the knowledge we gained."))
        .Then(() => fade.FadeOut())
        .Then(() => thoughts.HideDialogue())
        .Then(() => fade.SetTransparency(true))
        .Then(() => heart.SetActive(true))
        .Then(() => utils.WaitForSeconds(3.2f))
        .Then(() => fade.FadeOut())
        .Then(() => heart.SetActive(false))
        .Then(() => fade.SetTransparency(true))
        .Then(() => thoughts.StartDialogue("As long as I did my best..."))
        .Then(() => thoughts.StartDialogue("I should be satisfied."))
        .Then(() => thoughts.HideDialogue())
        .Then(() => utils.WaitForSeconds(1f))
        .Then(() => thoughts.StartDialogue("Right?"))
        .Then(() => FindObjectOfType<BGMusicManager>().FadeOutVolume(2f))
        .Then(() => fade.FadeOut())
        .Then(() => thoughts.HideDialogue())
        .Then(() => fade.SetTransparency(true))
        .Then(() => WokeUp());
    }

    public void WokeUp()
    {
        utils.WaitForSeconds(2.5f);
    }
}
