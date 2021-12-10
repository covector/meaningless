using UnityEngine;

public class AskScore : MonoBehaviour
{
    public Sprite personSprite;
    public Sprite personSpriteLeft;
    public SpriteRenderer personSpriteRenderer;

    void Start()
    {
        FindObjectOfType<BGMusicManager>().StopAudio();
        FindObjectOfType<Dialogue>().HideDialogue();
        FindObjectOfType<CutsManager>().WaitForSeconds(0.5f)
        .Then(() => FindObjectOfType<Dialogue>().StartDialogue("Paul", "Hey, what score did you get?"))
        .Then(() => FindObjectOfType<CutsManager>().WaitForSeconds(0.5f))
        .Then(() => FindObjectOfType<Dialogue>().StartDialogue("Me", "I don't know. I haven't turned it over and looked yet."))
        .Then(() =>
        {
            FindObjectOfType<Dialogue>().HideDialogue();
            personSpriteRenderer.sprite = personSprite;
        })
        .Then(() => FindObjectOfType<CutsManager>().WaitForSeconds(0.5f))
        .Then(() => FindObjectOfType<CutsManager>().incrementCut());
    }

    protected void Turn()
    {
        personSpriteRenderer.sprite = personSpriteLeft;
    }
}
