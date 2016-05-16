using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Saver : MonoBehaviour{

    public GameObject stage;


	// Use this for initialization
	void Start () {
        stage = new GameObject();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //saves stuff
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/stageToLoad.dat");

        LevelData datasave = new LevelData();
        datasave.center = stage;
        bf.Serialize(file, datasave);
        file.Close();

    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "stageToLoad.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "stageToLoad.dat", FileMode.Open);
            LevelData data = (LevelData)bf.Deserialize(file);
            file.Close();

            stage = data.center;
        }
    }
}

[Serializable]
class LevelData
{
    public GameObject center;
}