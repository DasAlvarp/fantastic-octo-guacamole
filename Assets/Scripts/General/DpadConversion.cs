using UnityEngine;

public class DpadConversion : MonoBehaviour
{
    //so you can have multiple instances
    public DpadConversion(){    }

    int dpadUpState = 0;
    int dpadSideState = 0;

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
        upPress = 0;
        sidePress = 0;
        if (Input.GetAxis("DpadDown") != dpadUpState)
        {
            dpadUpState = (int)Input.GetAxis("DpadDown");
            up = false;
            down = false;
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
            left = false;
            right = false;
            if (dpadSideState == 1)
            {
                right = true;
            }
            else if (dpadSideState == -1)
            {
                right = true;
            }
            sidePress = dpadSideState;
        }
        if(Input.GetKeyDown("up"))
        {
            up = true;
            down = false;
            upPress = 1;
        }
        if (Input.GetKeyDown("down"))
        {
            up = false;
            down = true;
            upPress = -1;
        }
        if (Input.GetKeyDown("left"))
        {
            left = true;
            right = false;
            sidePress = -1;
        }
        if (Input.GetKeyDown("right"))
        {
            right = true;
            left = false;
            sidePress = 1;
        }
    }
}
