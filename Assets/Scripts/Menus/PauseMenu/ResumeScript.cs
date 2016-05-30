using UnityEngine;

public class ResumeScript : MonoBehaviour
{
    public Canvas bigBoss;

	// Unpauses
	public void OnPress ()
    {
        Time.timeScale = 1;
        bigBoss.enabled = false;	
	}
}
