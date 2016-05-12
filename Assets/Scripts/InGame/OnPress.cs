using UnityEngine;
using System.Collections;

public class OnPress : MonoBehaviour {
    bool pressed = false;

    public GameObject[] blocks;
    public int blockNumber;

    // Use this for initialization
    void Start () {
        blocks = GameObject.FindGameObjectsWithTag("block " + blockNumber);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter(Collider col)
    {
        if(!pressed)
            if(col.gameObject.tag == "Player")
            {
                pressed = true;
                foreach(GameObject block in blocks)
                {
                    if(block.activeSelf)
                    {
                        block.SetActive(false);
                    }
                    else
                    {
                        block.SetActive(true);
                    }
                }
            }
    }
}
