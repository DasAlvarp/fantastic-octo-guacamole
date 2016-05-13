using UnityEngine;
using System.Collections;

public class CameraCTRL : MonoBehaviour
{

    public Transform thisGuy;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0; ;

    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("SpinUp") && !Input.GetButton("RotateLeft"))
        {
            thisGuy.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("CameraUp"), Input.GetAxis("Vertical")), Space.Self);
            thisGuy.transform.Rotate(new Vector3(0, Input.GetAxis("CamSpin")));
        }
    }
}
