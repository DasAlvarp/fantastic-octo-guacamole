using UnityEngine;

public class RadialMenuAndHold : MonoBehaviour {

    // Use this for initialization
    public GameObject otherThing;
    public GameObject selector;
    public int value;

	void Start ()
    {
        otherThing.SetActive(false);
	}
	
	// tests radial menus and stuff.
	void Update () {
        //otherTHing = inverted toggle
        if(Input.GetButtonDown("SpinUp") || Input.GetKeyDown("q"))
        {
            otherThing.SetActive(true);
        }
        else if(Input.GetButtonUp("SpinUp") || Input.GetKeyUp("q"))
        {
            value = GetEigth();
            otherThing.SetActive(false);
        }
        if(otherThing.activeInHierarchy)
        {
            int pos = GetEigth();
            selector.transform.rotation = Quaternion.identity;
            selector.transform.Rotate(0, 0, Mathf.Rad2Deg*((5 + pos) * Mathf.PI / 4 + Mathf.PI));
        }
	}

    int GetEigth()
    {
        //get eight that joystick is on. Mouse doesn't really work.
        float rad = Mathf.Atan2(Input.GetAxis("Vertical") - Input.GetAxis("CamRotUp") / 2, Input.GetAxis("CamSpin") / 2 + Input.GetAxis("Horizontal"));
        rad += Mathf.PI;
        rad *= 4 / Mathf.PI;
        return Mathf.FloorToInt(rad) - 5;
    }
}
