using UnityEngine;

public class LoadForEdit : MonoBehaviour
{
	void Start ()
    {
        GetComponent<Saver>().Load(GameObject.Find("MrUniverse").GetComponent<TextHolder>().text);
	}
}
