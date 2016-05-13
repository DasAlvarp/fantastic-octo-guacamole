using UnityEngine;
using System.Collections;

public class ChangeOptions : MonoBehaviour {

    public GameObject selectionMenu;
    int menuLevel = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        selectionMenu.GetComponent<SetText>().TextIt(gameObject.tag);

        if (Input.GetAxis("DpadDown") == -1)
        {
            gameObject.tag = "block 31";
            Disappear();
        }
        else if(Input.GetAxis("DpadDown") == 1)
        {
            gameObject.tag = "block 1";
            Disappear();
        }

        if (Input.GetAxis("DpadLeft") == -1)
        {
            gameObject.tag = "block 0";
            Disappear();
        }
        else if (Input.GetAxis("DpadLeft") == 1)
        {
            gameObject.tag = "block 2";
            Disappear();
        }

    }

    public void Edit()
    {
        selectionMenu.active = true;
        menuLevel = 0;

    }

    public void Disappear()
    {
        selectionMenu.active = false;
    }
}
