using UnityEngine;
using System.Collections;

public class OnStart : MonoBehaviour {
    // Use this for initialization
    public GameObject stage;
    public GameObject camCont;
    void Start () {
        stage.GetComponent<Saver>().Load();
        camCont.GetComponent<CameraBoss>().thisGuy = stage.GetComponent<Saver>().character.transform;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
