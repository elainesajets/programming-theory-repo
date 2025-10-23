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
        if (!File.Exists(PathStr)) return null;
        return JsonUtility.FromJson<SaveData>(File.ReadAllText(PathStr));
    }
}
