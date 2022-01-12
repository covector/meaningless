using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWalk : MonoBehaviour
{
    public Dialogue thoughts;
    public Dialogue dialogue;
    SceneUtils utils;
    FadeTransition fade;
    public GameObject walk;
    public InfSprite[] bgSprites;
    public WalkAnimation sean;
    public WalkAnimation me;
    public GameObject cinematic;
    public SpriteChanger seanBack;

    void Start()
    {
        utils = GetComponent<SceneUtils>();
        fade = FindObjectOfType<FadeTransition>();
        FindObjectOfType<BGMusicManager>().PlayAudio("walk");
        FindObjectOfType<BGMusicManager>().FadeInVolume(1.5f, 0.5f)
        .Then(() => thoughts.StartDialogue("The rest of the day went by as normal."))
        .Then(() => thoughts.StartDialogue("As usual, I walked home with Sean after school."))
        .Then(() =>
        {
            thoughts.HideDialogue();
            walk.SetActive(true);
        })
        .Then(() => utils.WaitForSeconds(3f))
        .Then(() =>
        {
            walk.SetActive(false);
            return thoughts.StartDialogue("Normally, we would chat a lot while walking.");
        })
        .Then(() =>
        {
            thoughts.HideDialogue();
            walk.SetActive(true);
        })
        .Then(() => utils.WaitForSeconds(8f))
        .Then(() => dialogue.StartDialogue("Me", "\"Ehmm... You know.....\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Having a low score in one exam doesn・t mean shit.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"You just have to learn from it and improve, am I right?\""))
        .Then(() =>
         {
             dialogue.HideDialogue();
             return utils.WaitForSeconds(2.5f);
         })
        .Then(() => dialogue.StartDialogue("Me", "\"I also have my fair share of mistakes.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"No one in this world is perfect I can ensure you that.\""))
        .Then(() =>
        {
            dialogue.HideDialogue();
            return utils.WaitForSeconds(6f);
        })
        .Then(() => dialogue.StartDialogue("Sean", "\"I・m not sure if I have told you before...\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"but I started composing my own music recently.\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"And honestly, I found it quite fun.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Yea? Good for you then.\""))
        .Then(() =>
         {
             dialogue.HideDialogue();
             return utils.WaitForSeconds(3f);
         })
        .Then(() => dialogue.StartDialogue("Sean", "\"Also...\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"I have been thinking lately...\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"Maybe I should leave this place, and start a career as a musician.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Uhuh...\""))
        .Then(() =>
        {
            dialogue.HideDialogue();
            return utils.WaitForSeconds(1f);
        })
        .Then(() => dialogue.StartDialogue("Me", "\"Wait what?\""))
        .Then(() => dialogue.StartDialogue("Me", "\"You mean you want to drop out of school? Why would you want to do that?\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"Because I want to become a musician.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"It is fine that you like music and play it as a hobby.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"But after all, we are still medical students.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"We are meant to be doctors.\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"Are we though?\""))
        .Then(() => dialogue.StartDialogue("Me", "\"...\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Have you already forgotten that we were chosen by the \'Essential Law\' to be doctors.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"It has been decided that we will become doctors after that selection test.\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"I know that, but even so, why should I give a shit about that stupid law?\""))
        .Then(() => dialogue.StartDialogue("Me", "\"What are you on about?\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"The selection is performed by humans just like us.\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"Who are they to have the right to define my purpose in this world?\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Calm down. It is fine that you feel frustrated after such low score.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"But don't you think this is too far? You are starting to not make any sense.\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"This isn't about the score. I don't care about that score, okay?\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"Why do you have so much faith in this \'Essential Law\' thing anyway.\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"As if you are worshipping a god or something.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"...\""))
        .Then(() => dialogue.StartDialogue("Me", "\"It doesn't matter whether you care about the \'Essential Law\' or not.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"People chosen by the \'Essential Law\' have a much bigger advantage when it comes to employment.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Even if you are really good at music, you will still not likely get a well-paid job.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"So what is your plan?\""))
        .Then(() => dialogue.StartDialogue("Me", "\"Do you even have one to begin with?\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"I・ll figure things out along the way.\""))
        .Then(() => dialogue.StartDialogue("Me", "\"You can't do that. That's dangerous.\""))
        .Then(() =>
        {
            dialogue.HideDialogue();
            return thoughts.StartDialogue("hollowness");
        })
        .Then(() => utils.WaitForSeconds(0.4f))
        .Then(() =>
        {
            thoughts.HideDialogue();
            return dialogue.StartDialogue("Me", "\"What if you can・t find a job, and end up losing your meaning in life.\"");
        })
        .Then(() => dialogue.StartDialogue("Me", "\"You will DIE!\""))
        .Then(() =>
        {
            dialogue.HideDialogue();
            FindObjectOfType<BGMusicManager>().FadeOutVolume(2f)
            .Then(() =>
            {
                FindObjectOfType<BGMusicManager>().PlayAudio("dream");
                return FindObjectOfType<BGMusicManager>().FadeInVolume(1.5f, 0.3f);
            });
        })
        .Then(() =>
        {
            foreach (InfSprite sprites in bgSprites)
            {
                sprites.auto = false;
            }
            sean.SetWalk(false);
            StartCoroutine(StopMe());
            return dialogue.StartDialogue("Sean", "\"So be it.\"");
        })
        .Then(() => dialogue.StartDialogue("Me", "\"Huh? What do you mean? Are you crazy?\""))
        .Then(() => dialogue.StartDialogue("Sean", "\"Is merely being alive enough for you?\""))
        .Then(() => dialogue.StartDialogue("Me", "\"...\""))
        .Then(() => fade.FadeOut())
        .Then(() => {
            dialogue.HideDialogue();
            walk.SetActive(false);
            cinematic.SetActive(true);
            return fade.FadeIn();
        })
        .Then(() => dialogue.StartDialogue("Sean", "\"If I can・t do the things I want...\""))
        .Then(() =>
        {
            seanBack.Change(1);
            return dialogue.StartDialogue("Sean", "\"what is the point of living?\"");
        })
        .Then(() =>
        {
            dialogue.HideDialogue();
            return fade.FadeOut();
        })
        .Then(() => {
            cinematic.SetActive(false);
            fade.SetTransparency(true);
            return utils.WaitForSeconds(1.5f);
        })
        .Then(() => thoughts.StartDialogue("\"What is the point of living?\""))
        .Then(() => thoughts.StartDialogue("He said with a smile on his face."))
        .Then(() => thoughts.StartDialogue("A brave yet nihilistic smile."))
        .Then(() => {
            thoughts.HideDialogue();
            return utils.WaitForSeconds(2f);
        })
        .Then(() => thoughts.StartDialogue("The next day Sean dropped out of school."))
        .Then(() => thoughts.StartDialogue("I have never seen him ever since then."))
        .Then(() => { FindObjectOfType<BGMusicManager>().FadeOutVolume(2f); })
        .Then(() => thoughts.StartDialogue("END OF DEMO. BYE BITCH."))
        .Then(() => fade.FadeOut())
        .Then(() => SceneManager.LoadScene(2));
    }

    private IEnumerator StopMe()
    {
        Transform trans = me.transform;
        float counter = 0f;
        while (counter < 1f)
        {
            trans.localPosition += new Vector3(Time.deltaTime * 1.5f, 0, 0);
            counter += Time.deltaTime;
            yield return null;
        }
        me.SetWalk(false);
    }
}
