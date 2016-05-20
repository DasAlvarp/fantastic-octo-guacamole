using UnityEngine;
using System;
using System.Collections;

public class EndProgression : MonoBehaviour {
    public int levelNumber;
    public int areaNumber;
    public string nextLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        GameObject.Find("MrUniverse").GetComponent<TextHolder>().AddLevel(areaNumber, levelNumber);
        Application.LoadLevel(nextLevel);
    }
}
