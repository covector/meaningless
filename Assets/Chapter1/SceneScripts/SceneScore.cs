using UnityEngine;

public class SceneScore : MonoBehaviour
{
    public Dialogue thoughts;
    public Dialogue dialogue;
    public GameObject vignette;
    public GameObject title;
    public GameObject envelope;
    public GameObject heart;
    public GameObject classroom;
    public SpriteChanger headSprite;
    public SpriteChanger bodySprite;
    public SpriteChanger envelopeSprite;
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
        .Then(() => vignette.SetActive(false))
        .Then(() => fade.SetTransparency(true))
        .Then(() => WokeUp());
    }

    public void WokeUp()
    {
        utils.WaitForSeconds(2.5f)
        .Then(() => dialogue.StartDialogue("Paul", "\"...Hey.........Hey.......\""))
        .Then(() => dialogue.HideDialogue())
        .Then(() => FindObjectOfType<BGMusicManager>().PlayAudio("cherrytree"))
        .Then(() => FindObjectOfType<BGMusicManager>().FadeInVolume(1.5f, 0.5f))
        .Then(() => classroom.SetActive(true))
        .Then(() => utils.WaitForSeconds(0.7f))
        .Then(() => headSprite.Change(2))
        .Then(() => dialogue.StartDialogue("Me", "\"What?\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"What score did you get in the midterm exam?\""))
        .Then(() => dialogue.StartDialogue("Me", "\"I don't know. I haven't opened the envelope and looked yet.\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"What are you waiting for? Just open it already.\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"It is not like the score will change if you wait any longer.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"I was just a bit...\""))
        .Then(() => dialogue.StartDialogue("Me", "\"I was just about to do it, okay?\""))
        .Then(() => headSprite.Change(0))
        .Then(() => dialogue.StartDialogue("Me", "\"Geez... Why do you even care anyway?\""))
        .Then(() => dialogue.HideDialogue())
        .Then(() => utils.WaitForSeconds(0.5f))
        .Then(() => bodySprite.Change(1))
        .Then(() => utils.WaitForSeconds(2f))
        .Then(() => dialogue.StartDialogue("Please."))
        .Then(() => dialogue.HideDialogue())
        .Then(() => utils.WaitForSeconds(0.5f))
        .Then(() => bodySprite.Change(2))
        .Then(() => envelopeSprite.Change(1))
        .Then(() => utils.WaitForSeconds(0.7f))
        .Then(() => headSprite.Change(1))
        .Then(() => utils.WaitForSeconds(3f))
        .Then(() => headSprite.Change(2))
        .Then(() => dialogue.StartDialogue("Me", "\"I got... 94 out of 100.\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"Holy shit, That's really high.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Is it?\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"Of course. I only got 81 mark.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Oh...\""))
        .Then(() => dialogue.StartDialogue("", "[Smile.]"));
    }
}
