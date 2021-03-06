﻿using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public GameObject thisGuy;
    public AudioClip rotate;
    float time = 1f;
    Vector3 rotateTo = new Vector3(0, 0, 0);
    AudioSource sound;

	// Use this for initialization
	void Start ()
    {
        sound = gameObject.AddComponent<AudioSource>();
        sound.clip = rotate;
    }
	
	// this works better now I guess?
	void FixedUpdate ()
    {
        Spin();
    }


    //spins stage + children based on controller inputs.
    void Spin()
    {
        if (Input.GetButtonDown("SpinLeft"))
        {
            sound.Play();
            rotateTo = new Vector3(0, -90, 0);
            StartCoroutine(RotatePositive(rotateTo, time));
        }
        else if (Input.GetButtonDown("SpinRight"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 90, 0);
            StartCoroutine(RotateNegative(rotateTo, time));
        }
        else if (Input.GetButtonDown("SpinUp"))
        {
            sound.Play();
            rotateTo = new Vector3(-90, 0, 0);
            StartCoroutine(RotateNegative(rotateTo, time));
        }
        else if (Input.GetButtonDown("SpinDown"))
        {
            sound.Play();
            rotateTo = new Vector3(90, 0, 0);
            StartCoroutine(RotatePositive(rotateTo, time));
        }
        else if(Input.GetButtonDown("RotateRight"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 0, 90);
            StartCoroutine(RotatePositive(rotateTo, time));
        }
        else if (Input.GetButtonDown("RotateLeft"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 0, -90);
            StartCoroutine(RotateNegative(rotateTo, time));
        }
        else
        {
            rotateTo = new Vector3(0, 0, 0);
        }
    }

    //returns transform, for possbile camra things
    public Transform ThisGuy()
    {
        return thisGuy.transform;
    }
    

    //looks like i only need one, but no reason to delete in case something strange pops up.
    //spins stage over amount of time
    IEnumerator RotatePositive(Vector3 vec, float time)
    {
        
        thisGuy.transform.Rotate(vec * Time.deltaTime / time, Space.World);
        yield return null;
        vec -= vec * Time.deltaTime/time ;
        time -= Time.deltaTime;


        if (time > .01f)
        {
            StartCoroutine(RotatePositive(vec, time));
        }
        else
        {
            thisGuy.transform.eulerAngles = RoundTo90(thisGuy.transform);
            yield return null;
        }
    }

    IEnumerator RotateNegative(Vector3 vec, float time)
    {

        thisGuy.transform.Rotate(vec * Time.deltaTime / time, Space.World);
        yield return null;
        vec -= vec * Time.deltaTime / time;
        time -= Time.deltaTime;


        if (time > .01f)
        {
            StartCoroutine(RotateNegative(vec, time));
        }
        else 
        {
            thisGuy.transform.eulerAngles = RoundTo90(thisGuy.transform);
            yield return null;
        }
    }

    //at end of rotation, make sure that it's 'snapped' to a right angle.
    Vector3 RoundTo90(Transform rotation)
    {
        Vector3 vec = rotation.eulerAngles;
        vec.x = Mathf.Round(vec.x / 90f) * 90;
        vec.y = Mathf.Round(vec.y / 90f) * 90;
        vec.z = Mathf.Round(vec.z / 90f) * 90;
        return vec;
    }
}