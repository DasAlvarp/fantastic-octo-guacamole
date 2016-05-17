using UnityEngine;
using System.Collections;

public class RadialMenuAndHold : MonoBehaviour {

    // Use this for initialization
    public GameObject otherThing;
    public GameObject selector;
    public int value;
	void Start () {
        otherThing.active = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("SpinUp") || Input.GetKeyDown("q"))
        {
            otherThing.active = true;
        }
        else if(Input.GetButtonUp("SpinUp") || Input.GetKeyUp("q"))
        {
            value = GetEigth();
            otherThing.active = false;
        }
        if(otherThing.active)
        {
            int pos = GetEigth();
            selector.transform.rotation = Quaternion.identity;
            selector.transform.Rotate(0, 0, Mathf.Rad2Deg*((5 + pos) * Mathf.PI / 4 + Mathf.PI));
        }
	}

    int GetEigth()
    {
        float rad = Mathf.Atan2(Input.GetAxis("Vertical") - Input.GetAxis("CamRotUp") / 2, Input.GetAxis("CamSpin") / 2 + Input.GetAxis("Horizontal"));
        rad += Mathf.PI;
        rad *= 4 / Mathf.PI;
        return Mathf.FloorToInt(rad) - 5;
    }
}
