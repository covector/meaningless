using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public int charDelay = 80;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI sentenceText;
    public GameObject dialogueBox;
    public GameObject arrowButton;
    public bool dialogueInProgress = false;
    public bool speakingInProgress = false;

    public async Task StartDialogue(string speaker, string sentence)
    {
        if (!dialogueInProgress)
        {
            dialogueInProgress = true;
            speakingInProgress = true;
            dialogueBox.SetActive(true);
            arrowButton.SetActive(false);
            speakerText.SetText(speaker);
            sentenceText.SetText(sentence);
            int totalChar = sentence.Length;
            for (int i = 0; i <= totalChar; i++)
            {
                sentenceText.maxVisibleCharacters = i;
                await Task.Delay(charDelay);
            }
            speakingInProgress = false;
            arrowButton.SetActive(true);
            while (dialogueInProgress)
            {
                await Task.Delay(25);
            }
            arrowButton.SetActive(false);
        }
    }

    public bool HideDialogue()
    {
        if (!dialogueInProgress)
        {
            dialogueBox.SetActive(false);
            return true;
        }
        return false;
    }

    public void EndDialogue()
    {
        if (!speakingInProgress)
        {
            dialogueInProgress = false;
        }
    }
}
