using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueData", order = 1)]
public class DialogueData : ScriptableObject
{
    public SentenceData[] dialogue;
}

[System.Serializable]
public class SentenceData
{
    public string speaker;
    public string sentence;
    public bool goOn = false;
}