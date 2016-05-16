using UnityEngine;
using System.Collections;

public class Unique : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var others = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
        foreach (GameObject o in others)
        {
            if(o != this.gameObject)
                Destroy(o.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
      /*  GameObject[] others = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
        if(others.Length > 1)
        {
            Destroy(gameObject);
        }*/
    }


}
