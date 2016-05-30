using UnityEngine;

public class DeleteParent : MonoBehaviour
{
    public GameObject parent;

    //doesn't just destroy parent. SOmetimes desttroys self. Bad name.
    public void Delete()
    {
        Destroy(parent);
    }
}