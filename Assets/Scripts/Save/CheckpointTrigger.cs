using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField]private SaveManager saveManager;
    [SerializeField] private NotificationInGame notificationInGame;
    private Timer timer;
    
    private void Awake()
    {
        timer = FindFirstObjectByType<Timer>();
        saveManager = FindFirstObjectByType<SaveManager>();
        notificationInGame = FindFirstObjectByType<NotificationInGame>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<UserControl>())
        {
            saveManager.SetCheckpoint(saveManager.LastCheckpointID);
            notificationInGame.SetNotification("Save");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
