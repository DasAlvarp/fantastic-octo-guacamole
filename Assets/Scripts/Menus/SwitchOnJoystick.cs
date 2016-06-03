using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchOnJoystick : MonoBehaviour
{
    public Sprite controller;
    public Sprite keyboard;
    public Image setme;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if(Input.GetJoystickNames()[0] != "")
        {
            setme.sprite = controller;
        }
        else
        {
            setme.sprite = keyboard;
        }
	}
}
