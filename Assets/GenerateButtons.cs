using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class GenerateButtons : MonoBehaviour {
    public GameObject dropdowns;
    float time;

	// Use this for initialization
	void Start () {
        dropdowns.GetComponent<Dropdown>().options.Clear();
        int x = 0;
        for (x = 0; File.Exists(Application.persistentDataPath + "/" + x + ".dat"); x++)
        {
            AddButton(x);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("SpinRight"))
        {
            if (File.Exists(Application.persistentDataPath + "/" + dropdowns.GetComponent<Dropdown>().value + ".dat"))
            {
                Application.LoadLevel("LoadStage");
                GameObject.Find("WhereToHud").GetComponent<OnStart>().level = "" + dropdowns.GetComponent<Dropdown>().value;

            }
        }
        if (Input.GetButtonDown("SpinUp"))
        {
            for(int x = 0; File.Exists(Application.persistentDataPath + "/" + x + ".dat"); x++)
            {
                File.Delete(Application.persistentDataPath + "/" + x + ".dat");
            }
        }

        time += Time.deltaTime;
        if (time > .1f)
        {
            time = 0f;

            dropdowns.GetComponent<Dropdown>().value += (int)Input.GetAxis("DpadDown");
        }
        
	}

    void AddButton(int buttonNum)
    {
        Dropdown.OptionData buttonInfo = new Dropdown.OptionData() ;
        buttonInfo.text = buttonNum + "";
        dropdowns.GetComponent<Dropdown>().options.Add(buttonInfo);

    }
}
