using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class TextHolder : MonoBehaviour
{
    //This script is basically what makes MrUniverse actually useful.
    public string text;
    public int unlockedLevels;
    public int unlockedAreas;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Load();

        //only the first MrUniverse can exist.
        var others = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if(others.Length > 1)
            foreach (GameObject o in others)
            {
                if (o == gameObject)
                    Destroy(o.gameObject);
            }
    }

    //unlocks a level in campaign
    public void AddLevel(int area, int level)
    {
        if (area > unlockedAreas)
        {
            unlockedAreas = area;
            unlockedLevels = 1;
        }
        if(level > unlockedLevels && area <= unlockedAreas)
        {
            unlockedLevels = level;
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/unlocks.inf");

        LoadData datasave = new LoadData();
        datasave.levelUnlock = unlockedLevels;
        datasave.areaUnlock = unlockedAreas;
        bf.Serialize(file, datasave);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/unlocks.inf"))//make sure i can load that file.
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/unlocks.inf", FileMode.Open);
            LoadData data = (LoadData)bf.Deserialize(file);
            unlockedAreas = data.areaUnlock;
            unlockedLevels = data.levelUnlock;
            file.Close();
        }
    }
}

//save for player level unlocks
[Serializable]
class LoadData
{
    public int levelUnlock;
    public int areaUnlock;
}