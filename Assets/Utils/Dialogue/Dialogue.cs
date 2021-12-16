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
    public SoundFXManager audioManager;
    private Promise curProm;

    private void Start()
    {
        audioManager = FindObjectOfType<SoundFXManager>();
    }

    public IPromise StartDialogue(string speaker, string sentence)
    {
        if (!dialogueInProgress)
        {
            curProm = new Promise();
            dialogueInProgress = true;
            speakingInProgress = true;
            dialogueBox.SetActive(true);
            arrowButton.SetActive(false);
            speakerText.SetText(speaker);
            sentenceText.SetText(sentence);
            audioManager.SetVolume(0.2f);
            StartCoroutine(_StartDialogue(sentence));
        }
        return curProm;
    }

    IEnumerator _StartDialogue(string sentence)
    {
        int totalChar = sentence.Length;
        for (int i = 0; i <= totalChar; i++)
        {
            sentenceText.maxVisibleCharacters = i;
            audioManager.PlayAudio(1);
            yield return new WaitForSeconds(charDelay);
        }
        speakingInProgress = false;
        arrowButton.SetActive(true);
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
            arrowButton.SetActive(false);
            curProm.Resolve();
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
