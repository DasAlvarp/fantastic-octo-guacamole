using UnityEngine;
using UnityEngine.UI;

public class CharacterAnimator : MonoBehaviour
{
    //script for controlling character. Not sure if I want to use it tho.
    public Image wheel;
    public Image body;
    public Image head;
    public Image booster;

    public bool jumping;
    public bool walking;
    float angle = 0;
    float dAngle = .3f;


    // Use this for initialization
    void Start ()
    {
        jumping = false; ;
        walking = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Jump();
        Walk();
	}



    void Jump()
    {
        if(!jumping)
        {
            booster.transform.localPosition =  new Vector3(0,20,0);
        }
        else
        {
            booster.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    void Walk()
    {
        if (angle > 5)
        {
            dAngle = -.3f;
        }
        else if (angle < -5)
        {
            dAngle = .3f;
        }
        angle += dAngle;
        head.transform.Rotate(0,0, dAngle);
    }
}