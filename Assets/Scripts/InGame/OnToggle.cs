using UnityEngine;

public class OnToggle : MonoBehaviour {
    public string toggleTag;
    GameObject[] toToggle;
    bool started = false;

    //toggles faces on levers.
    void OnTriggerEnter(Collider col)
    {
        //OnStart doesn't want to work for some reason.
        if(started == false)
        {
            started = true;
            toToggle = GameObject.FindGameObjectsWithTag(toggleTag);
        }

        ChangeFace[] things  = transform.GetComponentsInChildren<ChangeFace>();
        for(int x = 0; x < things.Length; x++)
        {
            things[x].Toggle();
        }

        foreach (GameObject toggleMe in toToggle)
        {
            if(toggleMe.activeSelf)
            {
                toggleMe.SetActive(false);
            }
            else
            {
                toggleMe.SetActive(true);
            }
        }
    }
}
