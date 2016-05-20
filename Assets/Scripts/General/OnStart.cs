using UnityEngine;

public class OnStart : MonoBehaviour
{
    //place for "global global" variables

    // Use this for initialization
    public GameObject stage;
    public GameObject camCont;
    public string level;

    //Specific loading thing.
    void Start()
    {
        level = GameObject.Find("MrUniverse").GetComponent<TextHolder>().text;
        if (level == "")
        {
            stage.GetComponent<Saver>().Load();
        }
        else
        {
            stage.GetComponent<Saver>().Load(level);
        }
        camCont.GetComponent<CameraBoss>().character = GameObject.FindGameObjectWithTag("Player").transform;
        camCont.GetComponent<CameraBoss>().stage = GameObject.Find("Stage(Clone)").transform;
        Time.timeScale = 1;
    }

}