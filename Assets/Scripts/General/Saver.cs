using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

public class Saver : MonoBehaviour{

    public GameObject stage;

    public GameObject blankStage;
    public GameObject blankBlock;
    public GameObject blankButton;
    public GameObject blankExit;
    public GameObject character;


	// Use this for initialization
	void Start () {
	
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
        datasave.SaveStage(stage);
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
            GameObject center = (GameObject)Instantiate(blankStage, new Vector3(.5f,5.5f,.5f), Quaternion.identity);

            center.transform.localScale = data.ToVector3(data.centerScale);

            //getting block types
            if(data.blockNumbers.Count != 0)
                for (int x = 0; x < data.blockLocations.Count; x++)
                {
                    GameObject block = (GameObject)Instantiate(blankBlock, data.ToVector3((float[])data.blockLocations[x]), Quaternion.identity);
                    block.transform.SetParent(center.transform);
                    block.tag = (String)data.blockNumbers[x];
                }

            //getting button types
            if(data.buttonLocations.Count != 0)
                for (int x = 0; x < data.buttonLocations.Count; x++)
                {
                    GameObject button = (GameObject)Instantiate(blankButton, data.ToVector3((float[])data.buttonLocations[x]), Quaternion.identity);
                    button.transform.SetParent(center.transform);
                    button.tag = (String)data.buttonNumbers[x];
                }
            //set character
            GameObject player = (GameObject)Instantiate(character, data.ToVector3(data.charLoc), Quaternion.identity);
            player.transform.SetParent(center.transform);

            //set exit
            GameObject exit = (GameObject)Instantiate(blankExit, data.ToVector3(data.exitLoc), Quaternion.identity);
            exit.transform.SetParent(center.transform);

            file.Close();

        }
    }
}

//saving stuff
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


    //saves it. duh.
    public void SaveStage(GameObject stage)
    {
        buttonLocations = new ArrayList();
        buttonNumbers = new ArrayList();

        blockLocations = new ArrayList();
        blockNumbers = new ArrayList();
        

        //every child of stage.transform
        foreach (Transform block in stage.transform)
        {
            if(block.gameObject.tag == "Player")
            {
                charLoc = FromVector3(block.transform.position);
            }
            else if(block.gameObject.tag == "ExitCenter")
            {
                exitLoc = FromVector3(block.position);
            }
            else if(block.gameObject.name == "Block(Clone)")
            {
                blockLocations.Add(FromVector3(block.position));
                blockNumbers.Add(block.gameObject.tag);
            }
            else if(block.gameObject.name == "Button(Clone)")
            {
                buttonLocations.Add(FromVector3(block.position));
                buttonNumbers.Add(block.gameObject.tag);
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