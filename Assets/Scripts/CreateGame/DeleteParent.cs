using UnityEngine;

public class DeleteParent : MonoBehaviour {
    public GameObject parent;

    public void Delete()
    {
        Destroy(parent);
    }
}