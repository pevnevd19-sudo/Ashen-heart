using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]private DialogueSO dialogueSO;
    private DialogueController dialogueController;

    private void Start()
    {
        dialogueController = FindFirstObjectByType<DialogueController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueController.StartDialogue(dialogueSO);
        }

            
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        dialogueController.ShowDialogue(false);
    }
}
