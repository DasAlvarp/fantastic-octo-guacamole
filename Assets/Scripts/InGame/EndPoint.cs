using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour {
    //default end of level
    void OnTriggerEnter(Collider col)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
