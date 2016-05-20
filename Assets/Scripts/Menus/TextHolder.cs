using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

public class TextHolder : MonoBehaviour {
    public string text;
    public int unlockedLevels;
    public int unlockedAreas;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
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
            file.Close();
        }
    }

}

[Serializable]
class LoadData
{
    public int levelUnlock;
    public int areaUnlock;
}
