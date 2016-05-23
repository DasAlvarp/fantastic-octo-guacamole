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
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Spin();
    }


    //spins stage + children based on controller inputs.
    void Spin()
    {
        Vector3 rotateTo;
        if (Input.GetButtonUp("SpinLeft"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 90, 0);
            player.transform.position = FloorEr(player.transform.position);
        }
        else if (Input.GetButtonUp("SpinRight"))
        {
            sound.Play();
            rotateTo = new Vector3(0, -90, 0);
            player.transform.position = FloorEr(player.transform.position);

        }
        else if (Input.GetButtonUp("SpinUp"))
        {
            sound.Play();
            rotateTo = new Vector3(-90, 0, 0);
            player.transform.position = FloorEr(player.transform.position);

        }
        else if (Input.GetButtonUp("SpinDown"))
        {
            sound.Play();
            rotateTo = new Vector3(90, 0, 0);
            player.transform.position = FloorEr(player.transform.position);

        }
        else if(Input.GetButtonUp("RotateRight"))
        {
            sound.Play();
            rotateTo = new Vector3(0, 0, 90);
            player.transform.position = FloorEr(player.transform.position);

        }
        else if (Input.GetButtonUp("RotateLeft"))
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
        return new Vector3(vec.x, vec.y, Mathf.Round((vec.z)));
    }
}
