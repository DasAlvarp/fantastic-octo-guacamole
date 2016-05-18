using UnityEngine;
using System.Collections;

public class OnStart : MonoBehaviour {
    //place for "global global" variables

    // Use this for initialization
    public GameObject stage;
    public GameObject camCont;
    public string level;
    
    void Start () {
        print(level);

        level = GameObject.Find("MrUniverse").GetComponent<TextHolder>().text;
        print(level);
        if (level == "")
        {
            stage.GetComponent<Saver>().Load();
        }
        else
        {
            stage.GetComponent<Saver>().Load(level);
        }
        camCont.GetComponent<CameraBoss>().character = GameObject.FindGameObjectWithTag("Player").transform;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
