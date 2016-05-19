using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResumeScript : MonoBehaviour {

    public Canvas bigBoss;
	// Use this for initialization
	public void OnPress () {
        Time.timeScale = 1;
        bigBoss.enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
