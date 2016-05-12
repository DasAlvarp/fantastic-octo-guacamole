using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public GameObject thisGuy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Spin();

    }

    void Spin()
    {
        Vector3 rotateTo;
        if (Input.GetButtonUp("SpinLeft"))
        {
            rotateTo = new Vector3(0, 90, 0);
        }
        else if (Input.GetButtonUp("SpinRight"))
        {
            rotateTo = new Vector3(0, -90, 0);
        }
        else if (Input.GetButtonUp("SpinUp"))
        {
            rotateTo = new Vector3(-90, 0, 0);
        }
        else if (Input.GetButtonUp("SpinDown"))
        {
            rotateTo = new Vector3(90, 0, 0);
        }
        else if(Input.GetButtonUp("RotateRight"))
        {
            rotateTo = new Vector3(0, 0, 90);
        }
        else if (Input.GetButtonUp("RotateLeft"))
        {
            rotateTo = new Vector3(0, 0, -90);
        }
        else
        {
            rotateTo = new Vector3(0, 0, 0);
        }
        thisGuy.transform.Rotate(rotateTo, Space.World);
    }

    

}
