using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public LevelData[] levels;

    void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }
        LoadGame();
    }


    public LevelData GetSelectedLevel() {
        LevelData currentData;
        for (int i = 0; i < levels.Length; i++) {
            if (levels[i].GetLevelSelect()) {
                int curLevel = i;
                return levels[curLevel];
            }
        }
        return currentData = new LevelData();
    }

    [System.Serializable]
    public class Save
    {
          public List<bool> levelStatuses = new List<bool>();
    }

    Save CreateSave() {
        Save save = new Save();
        for (int i = 0; i < levels.Length; i++) {
            save.levelStatuses.Add(levels[i].isCompleted);
        }
        return save;
    }

    public  void SaveGame() {
        Save save = CreateSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/gamesave.save");

        bf.Serialize(file, save);
        file.Close();
    }

    public void LoadGame() {
        if (File.Exists(Application.dataPath + "/gamesave.save")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);

            file.Close();

            for (int i = 0; i < levels.Length; i++) {
                levels[i].isCompleted = save.levelStatuses[i];
            }
        }
        else {
            Debug.Log("No game saved!");
        }
    }
}
