using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public string HSPlayerName;
    public int highScore;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();

    }

    [System.Serializable]

    class SaveData
    {
        public string playerName;
        public string HSPlayerName;
        public int highScore;
        
    }

    public void SaveNameAndHighscore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.HSPlayerName = HSPlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            HSPlayerName = data.HSPlayerName;
            highScore = data.highScore;
            
        }
    }

}
