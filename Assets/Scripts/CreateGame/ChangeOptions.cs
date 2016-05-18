using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeOptions : MonoBehaviour {

    public GameObject selectionMenu;
    int menuLevel = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "LevelEdit")
        {
            selectionMenu.GetComponent<SetText>().TextIt(gameObject.tag);
            ArrayList walls = new ArrayList();
            //saving walls of block
            foreach(Transform wall in gameObject.transform.GetComponentsInChildren<Transform>())
            {
                walls.Add(wall);
            }
             
            //if one block wall's channel is changed, all block wall channels should be changed. Disappear after input given.
            if (Input.GetAxis("DpadDown") == -1)
            {
                gameObject.tag = "block 31";
                foreach(Transform wall in walls)
                {
                    wall.tag = gameObject.tag;
                }
                gameObject.transform.GetComponentInChildren<Transform>().gameObject.tag = "block 31";
                Disappear();
            }
            else if (Input.GetAxis("DpadDown") == 1)
            {
                gameObject.tag = "block 1";
                gameObject.transform.GetComponentInChildren<Transform>().gameObject.tag = "block 1";
                foreach (Transform wall in walls)
                {
                    wall.tag = gameObject.tag;

                }
                Disappear();
            }

            if (Input.GetAxis("DpadLeft") == -1)
            {
                gameObject.tag = "block 0";
                gameObject.transform.GetComponentInChildren<Transform>().gameObject.tag = "block 0";
                foreach (Transform wall in walls)
                {
                    wall.tag = gameObject.tag;

                }
                Disappear();
            }
            else if (Input.GetAxis("DpadLeft") == 1)
            {
                gameObject.tag = "block 2";
                gameObject.transform.GetComponentInChildren<Transform>().gameObject.tag = "block 2";
                foreach(Transform wall in walls)
                {
                    wall.tag = gameObject.tag;

                }
                Disappear();
            }
        }

    }

    //menu for block channel
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
