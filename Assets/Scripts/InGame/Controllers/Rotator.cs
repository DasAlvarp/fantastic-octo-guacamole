using UnityEngine;

public class Rotator : MonoBehaviour {

    public GameObject thisGuy;
    public AudioClip rotate;
    GameObject player;
    AudioSource sound;

	// Use this for initialization
	void Start () {
        sound = gameObject.AddComponent<AudioSource>();
        sound.clip = rotate;
        player = GameObject.Find("Character(Clone)");//sometimes is null on start.
    }
	
	// this works better now I guess?
	void FixedUpdate () {
        player = GameObject.Find("Character(Clone)");

        Spin();
    }


    //spins stage + children based on controller inputs.
    void Spin()
    {
        Vector3 rotateTo;
        if (Input.GetButtonDown("SpinLeft"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 90, 0);
            player.transform.position = FloorEr(player.transform.position);
        }
        else if (Input.GetButtonDown("SpinRight"))
        {
            sound.Play();
            rotateTo = new Vector3(0, -90, 0);
            player.transform.position = FloorEr(player.transform.position);

        }
        else if (Input.GetButtonDown("SpinUp"))
        {
            sound.Play();
            rotateTo = new Vector3(-90, 0, 0);
            player.transform.position = FloorEr(player.transform.position);

        }
        else if (Input.GetButtonDown("SpinDown"))
        {
            sound.Play();
            rotateTo = new Vector3(90, 0, 0);
            player.transform.position = FloorEr(player.transform.position);

        }
        else if(Input.GetButtonDown("RotateRight"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 0, 90);
            player.transform.position = FloorEr(player.transform.position);

        }
        else if (Input.GetButtonDown("RotateLeft"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 0, -90);
            player.transform.position = FloorEr(player.transform.position);

        }
        else
        {
            rotateTo = new Vector3(0, 0, 0);
        }
        thisGuy.transform.Rotate(rotateTo, Space.World);
    }

    Vector3 FloorEr(Vector3 vec)
    {
        return new Vector3(vec.x, vec.y,vec.z);//still testing ways to make stuff better. EZ changes.
    }
}
