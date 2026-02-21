using System;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    
    public static string GetPath(int slot)
    {

        return Path.Combine(Application.persistentDataPath, $"Save{slot}.json");
    }
    public static void Save(int slot, SaveData saveData)
    {
        try
        {
            string json = JsonUtility.ToJson(saveData,true);
            File.WriteAllText(GetPath(slot), json);
        }
        catch(Exception error)
        {
            Debug.Log($"Save failed: {error.Message}");
        }
    }
    public static bool TryLoad(int slot, out SaveData saveData)
    {
        saveData = null;
        string path = GetPath(slot);
        if (!File.Exists(path))
        {
            return false;
        }
        try
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
            return saveData != null;
        }
        catch(Exception error)
        {
            Debug.LogError($"Load Failed: {error.Message}");
            return false;
        }
    }
    public static void DeleteSave(int slot)
    {
        string path = GetPath(slot);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
    public static bool IsSaving(int slot)
    {
        string path = GetPath(slot);
        if (File.Exists(path))
        {
            return true;
        }
        return false;
    }
}

[Serializable]
public class SaveData
{
    public string SceneName;
    public float px,py,pz;
    public int MoralityScore;
    public int Money;
    public string LastCheckpointID;
    public long SaveTime;
}
