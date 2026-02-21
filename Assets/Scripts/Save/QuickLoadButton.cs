using UnityEngine;
using UnityEngine.UI;

public class QuickLoadButton : MonoBehaviour
{
    [SerializeField] private int slotToLoad = 1; // Какой слот загружать

    private Button loadButton;

    private void Start()
    {
        loadButton = GetComponent<Button>();
        loadButton.onClick.AddListener(QuickLoad);

        // Делаем кнопку неактивной, если сохранения нет
        loadButton.interactable = SaveSystem.IsSaving(slotToLoad);
    }

    private void QuickLoad()
    {
        if (SaveManager.instance != null)
        {
            SaveManager.instance.SetSlot(slotToLoad);
            SaveManager.instance.LoadSlot(slotToLoad);
        }

    }
}
