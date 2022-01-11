using RSG;
using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public float charDelay = 0.08f;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI sentenceText;
    public GameObject dialogueBox;
    public GameObject arrowButton;
    private bool dialogueInProgress = false;
    private bool speakingInProgress = false;
    private SoundFXManager audioManager;
    private Promise curProm;

    private void Start()
    {
        audioManager = FindObjectOfType<SoundFXManager>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && dialogueInProgress)
        {
            EndDialogue();
        }
    }

    public IPromise StartDialogue(string speaker, string sentence)
    {
        if (!dialogueInProgress)
        {
            curProm = new Promise();
            dialogueInProgress = true;
            speakingInProgress = true;
            if (dialogueBox) {
                dialogueBox.SetActive(true);
            }
            arrowButton.SetActive(false);
            if (speakerText)
            {
                speakerText.SetText(speaker);
            }
            sentenceText.SetText(sentence);
            audioManager.SetVolume(0.1f);
            StartCoroutine(_StartDialogue(sentence));
        }
        return curProm;
    }

    public IPromise StartDialogue(string sentence)
    {
        return StartDialogue("", sentence);
    }

    IEnumerator _StartDialogue(string sentence)
    {
        int totalChar = sentence.Length;
        for (int i = 0; i <= totalChar; i++)
        {
            sentenceText.maxVisibleCharacters = i;
            audioManager.PlayAudio("dialogue");
            if (!speakingInProgress)
            {
                sentenceText.maxVisibleCharacters = totalChar;
                break;
            }
            yield return new WaitForSeconds(charDelay);
        }
        speakingInProgress = false;
        arrowButton.SetActive(true);
    }

    public bool HideDialogue()
    {
        if (!dialogueInProgress)
        {
            if (dialogueBox)
            {
                dialogueBox.SetActive(false);
            }
            if (speakerText)
            {
                speakerText.SetText("");
            }
            sentenceText.SetText("");
            return true;
        }
        return false;
    }

    public void EndDialogue()
    {
        if (dialogueInProgress)
        {
            if (speakingInProgress)
            {
                speakingInProgress = false;
            } else
            {
                dialogueInProgress = false;
                arrowButton.SetActive(false);
                curProm.Resolve();
            }
        }
    }

    public void FullReset()
    {
        dialogueInProgress = false;
        speakingInProgress = false;
        StopAllCoroutines();
        HideDialogue();
    }
}
