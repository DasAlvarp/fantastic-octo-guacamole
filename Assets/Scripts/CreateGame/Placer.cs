﻿using UnityEngine;
using System.Collections;


public class Placer : MonoBehaviour {
    public GameObject cubeBlock;
    public GameObject button;
    public GameObject exit;
    public GameObject character;

    public GameObject selectedOption;

    public GameObject radialMenu;
    int selected;

    GameObject selectedObject;

    public GameObject wireMan;
    public int maxBlockTypes;
	// Use this for initialization
	void Start () {
        cubeBlock.GetComponent<ChangeOptions>().selectionMenu = selectedOption ;
        button.GetComponent<ChangeOptions>().selectionMenu = selectedOption;
        
        selectedObject = cubeBlock;
    }
	
	// Update is called once per frame
	void Update () {
        //have to adjust camera up/down, but don't want it to affect movement, this script is conveniently attatched to the camera
        if (!Input.GetButton("SpinUp") && !Input.GetButton("RotateLeft"))
            transform.Rotate(new Vector3(Input.GetAxis("CamRotUp"), 0));
        selected = radialMenu.GetComponent<RadialMenuAndHold>().value;
        selectedObject = SelectOptions(selected);
        DoThings();
	}

    //converts ints fron radial menu into selected blocks
    GameObject SelectOptions(int selections)
    {
        if(selections == -2)
        {
            return exit;
        }
        if(selections == -3)
        {
            return button;
        }
        if(selections == -1)
        {
            return cubeBlock;
        }
        if(selections == 0)
        {
            return character;
        }
        return selectedObject;
    }

    //manages raycast
    void DoThings()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit inFront;

        if (Physics.Raycast(transform.position, forward, out inFront, 200, 31))
        {
            if (Input.GetButtonDown("SpinDown"))
                PlaceBlock(selectedObject);
            if (Input.GetButtonDown("SpinRight"))
                DeleteBlock(inFront);
            if (Input.GetButtonDown("SpinLeft"))
                PushWalls(inFront);
            CheckCubes(inFront);
            PlaceWire(inFront);

        }
    }

    //changes block number types.
    void CheckCubes(RaycastHit inFront)
    {
        for (int x = 0; x < maxBlockTypes; x++)
        {
            if (inFront.collider.gameObject.tag == "block " + x)
            {
                if (Input.GetButtonDown("RotateLeft"))
                {
                    inFront.collider.gameObject.GetComponentInParent<ChangeOptions>().Edit();
                }
                if (Input.GetButtonUp("RotateLeft"))
                {
                    inFront.collider.gameObject.GetComponentInParent<ChangeOptions>().Disappear();
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
            if (ray.collider.gameObject.tag == "block " + x || ray.collider.gameObject.tag == "Wall" || ray.collider.gameObject.tag == "Exit" || ray.collider.gameObject.tag == "Player")
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
            if(block.tag == "Player" || block.tag == "Exit")
            {
                break;
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
        for (int x = 0; x < maxBlockTypes; x++)
        {
            if(block.tag == "block " + x  || block.tag == "Player" || block.tag == "ExitCenter")
            {
                GameObject placedBlock = (GameObject)Instantiate(block, pos, Quaternion.identity);
                placedBlock.transform.parent = GameObject.FindGameObjectWithTag("Stage").transform;
                GameObject.FindGameObjectWithTag("Stage").GetComponent<Saver>().Save();
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

    void PushWalls(RaycastHit ray)
    {

        if (ray.collider.gameObject.tag == "Wall")
        {
            GameObject bigBox = ray.collider.gameObject.transform.parent.gameObject;
            ArrayList childSafe = new ArrayList();
            
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
            foreach(Transform saved in childSafe)
            {
                saved.transform.SetParent(bigBox.transform);
            }

        }
    }

    Vector3 GetMagnitudes(Vector3 vec)
    {
        float x = Mathf.Abs(vec.x);
        float y = Mathf.Abs(vec.y);
        float z = Mathf.Abs(vec.z);
        return new Vector3(x, y, z);
    }
}