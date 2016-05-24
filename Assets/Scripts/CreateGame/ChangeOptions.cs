using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeOptions : MonoBehaviour {
    public GameObject selectionMenu;
	
	// Update is called once per frame
	void Update () {
        //this is horible and messy and needts to be fixed at some point.
        if (SceneManager.GetActiveScene().name == "LevelEdit")
        {
            if (gameObject.tag.Substring(0,5) == "block")
            {
                selectionMenu.GetComponent<SetText>().TextIt(gameObject.tag);
                ArrayList walls = new ArrayList();
                //saving walls of block
                foreach (Transform wall in gameObject.transform.GetComponentsInChildren<Transform>())
                {
                    walls.Add(wall);
                }

                //if one block wall's channel is changed, all block wall channels should be changed. Disappear after input given.
                if (Input.GetAxis("DpadDown") == -1)
                {
                    gameObject.tag = "block 31";
                    foreach (Transform wall in walls)
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
                    foreach (Transform wall in walls)
                    {
                        wall.tag = gameObject.tag;

                    }
                    Disappear();
                }
            }
            else if (gameObject.tag == "Lever")
            {
                selectionMenu.GetComponent<SetText>().TextIt(gameObject.GetComponent<OnToggle>().toggleTag);

                //if one block wall's channel is changed, all block wall channels should be changed. Disappear after input given.
                if (Input.GetAxis("DpadDown") == -1)
                {
                    gameObject.GetComponent<OnToggle>().toggleTag = "block 3";
                  
                    Disappear();
                }
                else if (Input.GetAxis("DpadDown") == 1)
                {
                    gameObject.GetComponent<OnToggle>().toggleTag = "block 1";
                    Disappear();
                }

                if (Input.GetAxis("DpadLeft") == -1)
                {
                    gameObject.GetComponent<OnToggle>().toggleTag = "block 0";
                    Disappear();
                }
                else if (Input.GetAxis("DpadLeft") == 1)
                {
                    gameObject.GetComponent<OnToggle>().toggleTag = "block 2";
                    Disappear();
                }
            }

        }

    }

    //menu for block channel
    public void Edit()
    {
        selectionMenu.SetActive(true);
    }

    public void Disappear()
    {
        selectionMenu.SetActive(false);
    }
}
