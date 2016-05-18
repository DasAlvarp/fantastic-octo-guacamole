using UnityEngine;
using System.Collections;
using System.IO;

public class GenerateButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int x = 0;
        for (x = 0; File.Exists(Application.persistentDataPath + "/" + x + ".dat"); x++)
        {
            AddButton(x);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddButton(int buttonNum)
    {

    }
}
