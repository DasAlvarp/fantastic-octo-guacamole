using UnityEngine;
using System.Collections;

public class Adjacents : MonoBehaviour {

    public GameObject[] adjacents = new GameObject[4];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //adjacent faces.
    public GameObject[] GetAdjacents()
    {
        return adjacents;
    }
}
