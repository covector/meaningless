using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public DialogueData data;
    public float charDelay = 0.08f;
    public int maxChar = 400;
    public TextMeshPro speakerText;
    public TextMeshPro sentenceText;
    public GameObject dialogueBox;
    private int dialogueIndex = -1;
    private bool dialogueInProgress = false;

    public bool NextDialogue(Action callback)
    {
        if (!dialogueInProgress)
        {
            dialogueBox.SetActive(true);
            dialogueIndex++;
            dialogueInProgress = true;
            if (dialogueIndex >= data.dialogue.Length)
            {
                StartCoroutine(StartDialogue("", "", callback));
                return true;
            }
            SentenceData sentence = data.dialogue[dialogueIndex];
            StartCoroutine(StartDialogue(sentence.speaker, sentence.sentence, sentence.goOn ? delegate() { NextDialogue(callback); } : callback));
            return true;
        }
        return false;
    }

    IEnumerator StartDialogue(string speaker, string sentence, Action callback)
    {
        speakerText.SetText(speaker);
        sentenceText.SetText(sentence);
        int totalChar = sentenceText.textInfo.characterCount;
        for (int i = 0; i < maxChar; i++)
        {
            sentenceText.maxVisibleCharacters = i;
            yield return new WaitForSeconds(charDelay);
            if (i >= totalChar) { break; }
        }
        dialogueInProgress = false;
        callback();
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
}
