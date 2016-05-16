using UnityEngine;
using System.Collections;

public class Unique : MonoBehaviour {

	// Use this for initialization
    //deletes every other object with the same tag.
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

    }


}
