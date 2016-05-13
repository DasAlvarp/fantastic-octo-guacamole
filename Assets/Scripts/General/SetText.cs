using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetText : MonoBehaviour {
    public GameObject textThing;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TextIt(string text)
    {
        textThing.GetComponent<Text>().text = text;
    }
}
