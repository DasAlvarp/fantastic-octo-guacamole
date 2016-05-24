using UnityEngine;

public class OnToggle : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        ChangeFace[] things  = transform.GetComponentsInChildren<ChangeFace>();
        for(int x = 0; x < things.Length; x++)
        {
            things[x].Toggle();
        }
    }
}
