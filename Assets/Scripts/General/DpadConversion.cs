using UnityEngine;

public class DpadConversion : MonoBehaviour
{
    //so you can have multiple instances
    public DpadConversion(){    }

    public float vert;
    int dpadUpState = 0;
    int dpadSideState = 0;

    int joyUpState = 0;
    int joySideState = 0;

    //press variables
    public bool up = false;
    public bool down = false;
    public bool left = false;
    public bool right = false;

    public int upPress = 0;
    public int sidePress = 0;

    // Converts d-pad axises into button-type inputs.
    void Update()
    {
        // reset EVERYTHING
        upPress = 0;
        sidePress = 0;
        Reset();


        //joystick control part

        if (Mathf.RoundToInt(Input.GetAxis("Vertical")) != joyUpState)
        {
            print("Triggered");
            joyUpState = Mathf.RoundToInt(Input.GetAxis("Vertical"));
            if (joyUpState == 1)
            {
                up = true;
            }
            else if (joyUpState == -1)
            {
                down = true;
            }
            upPress = joyUpState;
        }
        if (Mathf.RoundToInt(Input.GetAxis("Horizontal")) != joySideState)
        {
            joySideState = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
            if (joySideState == 1)
            {
                right = true;
            }
            else if (joySideState == -1)
            {
                left = true;
            }
            sidePress = joySideState;
        }

        //Dpad control part
        if (!Continue(up, down, left, right))
        {
            if (Input.GetAxis("DpadDown") != dpadUpState)
            {
                dpadUpState = (int)(Input.GetAxis("DpadDown"));
                if (dpadUpState == 1)
                {
                    up = true;
                }
                else if (dpadUpState == -1)
                {
                    down = true;
                }
                upPress = dpadUpState;
            }
            if (Input.GetAxis("DpadLeft") != dpadSideState)
            {
                dpadSideState = (int)Input.GetAxis("DpadLeft");
                if (dpadSideState == 1)
                {
                    right = true;
                }
                else if (dpadSideState == -1)
                {
                    left = true;
                }
                sidePress = dpadSideState;
            }
        }

        //keyboard control part
        if (!Continue(up, down, left, right))
        {

            if (Input.GetKeyDown("up"))
            {
                down = false;
                up = true;
                upPress = 1;
            }
            else if (Input.GetKeyDown("down"))
            {
                up = false;
                down = true;
                upPress = -1;
            }
            if (Input.GetKeyDown("left"))
            {
                right = false;
                left = true;
                sidePress = -1;
            }
            else if (Input.GetKeyDown("right"))
            {
                left = false;
                right = true;
                sidePress = 1;
            }
        }
    }

    bool Continue(params bool[] args )
    {
        foreach(bool arg in args)
        {
            if (arg)
            {
                return true;
            }
        }
        return false;
    }

    public void Reset()
    {
        right = false;
        left = false;
        up = false;
        down = false;
    }
}
