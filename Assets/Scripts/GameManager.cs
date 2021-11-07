using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string playerName;
    

    public int highScore {get; private set;}
    
    public string highScorePlayerName {get; private set;}
    
    public void SetNewHighScore(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            highScorePlayerName = playerName;
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);        

        LoadSaveData();
    }    

    public void OnDestroy()
    {
        Exit();
    }
     public void Exit()
    {

        //ager.instance.SaveColor();
        SaveData();
    }
    
    public void LoadSaveData()
    {
        string path = Path.Combine(Application.persistentDataPath,"saveFile.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorePlayerName = data.highScorePlayerName;
        }
        else
        {
            highScore = 0;
            highScorePlayerName = "Nobody";
        }

    }

    public void SaveData()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScorePlayerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Path.Combine(Application.persistentDataPath,"saveFile.json"),json);
    }


}
