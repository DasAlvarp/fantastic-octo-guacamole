using UnityEngine;
using System.Collections;

public class TextHolder : MonoBehaviour {
    public string text;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
