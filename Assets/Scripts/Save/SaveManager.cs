using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }
    [SerializeField] private Transform playerTrans;
    [SerializeField] private int currentSlot = 0;
    public int Morality { get; private set; }
    public string LastCheckpointID { get; private set; }
    public int Money { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode load)
    {
        if (playerTrans == null)
        {
            playerTrans = FindFirstObjectByType<UserControl>().transform;
        }

    }
    public void SetPlayer(Transform player)
    {
        playerTrans = player;
    }
    public void SetSlot(int slot)
    {
        currentSlot = slot;
    }

    private void SaveNow()
    {
        if (playerTrans == null)
        {
            return;
        }
        var data = new SaveData
        {
            SceneName = SceneManager.GetActiveScene().name,
            px = playerTrans.position.x,
            py = playerTrans.position.y,
            pz = playerTrans.position.z,
            MoralityScore = Morality,
            Money = Money,
            LastCheckpointID = LastCheckpointID,
            SaveTime = System.DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        SaveSystem.Save(currentSlot, data);
    }
    public void LoadSlot(int slot)
    {
        if (!SaveSystem.TryLoad(slot, out var data))
        {
            return;
        }
        StartCoroutine(LoadTimer(data));

    }
    IEnumerator LoadTimer(SaveData saveData)
    {
        if (SceneManager.GetActiveScene().name != saveData.SceneName)
        {
            var OP = SceneManager.LoadSceneAsync(saveData.SceneName);
            while (!OP.isDone)
            {
                yield return null;
            }
            yield return null;
        }

        FindPlayer();
        Morality = saveData.MoralityScore;
        LastCheckpointID = saveData.LastCheckpointID;
        Money = saveData.Money;
        if (playerTrans != null)
        {
            playerTrans.position = new Vector3(saveData.px, saveData.py, saveData.pz);

        }
    }
    public void FindPlayer()
    {
        playerTrans = FindFirstObjectByType<UserControl>().transform;
    }
    public void SetCheckpoint(string lastCheckpoint)
    {
        LastCheckpointID = lastCheckpoint;
        SaveNow();
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
