using UnityEngine;
using UnityEngine.UI;

public class SetImage : MonoBehaviour
{
    public Sprite[] images;

	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Image>().sprite = images[GameObject.Find("Camera").GetComponent<Placer>().selected * -1];
	}
}
