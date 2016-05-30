using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    public GameObject thisGuy;
    public AudioClip rotate;
    float time = 1f;
    Vector3 rotateTo = new Vector3(0, 0, 0);
    GameObject player;
    AudioSource sound;
    Transform pos;

	// Use this for initialization
	void Start () {
        sound = gameObject.AddComponent<AudioSource>();
        sound.clip = rotate;
        player = GameObject.Find("Character(Clone)");//sometimes is null on start.
    }
	
	// this works better now I guess?
	void FixedUpdate ()
    {
        player = GameObject.Find("Character(Clone)");
        pos = transform;
        Spin();
    }


    //spins stage + children based on controller inputs.
    void Spin()
    {
        if (Input.GetButtonDown("SpinLeft"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 90, 0);
            StartCoroutine(Rotate(rotateTo, time));
        }
        else if (Input.GetButtonDown("SpinRight"))
        {
            sound.Play();
            rotateTo = new Vector3(0, -90, 0);
            StartCoroutine(Rotate(rotateTo, time));
        }
        else if (Input.GetButtonDown("SpinUp"))
        {
            sound.Play();
            rotateTo = new Vector3(-90, 0, 0);
            StartCoroutine(Rotate(rotateTo, time));


        }
        else if (Input.GetButtonDown("SpinDown"))
        {
            sound.Play();
            rotateTo = new Vector3(90, 0, 0);
            StartCoroutine(Rotate(rotateTo, time));


        }
        else if(Input.GetButtonDown("RotateRight"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 0, 90);
            StartCoroutine(Rotate(rotateTo, time));


        }
        else if (Input.GetButtonDown("RotateLeft"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 0, -90);
            StartCoroutine(Rotate(rotateTo, time));


        }
        else
        {
            rotateTo = new Vector3(0, 0, 0);
        }


    }

    Vector3 FloorEr(Vector3 vec)
    {
        return new Vector3(vec.x, vec.y,vec.z);//still testing ways to make stuff better. EZ changes.
    }

    public Transform ThisGuy()
    {
        return thisGuy.transform;
    }

    IEnumerator Rotate(Vector3 vec, float time)
    {        
        thisGuy.transform.Rotate(vec * Time.deltaTime / time, Space.World);
        yield return null;

        time -= Time.deltaTime;
        vec -= vec * Time.deltaTime / time;
        if (time > 0)
        {
            StartCoroutine(Rotate(vec, time));
        }
        if (time <= 0)
        {
            thisGuy.transform.eulerAngles = RoundTo90(thisGuy.transform);
            yield return null;

        }


    }

    Vector3 RoundTo90(Transform rotation)
    {
        Vector3 vec = rotation.eulerAngles;
        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;
        return vec;


    }
}
