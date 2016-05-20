using UnityEngine;

public class GoTo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //manages game state.

    public void GoToStage()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void GoToStage(string level)
    {
        Application.LoadLevel(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}