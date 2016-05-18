using UnityEngine;
using System.Collections;

public class GoToGame : MonoBehaviour {
    public GameObject stage;
    public GameObject typeThing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Start"))
        {
            stage.GetComponent<Saver>().Save();
            Application.LoadLevel("LoadStage");
        }
	}
}
