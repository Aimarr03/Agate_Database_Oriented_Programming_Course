using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinaryProgressLevelManager : MonoBehaviour
{
    private string _dirPath = "Data Progress Level";
    private string _textFile = "PlayerCurrentProgress.sav";

    private ProgressLevel _PlayerProgressLevel = new ProgressLevel();

    private void Awake()
    {
        Load();
    }

    public void Load()
    {
        LoadData();
    }

    public void Save()
    {
        SaveData();
    }
    public ProgressLevel GetPlayerProgressLevel()
    {
        return _PlayerProgressLevel;
    }
    private void LoadData()
    {
        string directoryPath = Path.Combine(Application.persistentDataPath, _dirPath);
        string filePath = Path.Combine(directoryPath, _textFile);

        if (File.Exists(filePath))
        {
            try
            {
                BinaryFormatter _binaryFormatter = new BinaryFormatter();
                using (FileStream _dataFile = new FileStream(filePath, FileMode.Open))
                {
                    ProgressLevel progressLevel = _binaryFormatter.Deserialize(_dataFile) as ProgressLevel;
                    if (progressLevel != null)
                    {
                        _PlayerProgressLevel = progressLevel;
                        Debug.Log("Progress loaded");
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error loading progress: " + e.Message);
            }
        }
        else
        {
            Directory.CreateDirectory(directoryPath);
            _PlayerProgressLevel.levelPackProgress.Add("Level Pack A", 0);
            SaveData(); // Create a new save file if it doesn't exist
        }
    }

    private void SaveData()
    {
        string directoryPath = Path.Combine(Application.persistentDataPath, _dirPath);
        string filePath = Path.Combine(directoryPath, _textFile);

        try
        {
            BinaryFormatter _binaryFormatter = new BinaryFormatter();
            using (FileStream _dataFile = new FileStream(filePath, FileMode.Create))
            {
                _binaryFormatter.Serialize(_dataFile, _PlayerProgressLevel);
                Debug.Log("Progress saved");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error saving progress: " + e.Message);
        }
    }
}
