using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScore : MonoBehaviour
{
    public Dialogue thoughts;
    public Dialogue dialogue;
    public GameObject vignette;
    public GameObject title;
    public GameObject envelope;
    public GameObject heart;
    public GameObject classroom;
    public GameObject saw;
    public SpriteChanger headSprite;
    public SpriteChanger bodySprite;
    public SpriteChanger envelopeSprite;
    SceneUtils utils;
    public FadeTransition fade;

    void Start()
    {
        utils = GetComponent<SceneUtils>();
        utils.WaitForSeconds(1f)
        .Then(() =>
        {
            title.SetActive(true);
            vignette.SetActive(true);
            return fade.FadeIn();
        })
        .Then(() => FindObjectOfType<BGMusicManager>().PlayAudio("king"))
        .Then(() => FindObjectOfType<BGMusicManager>().FadeInVolume(2f, 0.5f))
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
        .Then(() => fade.FadeOut())
        .Then(() => thoughts.HideDialogue())
        .Then(() => vignette.SetActive(false))
        .Then(() => fade.SetTransparency(true))
        .Then(() => FindObjectOfType<BGMusicManager>().FadeOutVolume(2f))
        .Then(() => WokeUp());
    }

    void WokeUp()
    {
        dialogue.StartDialogue("Paul", "\"...Hey.........Hey.......\"")
        .Then(() => dialogue.HideDialogue())
        .Then(() => classroom.SetActive(true))
        .Then(() => FindObjectOfType<BGMusicManager>().PlayAudio("cherrytree"))
        .Then(() => FindObjectOfType<BGMusicManager>().FadeInVolume(1f, 0.5f))
        .Then(() => headSprite.Change(2))
        .Then(() => dialogue.StartDialogue("Me", "\"What?\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"What score did you get in the midterm exam?\""))
        .Then(() => dialogue.StartDialogue("Me", "\"I don't know. I haven't opened the envelope and looked yet.\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"What are you waiting for? Just open it already.\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"It is not like the score will change if you wait any longer.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"I was just a bit...\""))
        .Then(() => dialogue.StartDialogue("Me", "\"I was just about to do it, okay?\""))
        .Then(() => headSprite.Change(0))
        .Then(() => dialogue.StartDialogue("Me", "\"Jeez... Why do you even care anyway?\""))
        .Then(() => dialogue.HideDialogue())
        .Then(() => CheckScore());

    }

    void CheckScore()
    {
        utils.WaitForSeconds(0.5f)
        .Then(() => bodySprite.Change(1))
        .Then(() => utils.WaitForSeconds(3f))
        .Then(() => thoughts.StartDialogue("Please."))
        .Then(() => thoughts.HideDialogue())
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
        .Then(() => dialogue.StartDialogue("", "[Smirk.]"))
        .Then(() => dialogue.HideDialogue())
        .Then(() => utils.WaitForSeconds(1f))
        .Then(() => dialogue.StartDialogue("Me", "\"I probably just got lucky this time.\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"Huh? You literally got the highest score in the whole class in almost every quiz.\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"And you call that luck?\""))
        .Then(() => dialogue.StartDialogue("Me", "..."))
        .Then(() => dialogue.StartDialogue("Paul", "\"I mean you are always trying so hard. You even do practice paper during break time.\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"If anyone were to get the highest score, it would be you.\""))
        .Then(() => dialogue.HideDialogue())
        .Then(() => utils.WaitForSeconds(1f))
        .Then(() => dialogue.StartDialogue("Me", "\"Well, the midterm score doesn・t really mean that much.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"If I fuck up the final exam, no matter how well I did during the midterm exam, it doesn・t matter.\""))
        .Then(() => dialogue.StartDialogue("Paul", "\"Dude, stop being this humble. Just admit that you are good.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Umm...ok...\""))
        .Then(() => dialogue.HideDialogue())
        .Then(() => utils.WaitForSeconds(2f))
        .Then(() => headSprite.Change(3))
        .Then(() => classroom.GetComponent<Animator>().SetTrigger("pan"))
        .Then(() => dialogue.StartDialogue("Me", "\"Oh yea, how about you, Sean?\""))
        .Then(() => FindObjectOfType<BGMusicManager>().FadeOutVolume(0.5f))
        .Then(() => dialogue.StartDialogue("Me", "\"What score did yo-\""))
        .Then(() => dialogue.HideDialogue())
        .Then(() => FindObjectOfType<BGMusicManager>().PlayAudio("king"))
        .Then(() => {
            FindObjectOfType<BGMusicManager>().FadeInVolume(1.5f, 0.5f);
            return fade.FadeOut();
        })
        .Then(() => classroom.SetActive(false))
        .Then(() => fade.SetTransparency(true))
        .Then(() => saw.SetActive(true));
    }

    public void SawScore()
    {
        thoughts.StartDialogue("He got 36 out of 100.")
        .Then(() => thoughts.StartDialogue("Basically, he failed the exam."))
        .Then(() => thoughts.StartDialogue("To put in perspective how absurd this is."))
        .Then(() => thoughts.StartDialogue("The last time I saw a fail from someone was more than 5 years ago."))
        .Then(() => thoughts.StartDialogue("Really rarely does one fail."))
        .Then(() => thoughts.StartDialogue("As long as you did all your revision,"))
        .Then(() => thoughts.StartDialogue("A passing grade was guaranteed."))
        .Then(() => thoughts.StartDialogue("So what happened?"))
        .Then(() => thoughts.StartDialogue("Did he do his revision on the wrong materials?"))
        .Then(() => thoughts.StartDialogue("Or was he extremely ill on the day of the exam?"))
        .Then(() => thoughts.StartDialogue("I can・t really think of any other reason."))
        .Then(() => thoughts.StartDialogue("This just doesn・t make any sense."))
        .Then(() => fade.FadeOut())
        .Then(() => FindObjectOfType<BGMusicManager>().FadeOutVolume(1.5f))
        .Then(() => SceneManager.LoadScene(3));
    }
}
