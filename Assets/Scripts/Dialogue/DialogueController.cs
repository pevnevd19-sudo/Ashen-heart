using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueSO currentDialogue;
    [SerializeField] private DialogueSO.DialogueNode currentNode;
    [SerializeField] private DialogueUI dialogueUI;

    private void Awake()
    {
        dialogueUI.Show(false);
    }
    public void StartDialogue(DialogueSO dialogue)
    {
        if (dialogue == null || dialogue.startNode == null)
        {
            return;
        }

        currentDialogue = dialogue;
        currentNode = dialogue.startNode;
        dialogueUI.Show(true);
    }

    public bool ShowDialogue(bool variable)
    {
        dialogueUI.Show(variable);
        return variable;
    }
    public void EndDialogue()
    {
        dialogueUI.Show(false);
        dialogueUI.ClearChoices();
        dialogueUI.HideContinue();
        currentDialogue = null;
        currentNode = null;
    }
    private void ShowNode()
    {
        if(currentNode== null)
        {
            EndDialogue();
            return;
        }
        var speaker = currentNode.speaker;
        Sprite portrait = null;
        var speakerName = speaker ? speaker.DisplayName : "No name";

        dialogueUI.SetLine(speakerName, portrait, currentNode.text);

        if (currentNode.choices != null && currentNode.choices.Count>0)
        {
            var list = new List<(string, System.Action)>();
            foreach (var choices in currentNode.choices)
            {
                list.Add((choices.textButton, () =>
                {
                    currentNode = choices.next;
                    ShowNode();
                }
                ));
            }
            dialogueUI.ShowChoices(list);
        }
        else
        {
            dialogueUI.ClearChoices();
            dialogueUI.SetContinue(() =>
            {
                currentNode = currentNode.NextDialogue;
                ShowNode();
            });
        }
    }
}
