using UnityEngine;
using System.Collections;

public class CameraBoss : MonoBehaviour {
    public Transform thisGuy;
    public Transform character;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        thisGuy.position = new Vector3(thisGuy.position.x, thisGuy.position.y, character.position.z - 1);
	
	}
}
