using UnityEngine;
using System.Collections;

public class DpadConversion : MonoBehaviour {
    public DpadConversion()
    {

    }

    int dpadUpState = 0;
    int dpadSideState = 0;

    //press variables
    public bool up = false;
    public bool down = false;
    public bool left = false;
    public bool right = false;

    public int upPress = 0;
    public int sidePress = 0;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
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
    }


}
