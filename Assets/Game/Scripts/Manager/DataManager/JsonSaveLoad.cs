using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class JsonSaveLoad : SingleTon<JsonSaveLoad>
{
    public static JsonSaveLoad Instance;
    public int cointsJson;
    private string path = "/Game/Resources/Data/StreamingAssets";


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        DataGame data = new DataGame();
        data.coints = cointsJson;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + path, json);
    }

    public void LoadData()
    {
        if (File.Exists(Application.dataPath + path))
        {
            string json = File.ReadAllText(Application.dataPath + path);
            DataGame data = JsonUtility.FromJson<DataGame>(json);
            cointsJson = data.coints; 
        }
    }
}