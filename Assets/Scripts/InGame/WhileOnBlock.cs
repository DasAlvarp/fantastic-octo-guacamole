using UnityEngine;

public class WhileOnBlock : MonoBehaviour
{
    public string toggleTag;
    GameObject[] toToggle;
    bool started = false;

    void Start()
    {
        if (!started)
        {
            started = true;
            toToggle = GameObject.FindGameObjectsWithTag(toggleTag);
        }
    }

    //toggles faces on levers. This one makes it so the lever is only active when the player is touching it.
    void OnTriggerEnter(Collider col)
    {
        ChangeFace[] things = transform.GetComponentsInChildren<ChangeFace>();
        for (int x = 0; x < things.Length; x++)
        {
            things[x].Toggle();
        }

        foreach (GameObject toggleMe in toToggle)
        {
            if (toggleMe.activeSelf)
            {
                toggleMe.SetActive(false);
            }
            else
            {
                toggleMe.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        OnTriggerEnter(col);
    }
}
