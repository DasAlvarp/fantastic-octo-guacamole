﻿using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

public class Saver : MonoBehaviour{

    public GameObject stage;
    public int maxBlockNum;

    public GameObject blankStage;
    public GameObject blankBlock;
    public GameObject blankButton;
    public GameObject blankExit;
    public GameObject character;


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
        if(File.Exists(Application.persistentDataPath + "/stageToLoad.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/stageToLoad.dat", FileMode.Open);
            LevelData data = (LevelData)bf.Deserialize(file);

            //set center properly
            GameObject center = (GameObject)Instantiate(blankStage, data.ToVector3(data.centerScale), Quaternion.identity);

            //set character
            GameObject player = (GameObject)Instantiate(character, data.ToVector3(data.charLoc), Quaternion.identity);
            player.transform.SetParent(center.transform);

            //set exit
            GameObject exit = (GameObject)Instantiate(blankExit, data.ToVector3(data.exitLoc), Quaternion.identity);
            exit.transform.SetParent(center.transform);

            //getting block types
            for(int x = 0; x < data.blockLocations.Count; x++)
            {
                GameObject block = (GameObject)Instantiate(blankBlock, (Vector3)data.blockLocations[x], Quaternion.identity);
                block.transform.SetParent(center.transform);
                block.tag = (String)data.blockNumbers[x];
            }

            //getting button types
            for (int x = 0; x < data.blockLocations.Count; x++)
            {
                GameObject button = (GameObject)Instantiate(blankButton, (Vector3)data.buttonLocations[x], Quaternion.identity);
                button.transform.SetParent(center.transform);
                button.tag = (String)data.buttonNumbers[x];
            }

            file.Close();

        }
    }
}

[Serializable]
class LevelData
{
    public float[] centerScale;
    public float[] charLoc;
    public float[] exitLoc;

    public ArrayList buttonLocations;
    public ArrayList buttonNumbers;

    public ArrayList blockLocations;
    public ArrayList blockNumbers;

    public void SaveStage(GameObject stage, int maxBlock)
    {
        buttonLocations = new ArrayList();
        buttonNumbers = new ArrayList();

        blockLocations = new ArrayList();
        blockNumbers = new ArrayList();

        foreach (GameObject block in stage.transform)
        {
            if(block.tag == "Player")
            {
                charLoc = FromVector3(block.transform.position);
            }
            else if(block.tag == "ExitCenter")
            {
                exitLoc = FromVector3(block.transform.position);
            }
            else if(block.name == "Block(Clone)")
            {
                blockLocations.Add(block.transform.position);
                blockNumbers.Add(block.tag);
            }
            else if(block.name == "Button(Clone)")
            {
                buttonLocations.Add(block.transform.position);
                buttonNumbers.Add(block.tag);
            }
        }
        centerScale = FromVector3(stage.transform.localScale);
    } 

    float[] FromVector3(Vector3 vectahr)
    {
        return new float[3] { vectahr.x, vectahr.y, vectahr.z };
    }

    public Vector3 ToVector3(float[] vector)
    {
        return new Vector3(vector[0], vector[1], vector[2]);
    }

}