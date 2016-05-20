using UnityEngine;

public class ShowOnHold : MonoBehaviour {

    public string buttonName;
    public GameObject toToggle;
    public GameObject toAntiToggle;
	// Use this for initialization
	void Start () {
        toToggle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown(buttonName))
        {
            toToggle.SetActive(true);
            toAntiToggle.SetActive(false);
        }
        if(Input.GetButtonUp(buttonName))
        {
            toToggle.SetActive(false);
            toAntiToggle.SetActive(true);
        }
	
	}
}
