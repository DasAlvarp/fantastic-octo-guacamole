using UnityEngine;

public class Unique : MonoBehaviour
{
	// Use this for initialization
    //deletes every other object with the same tag.
	void Start ()
    {
        var others = GameObject.FindGameObjectsWithTag(gameObject.tag);
        foreach (GameObject o in others)
        {
            if(o != gameObject)
                Destroy(o.gameObject);
        }
    }
}