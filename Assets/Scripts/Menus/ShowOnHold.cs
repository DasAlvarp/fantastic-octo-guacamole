using UnityEngine;

public class ShowOnHold : MonoBehaviour {

    public string buttonName;
    public GameObject toToggle;
    public GameObject toAntiToggle;
	// Use this for initialization
	void Start () {
        toToggle.active = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown(buttonName))
        {
            toToggle.active = true;
            toAntiToggle.active = false;
        }
        if(Input.GetButtonUp(buttonName))
        {
            toToggle.active = false;
            toAntiToggle.active = true;
        }
	
	}
}
