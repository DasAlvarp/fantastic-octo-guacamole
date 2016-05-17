using UnityEngine;
using System.Collections;

public class OnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Saver>().Load();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
