using UnityEngine;

public class OnPress : MonoBehaviour
{
    bool pressed = false;

    public GameObject[] blocks;

    // Use this for initialization
    void Start ()
    {
        blocks = GameObject.FindGameObjectsWithTag(gameObject.tag);
	}
    
    //button triggering script. Might switch to toggle/add lever at some point
    void OnTriggerEnter(Collider col)
    {
        if(!pressed)
            if(col.gameObject.tag == "Player")
            {
                pressed = true;
                foreach(GameObject block in blocks)
                    block.SetActive(!block.activeSelf);
            }
    }
}
