using UnityEngine;

public class CameraCTRL : MonoBehaviour
{
    public Transform thisGuy;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //all sittuations for camera lock
        if (!Input.GetButton("SpinUp") && !Input.GetButton("RotateLeft") && !Input.GetKey("q"))
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("CameraUp"), Input.GetAxis("Vertical"));
            
            //hardcoding kbm input
            if (Input.GetKey("d"))
            {
                movement += new Vector3(.5f, 0, 0);
            }
            if(Input.GetKey("a"))
            {
                movement -= new Vector3(.5f, 0, 0);
            }
            if (Input.GetKey("w"))
            {
                movement += new Vector3(0,0,.5f);
            }
            if (Input.GetKey("s"))
            {
                movement -= new Vector3(0, 0, .5f);
            }
            if(Input.GetKey("left shift"))
            {
                movement -= new Vector3(0, .5f, 0);
            }
            if(Input.GetKey("space"))
            {
                movement += new Vector3(0, .5f, 0);
            }

            thisGuy.Translate(movement, Space.Self);
            thisGuy.transform.Rotate(new Vector3(0, Input.GetAxis("CamSpin")));
        }
        //lock/release camera
        if(Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(Input.GetKeyDown("mouse 0"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
