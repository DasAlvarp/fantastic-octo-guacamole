using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeOptions : MonoBehaviour
{
    public GameObject selectionMenu;
    GameObject selectInstance;

    public void Start()
    {
        enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //this is horible and messy and needts to be fixed at some point.
        if (SceneManager.GetActiveScene().name == "LevelEdit" || SceneManager.GetActiveScene().name == "LevelEditAfterLoad")
        {
            if (gameObject.tag.Substring(0,5) == "block")
            {
                //if one block wall's channel is changed, all block wall channels should be changed. Disappear after input given.
                if (Input.GetAxis("DpadDown") == -1 || Input.GetKey("down"))
                {
                    gameObject.tag = "block 31";
                    Disappear();
                }
                else if (Input.GetAxis("DpadDown") == 1 || Input.GetKey("up"))
                {
                    gameObject.tag = "block 1";
                    Disappear();
                }

                if (Input.GetAxis("DpadLeft") == -1 || Input.GetKey("left"))
                {
                    gameObject.tag = "block 0";
                    Disappear();
                }
                else if (Input.GetAxis("DpadLeft") == 1 || Input.GetKey("right"))
                {
                    gameObject.tag = "block 2";
                    Disappear();
                }
            }
            else if (gameObject.tag == "Lever")
            {
                selectionMenu.GetComponent<SetText>().TextIt(gameObject.GetComponent<OnToggle>().toggleTag);

                //if one block wall's channel is changed, all block wall channels should be changed. Disappear after input given.
                if (Input.GetAxis("DpadDown") == -1 || Input.GetKey("down"))
                {
                    gameObject.GetComponent<OnToggle>().toggleTag = "block 3";
                  
                    Disappear();
                }
                else if (Input.GetAxis("DpadDown") == 1 || Input.GetKey("up"))
                {
                    gameObject.GetComponent<OnToggle>().toggleTag = "block 1";
                    Disappear();
                }

                if (Input.GetAxis("DpadLeft") == -1 || Input.GetKey("left"))
                {
                    gameObject.GetComponent<OnToggle>().toggleTag = "block 0";
                    Disappear();
                }
                else if (Input.GetAxis("DpadLeft") == 1 || Input.GetKey("right"))
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
        selectInstance = Instantiate(selectionMenu);
        selectInstance.transform.SetParent(GameObject.Find("Canvas").transform);
        selectInstance.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        selectInstance.GetComponent<SetText>().TextIt(gameObject.tag);

    }

    public void Disappear()
    {
        DestroyObject(selectInstance);
        enabled = false;
    }
}
