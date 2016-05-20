using UnityEngine;

public class ResumeScript : MonoBehaviour {

    public Canvas bigBoss;
	// Use this for initialization
	public void OnPress () {
        Time.timeScale = 1;
        bigBoss.enabled = false;	
	}
}
