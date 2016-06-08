using UnityEngine;

public class TextTogglerJoystick : MonoBehaviour
{

    public Transform controller;
    public Transform keyboard;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetJoystickNames()[0] != "")
        {
            controller.gameObject.SetActive(true);
            keyboard.gameObject.SetActive(false);
        }
        else
        {
            controller.gameObject.SetActive(false);
            keyboard.gameObject.SetActive(true);
        }
    }
}