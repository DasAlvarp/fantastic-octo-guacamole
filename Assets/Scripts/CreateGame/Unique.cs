using UnityEngine;
using System.Collections;

public class Unique : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] others = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if(others.Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
