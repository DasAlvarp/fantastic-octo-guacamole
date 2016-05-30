using UnityEngine;

public class OnToggle : MonoBehaviour
{
    public string toggleTag;
    GameObject[] toToggle;

    void Start()
    {
        toToggle = GameObject.FindGameObjectsWithTag(toggleTag);
    }

    //toggles faces on levers.
    void OnTriggerEnter(Collider col)
    {
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