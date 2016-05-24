using UnityEngine;
using System.Collections;


public class Placer : MonoBehaviour {
    //way too big of a class to place things
    public GameObject cubeBlock;
    public GameObject button;
    public GameObject exit;
    public GameObject character;
    public GameObject lever;

    public GameObject selectedOption;

    public GameObject radialMenu;
    int selected;

    GameObject selectedObject;

    public GameObject wireMan;
    public int maxBlockTypes;
	// Use this for initialization
	void Start () {
        //init selections
        cubeBlock.GetComponent<ChangeOptions>().selectionMenu = selectedOption ;
        button.GetComponent<ChangeOptions>().selectionMenu = selectedOption;
        lever.GetComponent<ChangeOptions>().selectionMenu = selectedOption;
        
        selectedObject = cubeBlock;
    }
	
	// Update is called once per frame
	void Update () {
        //have to adjust camera up/down, but don't want it to affect movement, this script is conveniently attatched to the camera
        if (!Input.GetButton("SpinUp") && !Input.GetButton("RotateLeft") && !Input.GetKey("q"))
            transform.Rotate(new Vector3(Input.GetAxis("CamRotUp"), 0));

        //selected block type
        selected = radialMenu.GetComponent<RadialMenuAndHold>().value;
        selectedObject = SelectOptions(selected);

        //basically the update method here.
        DoThings();
	}

    //converts ints fron radial menu into selected blocks
    GameObject SelectOptions(int selections)
    {
        if(selections == -2)
        {
            return exit;
        }
        else if (selections == -3)
        {
            return button;
        }
        else if (selections == -1)
        {
            return cubeBlock;
        }
        else if (selections == 0)
        {
            return character;
        }
        else if(selections == -4)
        {
            return lever;
        }
        return selectedObject;
    }

    //manages raycast
    void DoThings()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit inFront;

        //mouse placement controls. Other controls are very much WIP
        if (Physics.Raycast(transform.position, forward, out inFront, 200, 31))
        {
            if (Input.GetButtonDown("SpinDown") || Input.GetKeyDown("mouse 0"))
                PlaceBlock(selectedObject);
            if (Input.GetButtonDown("SpinRight") || Input.GetKeyDown("mouse 1"))
                DeleteBlock(inFront);
            if (Input.GetButtonDown("SpinLeft") || Input.GetKeyDown("mouse 2"))
                PushWalls(inFront);
            CheckCubes(inFront);
            PlaceWire(inFront);
        }
    }

    //changes block channel.
    void CheckCubes(RaycastHit inFront)
    {
        //things tend to hit walls.. Return returns, because it already did what we needed to do.
        if (inFront.collider.gameObject.tag == "Lever")
        {
            if (Input.GetButtonDown("RotateLeft") || Input.GetKeyDown("e"))
            {
                inFront.collider.gameObject.GetComponent<ChangeOptions>().Edit();
                return;
            }
            if (Input.GetButtonUp("RotateLeft") || Input.GetKeyDown("e"))
            {
                inFront.collider.gameObject.GetComponent<ChangeOptions>().Disappear();
                return;
            }
        }
        else if(inFront.collider.tag == "LeverWall")
        {
            print("dank memes");
            if (Input.GetButtonDown("RotateLeft") || Input.GetKeyDown("e"))
            {
                inFront.collider.gameObject.GetComponentInParent<ChangeOptions>().Edit();
                return;
            }
            if (Input.GetButtonUp("RotateLeft") || Input.GetKeyDown("e"))
            {
                inFront.collider.gameObject.GetComponentInParent<ChangeOptions>().Disappear();
                return;
            }
        }

        for (int x = 0; x < maxBlockTypes; x++)
        {
            if (inFront.collider.gameObject.tag == "block " + x )
            {
                if (Input.GetButtonDown("RotateLeft") || Input.GetKeyDown("e"))
                {
                    inFront.collider.gameObject.GetComponentInParent<ChangeOptions>().Edit();
                    return;
                }
                if (Input.GetButtonUp("RotateLeft") || Input.GetKeyDown("e"))
                {
                    inFront.collider.gameObject.GetComponentInParent<ChangeOptions>().Disappear();
                    return;
                }
            }
        }
    }

    //places wirefraem block
    void PlaceWire(RaycastHit ray)
    {
        Vector3 pos = SetProperValues(ray.collider.transform.position);
        for (int x = 0; x < maxBlockTypes; x++)
        {
            if (ray.collider.gameObject.tag == "block " + x || ray.collider.gameObject.tag == "Wall" || ray.collider.gameObject.tag == "Exit" || ray.collider.gameObject.tag == "Player" || ray.collider.gameObject.tag == "Lever")
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
            //get proper channel etc, if it's unique, good to place.
            if(block.tag == "Player" || block.tag == "Exit")
            {
                break;
            }

            //probably fewer levers than blocks, so do this first for memory.
            GameObject[] levers = GameObject.FindGameObjectsWithTag("Lever");
            foreach (GameObject lever in levers)
            {
                if (lever.transform.position == pos)
                {
                    return;
                }
            }
            GameObject[] otherStuff = GameObject.FindGameObjectsWithTag("block " + x);
            for (int y = 0; y < otherStuff.Length; y++)
            {
                if(otherStuff[y].transform.position == pos)
                {
                    return;
                }
            }
            
        }

        //if it's not a block
        if (block.tag == "Player" || block.tag == "ExitCenter" || block.tag == "Lever")
        {
            GameObject placedBlock = (GameObject)Instantiate(block, pos, Quaternion.identity);
            placedBlock.transform.parent = GameObject.FindGameObjectWithTag("Stage").transform;
            return;
        }
        for (int x = 0; x < maxBlockTypes; x++)
        {
            if(block.tag == "block " + x )
            {
                GameObject placedBlock = (GameObject)Instantiate(block, pos, Quaternion.identity);
                placedBlock.transform.parent = GameObject.FindGameObjectWithTag("Stage").transform;
                return;
            }
        }
    }

    //adjusting values so thing snap into a grid.
    Vector3 SetProperValues(Vector3 pos)
    {
        pos.x = Mathf.Floor(pos.x) + 0;
        pos.y = Mathf.Floor(pos.y) + 0;
        pos.z = Mathf.Floor(pos.z) + 0;
        return pos;
    }

    //deletes non-wall object targeted by raycast.
    void DeleteBlock(RaycastHit other)
    {
        for(int x = 0; x < maxBlockTypes; x++)
        {
            if (other.collider.gameObject.tag == "block " + x || other.collider.gameObject.tag == "Exit" || other.collider.gameObject.tag == "Player")
            {
                other.collider.gameObject.GetComponent<DeleteParent>().Delete();
            }
        }
    }

    //pushes wall targeted by raycast
    void PushWalls(RaycastHit ray)
    {
        if (ray.collider.gameObject.tag == "Wall")
        {
            GameObject bigBox = ray.collider.gameObject.transform.parent.gameObject;
            ArrayList childSafe = new ArrayList();

            //adding everything that isn't a wall to not be scaled
            foreach (Transform child in bigBox.transform)
            {
                if (child.tag != "Wall")
                {
                    childSafe.Add(child);
                }
            }
            bigBox.transform.DetachChildren();

            foreach(GameObject wall in GameObject.FindGameObjectsWithTag("Wall"))
            {
                wall.transform.SetParent(bigBox.transform);
            }
            bigBox.transform.localScale += GetMagnitudes(ray.collider.gameObject.transform.up);
            bigBox.transform.Translate(ray.collider.transform.up * 5);

            //reattach children
            foreach(Transform saved in childSafe)
            {
                saved.transform.SetParent(bigBox.transform);
            }
        }
    }

    //why is this here? Oh well.
    Vector3 GetMagnitudes(Vector3 vec)
    {
        float x = Mathf.Abs(vec.x);
        float y = Mathf.Abs(vec.y);
        float z = Mathf.Abs(vec.z);
        return new Vector3(x, y, z);
    }
}