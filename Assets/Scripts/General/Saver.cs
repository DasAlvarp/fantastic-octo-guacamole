using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

//class for saving levels.
public class Saver : MonoBehaviour
{
    //info for rebuilding stage.
    public GameObject stage;

    public GameObject blankStage;
    public GameObject blankBlock;
    public GameObject blankButton;
    public GameObject blankExit;
    public GameObject character;
    public GameObject blankLever;
    public GameObject blankSpike;


    //default save, saves on last number.
    public string Save()
    {
        int x = 0;
        for (x = 0; File.Exists(Application.persistentDataPath + "/" + x + ".dat"); x++)
        {//count thru all stages
        }
        return Save("" + (x));
    }

    //saves stuff
    public string Save(string name)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + name + ".dat");

        LevelData datasave = new LevelData();
        datasave.SaveStage(stage);
        bf.Serialize(file, datasave);
        file.Close();
        return name;
    }

    //loads = conversts stage load to file
    public void Load()
    {
        int x = 0;
        for(x = 0; File.Exists(Application.persistentDataPath + "/" + x + ".dat"); x++)
        {
        }
        Load((x) + "");
    }

    public void Load(string name)
    {
        if(File.Exists(Application.persistentDataPath + "/" + name + ".dat"))//make sure i can load that file.
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + name + ".dat", FileMode.Open);
            LevelData data = (LevelData)bf.Deserialize(file);

            //set center properly
            GameObject center = (GameObject)Instantiate(blankStage, data.ToVector3(data.centerLoc), Quaternion.identity);
            //default start location for stage
            center.transform.localScale = data.ToVector3(data.centerScale);

            //getting block types
            if(data.blockNumbers.Count != 0)
                for (int x = 0; x < data.blockLocations.Count; x++)
                {
                    GameObject block = (GameObject)Instantiate(blankBlock, data.ToVector3((float[])data.blockLocations[x]), Quaternion.identity);
                    block.transform.SetParent(center.transform);
                    block.tag = (string)data.blockNumbers[x];
                }

            //getting button types
            if(data.buttonLocations.Count != 0)
                for (int x = 0; x < data.buttonLocations.Count; x++)
                {
                    GameObject button = (GameObject)Instantiate(blankButton, data.ToVector3((float[])data.buttonLocations[x]), Quaternion.identity);
                    button.transform.SetParent(center.transform);
                    button.tag = (string)data.buttonNumbers[x];
                }

            //loading levers
            if (data.leverNumbers.Count != 0)
                for (int x = 0; x < data.leverNumbers.Count; x++)
                {
                    GameObject lever = (GameObject)Instantiate(blankLever, data.ToVector3((float[])data.leverLocations[x]), Quaternion.identity);
                    lever.transform.SetParent(center.transform);
                    lever.GetComponent<OnToggle>().toggleTag = (string)data.leverNumbers[x];
                }

            //place dem spikes
            if(data.spikeNumbers.Count != 0)
            {
                for(int x = 0; x < data.spikeNumbers.Count; x ++)
                {
                    GameObject spike = (GameObject)Instantiate(blankSpike, data.ToVector3((float[])data.spikeLocations[x]), Quaternion.identity);
                    spike.transform.SetParent(center.transform);
                    spike.tag = (string)data.spikeNumbers[x];
                }
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
    public float[] centerLoc;
    public float[] charLoc;
    public float[] exitLoc;

    public ArrayList buttonLocations;
    public ArrayList buttonNumbers;

    public ArrayList blockLocations;
    public ArrayList blockNumbers;

    public ArrayList leverLocations;
    public ArrayList leverNumbers;

    public ArrayList spikeLocations;
    public ArrayList spikeNumbers;


    //saves it. duh.
    public void SaveStage(GameObject stage)
    {
        buttonLocations = new ArrayList();
        buttonNumbers = new ArrayList();

        blockLocations = new ArrayList();
        blockNumbers = new ArrayList();

        leverLocations = new ArrayList();
        leverNumbers = new ArrayList();

        spikeLocations = new ArrayList();
        spikeNumbers = new ArrayList();

        exitLoc = new float[]{ 0f,0f,0f};
        charLoc = new float[] { 0f, 0f, 0f };

        //every child of stage.transform
        //saves and conversion.
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
                blockNumbers.Add(block.tag);
            }
            else if(block.gameObject.name == "Button(Clone)")
            {
                buttonLocations.Add(FromVector3(block.position));
                buttonNumbers.Add(block.tag);
            }
            else if(block.gameObject.tag == "Lever")
            {
                leverLocations.Add(FromVector3(block.position));
                leverNumbers.Add("" + block.GetComponent<OnToggle>().toggleTag);
            }
            else if(block.gameObject.name == "Spike(Clone)")
            {
                spikeLocations.Add(FromVector3(block.position));
                spikeNumbers.Add(block.tag);
            }
        }
        centerScale = FromVector3(stage.transform.localScale);
        centerLoc = FromVector3(stage.transform.position);
    } 

    //converting these things back and forth.
    float[] FromVector3(Vector3 vectahr)
    {
        return new float[3] { vectahr.x, vectahr.y, vectahr.z };
    }

    public Vector3 ToVector3(float[] vector)
    {
        return new Vector3(vector[0], vector[1], vector[2]);
    }
}