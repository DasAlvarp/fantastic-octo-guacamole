using UnityEngine;

public class CharacterCTRL : MonoBehaviour
{
    public Canvas ui;
    public Rigidbody thisGuy;

    public AudioClip jumpSound;
    // Use this for initialization
    bool locked;
    bool canJump;

    AudioSource sound;

    void Start()
    {
        Unlock();
        ui = Instantiate(ui);
        sound = gameObject.AddComponent<AudioSource>();
        sound.clip = jumpSound;
    }

    // Update is called once per frame
    //moves char left and right
    void Update()
    {
        if (!locked)
        {
            thisGuy.velocity = new Vector3(GetLargestMagnitude(Input.GetAxis("Horizontal"), HorizontalKeyInputs()) * 8, thisGuy.velocity.y);
        }
        else
        {
            thisGuy.velocity = new Vector3(0, 0, 0);
        }
        Jump();
        ManageUI();
    }

    //managing UI editableness
    public void Lock()
    {
        locked = true;
    }

    public void Unlock()
    {
        locked = false;
    }

    //jumping is a bit stranger than I thought it would be.
    void Jump()
    {
        if((Input.GetAxis("Vertical") > .5 || Input.GetButton("Jump")) && canJump )
        {
            if(Mathf.Abs(thisGuy.velocity.y) < 1)
            {
                thisGuy.velocity = new Vector3(Input.GetAxis("Horizontal"), 7);
                sound.Play();
            }
            canJump = false;
        }
    }

    //you can jump when you touch something.
    void OnCollisionEnter(Collision collide)
    {
        canJump = true;
    }

    //Pauses
    void ManageUI()
    {
        if (Input.GetButtonDown("Start"))
            if (ui.enabled == false)
            {
                Time.timeScale = 0;
                ui.enabled = true;
            }
    }

    float HorizontalKeyInputs()
    {
        float tret = 0;
        if(Input.GetButton("MoveLeft"))
        {
            tret -= 1;
        }
        if(Input.GetButton("MoveRight"))
        {
            tret += 1;
        }
        return tret;
    }

    //idk, recursive stuff is kinda fun. Not very practical though.
    float GetLargestMagnitude(params float[] floats)
    {
        if(floats.Length == 2)
        {
            if (Mathf.Abs(floats[0]) > Mathf.Abs(floats[1]))
                return floats[0];
            else
                return floats[1];
        }
        else
        {
            float[] newFloats = new float[floats.Length - 1];
            for(int x = 0; x < floats.Length - 1; x++)
            {
                newFloats[x] = floats[x];
            }
            return (GetLargestMagnitude(floats[floats.Length - 1], GetLargestMagnitude(newFloats)));
        }
    }
}
