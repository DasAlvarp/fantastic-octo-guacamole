using UnityEngine;
using System.Collections;

public class CharacterCTRL : MonoBehaviour
{

    public Rigidbody thisGuy;
    // Use this for initialization
    bool locked;
    bool canJump;
    void Start()
    {
        Unlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (!locked)
        {
            thisGuy.velocity = new Vector3(Input.GetAxis("Horizontal") * 8, thisGuy.velocity.y);
        }
        else
        {
            thisGuy.velocity = new Vector3(0, 0,0);
        }

        Jump();
    }

    public void Lock()
    {
        locked = true;
    }
    public void Unlock()
    {
        locked = false;
    }

    void Jump()
    {
        if(Input.GetAxis("Vertical") > .5 && canJump)
        {
            if(Mathf.Abs(thisGuy.velocity.y) < 1)
            {
                thisGuy.velocity = new Vector3(Input.GetAxis("Horizontal"), 6);
            }
            canJump = false;

        }
    }

    void OnCollisionEnter(Collision collide)
    {
        canJump = true;
        print("hi");

    }
}
