using UnityEngine;
using System.Collections;

public class GoToGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Start"))
        {
            Application.LoadLevel("LoadStage");
        }
	}
}
