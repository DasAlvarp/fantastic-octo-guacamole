using UnityEngine;

public class GoToGame : MonoBehaviour {
    public GameObject stage;
    public GameObject typeThing;

	//loads level that's been edited.
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Start"))
        {
            GameObject.Find("MrUniverse").GetComponent<TextHolder>().text = stage.GetComponent<Saver>().Save();
            Application.LoadLevel("LoadStage");
        }
	}
}
