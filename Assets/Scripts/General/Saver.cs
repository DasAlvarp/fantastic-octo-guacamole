using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

public class Saver : MonoBehaviour{

    public GameObject stage;
    public int maxBlockNum;


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
        datasave.SaveStage(stage, maxBlockNum);
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
    public Vector3 centerScale;
    public Vector3 charLocation;
    public Vector3 exitLocation;

    public ArrayList buttonLocations;
    public ArrayList buttonNumbers;

    public ArrayList blockLocations;
    public ArrayList blockNumbers;

    public GameObject center;
    public void SaveStage(GameObject stage, int maxBlock)
    {
        buttonLocations = new ArrayList();
        buttonNumbers = new ArrayList();

        blockLocations = new ArrayList();
        blockNumbers = new ArrayList();

        centerScale = stage.transform.localScale;
        foreach (GameObject block in stage.transform)
        {
            if(block.tag == "Player")
            {
                charLocation = block.transform.position;
            }
            else if(block.tag == "ExitCenter")
            {
                exitLocation = block.transform.position;
            }
            for(int x = 0; x < maxBlock; x++)
            {
                if (block.tag == "block") ;

            }
        }
    } 

}