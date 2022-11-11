using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public static class SavingSystem<T> where T : new()
{
    private static string savePath = Path.Combine(Application.persistentDataPath, $"{typeof(T)}");

    public static void SaveJsonData(T gameData)
    {
        string jsonData = JsonConvert.SerializeObject(gameData);
        File.WriteAllText(savePath, jsonData);
    }
    public static void SaveJsonData(T gameData, string path)
    {
        string jsonData = JsonConvert.SerializeObject(gameData);
        File.WriteAllText(path, jsonData);
    }

    public static void SaveJsonDataNullable(T gameData)
    {
        string jsonData = JsonConvert.SerializeObject(gameData, Formatting.Indented,
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        File.WriteAllText(savePath, jsonData);
    }

    public static T LoadJsonData()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            Debug.Log($"Loaded: {jsonData}");
            T gameData = JsonConvert.DeserializeObject<T>(jsonData);
            if (gameData == null)
            {
                return new T();
            }
            return gameData;
        }
        else
        {
            Debug.Log("No save data to load");
            return new T();
        }
    }
    public static T LoadJsonData(string path)
    {
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            T gameData = JsonConvert.DeserializeObject<T>(jsonData);
            if (gameData == null)
            {
                return new T();
            }
            return gameData;
        }
        else
        {
            Debug.Log("No save data to load");
            return new T();
        }
    }
}

public static class SavingSystemExtension
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Aspid Games/Clear Saves")]
    public static void DeleteAllSaves()
    {
        var folder = new DirectoryInfo(Application.persistentDataPath);

        foreach (FileInfo file in folder.GetFiles())
        {
            file.Delete();
        }
    }
#endif
}