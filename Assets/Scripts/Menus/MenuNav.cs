using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetButtonDown("MenuBack"))
        {
            SceneManager.LoadScene("MainMenu");
        }
	}
}
