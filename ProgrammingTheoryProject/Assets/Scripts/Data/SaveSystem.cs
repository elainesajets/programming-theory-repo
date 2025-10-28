using UnityEngine;
using System.IO;

public static class SaveSystem
{
    static string PathStr => Path.Combine(Application.persistentDataPath, "save.json");

    public static void Save(SaveData d)
    {
        var json = JsonUtility.ToJson(d);
        File.WriteAllText(PathStr, json);
    }

    public static SaveData Load()
    {
        if (!File.Exists(PathStr)) return new SaveData();
        return JsonUtility.FromJson<SaveData>(File.ReadAllText(PathStr));
    }

    public static void SaveName(string playerName)
    {
        SaveData data = Load() ?? new SaveData();
        data.playerName = playerName;
        Save(data);
    }

    // public static string LoadName()
    // {
    //     if (File.Exists(PathStr))
    //     {
    //         string json = File.ReadAllText(PathStr);
    //         SaveData data = JsonUtility.FromJson<SaveData>(json);
    //         return data.playerName;
    //     }
    //     return "";
    // }

    public static void DeleteSave()
    {
        if (File.Exists(PathStr))
        {
            File.Delete(PathStr);
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }
}
