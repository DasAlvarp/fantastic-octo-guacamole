using UnityEngine;
using System.Collections;

public class Placer : MonoBehaviour {
    public GameObject cubeBlock;
    public GameObject wireMan;
    public int maxBlockTypes;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
        DoThings();
        
	}

    void DoThings()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit inFront;
        if (Physics.Raycast(transform.position, forward, out inFront, 200, 31))
        {
            if (Input.GetButtonDown("SpinDown"))
                PlaceBlock(cubeBlock);
            if (Input.GetButtonDown("SpinRight"))
                DeleteBlock(inFront);
            PlaceWire(inFront);

        }
    }

    //places wirefraem block
    void PlaceWire(RaycastHit ray)
    {
        Vector3 pos = SetProperValues(ray.collider.transform.position);
        for (int x = 0; x < maxBlockTypes; x++)
        {
            if (ray.collider.gameObject.tag == "block " + x)
            {
                pos = SetProperValues(ray.collider.transform.position) + ray.collider.gameObject.GetComponent<PlaneDirection>().GetDirection();
            }
        }
        Instantiate(wireMan, pos, Quaternion.identity);

    }

    //places a block where the wireframe block is
    void PlaceBlock(GameObject block)
    {

        Vector3 pos = GameObject.FindGameObjectWithTag("WireBlock").transform.position;
        for (int x = 0; x < maxBlockTypes; x++)
        {
            GameObject[] otherStuff = GameObject.FindGameObjectsWithTag("block " + x);
            for (int y = 0; y < otherStuff.Length; y++)
            {

                if(otherStuff[y].transform.position == pos)
                {
                    return;
                }
            }

        }
        Instantiate(block, pos, Quaternion.identity);
    }


    Vector3 SetProperValues(Vector3 pos)
    {
        pos.x = Mathf.Floor(pos.x) + 0;
        pos.y = Mathf.Floor(pos.y) + 0;
        pos.z = Mathf.Floor(pos.z) + 0;
        return pos;
    }

    void DeleteBlock(RaycastHit other)
    {
        for(int x = 0; x < maxBlockTypes; x++)
        {
            if (other.collider.gameObject.tag == "block " + x)
            {

                other.collider.gameObject.GetComponent<DeleteParent>().Delete();
            }
        }
    }
}
