using UnityEngine;
using System.Collections;

public class ShowOnHold : MonoBehaviour {

    public string buttonName;
    public GameObject toToggle;
	// Use this for initialization
	void Start () {
        toToggle.active = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown(buttonName))
        {
            toToggle.active = true;
        }
        if(Input.GetButtonUp(buttonName))
        {
            toToggle.active = false;
        }
	
	}
}
