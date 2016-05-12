using UnityEngine;
using System.Collections;

public class DeleteParent : MonoBehaviour {
    public GameObject parent;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Delete()
    {
        Destroy(parent);
    }
}