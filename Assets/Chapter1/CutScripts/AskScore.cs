using System.Threading.Tasks;
using UnityEngine;

public class AskScore : MonoBehaviour
{
    public Sprite personSprite;
    public Sprite personSpriteLeft;
    public SpriteRenderer personSpriteRenderer;

    async void Start()
    {
        FindObjectOfType<Dialogue>().HideDialogue();
        await Task.Delay(500);
        await FindObjectOfType<Dialogue>().StartDialogue("Paul", "Hey, what score did you get?");
        await Task.Delay(500);
        await FindObjectOfType<Dialogue>().StartDialogue("Me", "I don't know. I haven't turned it over and looked yet.");
        FindObjectOfType<Dialogue>().HideDialogue();
        personSpriteRenderer.sprite = personSprite;
        await Task.Delay(500);
        FindObjectOfType<CutsManager>().incrementCut();
    }

    protected void Turn()
    {
        personSpriteRenderer.sprite = personSpriteLeft;
    }
}
