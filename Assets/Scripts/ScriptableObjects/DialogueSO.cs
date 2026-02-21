using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Dialogue/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public DialogueNode startNode;

    [Serializable]
    public class DialogueNode
    {
        public SpeakerSO speaker;

        [TextArea(3, 8)]
        public string text;

        public DialogueNode NextDialogue;

        [Header("Choices")]

        public List<Choice> choices;
    }
    [Serializable]
    public class Choice
    {
        public string textButton;
        public DialogueNode next;
    }
}
