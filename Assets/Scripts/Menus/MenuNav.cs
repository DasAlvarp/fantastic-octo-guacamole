using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    // Supposed to be for global menu management. Not quite there yet.
    void Update()
    {
        if (Input.GetButtonDown("MenuBack"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}