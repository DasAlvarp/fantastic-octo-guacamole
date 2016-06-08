using UnityEngine;
using UnityEngine.UI;

public class SwitchOnJoystick : MonoBehaviour
{
    public Sprite controller;
    public Sprite keyboard;
    public Image setme;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetJoystickNames().Length > 0 &&  Input.GetJoystickNames()[0] != "")
        {
            setme.sprite = controller;
        }
        else
        {
            setme.sprite = keyboard;
        }
	}
}