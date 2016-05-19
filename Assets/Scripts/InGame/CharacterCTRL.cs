using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterCTRL : MonoBehaviour
{
    public Canvas ui;
    public Rigidbody thisGuy;
    // Use this for initialization
    bool locked;
    bool canJump;
    void Start()
    {
        Unlock();
        ui = GameObject.Instantiate(ui);
    }

    // Update is called once per frame
    //moves char left and right
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
        ManageUI();
    }

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
        if(Input.GetAxis("Vertical") > .5 && canJump)
        {
            if(Mathf.Abs(thisGuy.velocity.y) < 1)
            {
                thisGuy.velocity = new Vector3(Input.GetAxis("Horizontal"), 7);
            }
            canJump = false;

        }
    }

    void OnCollisionEnter(Collision collide)
    {
        canJump = true;
    }

    void ManageUI()
    {
        if (Input.GetButtonDown("Start"))
            if (ui.enabled == false)
            {
                Time.timeScale = 0;
                ui.enabled = true;
            }
    }


}
