using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    public GameObject stage;
    public Text text;

	//loads level that's been edited.
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Start"))
        {
            if(GameObject.FindGameObjectWithTag("ExitCenter") &&  GameObject.FindGameObjectWithTag("Player"))
            {
                stage = GameObject.Find("Stage(Clone)");

                text.text = "";

                GameObject.Find("MrUniverse").GetComponent<TextHolder>().text = stage.GetComponent<Saver>().Save();
                SceneManager.LoadScene("LoadStage");
            }
            else
            {
                text.text = "The scene is missing either a player or an exit point.";
            }
        }
	}
}