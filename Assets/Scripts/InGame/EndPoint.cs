using UnityEngine;

public class EndPoint : MonoBehaviour {

    //default end of level
    void OnTriggerEnter(Collider col)
    {
        Application.LoadLevel("MainMenu");
    }
}
