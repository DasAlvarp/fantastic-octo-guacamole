using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GenerateButtons : MonoBehaviour  {
    public GameObject dropdowns;
    float time;

    //sets up dropdown menus

	// Use this for initialization
	void Awake () {
        //coulda been OnStart.
        dropdowns.GetComponent<Dropdown>().options.Clear();
        int x = 0;
        for (x = 0; File.Exists(Application.persistentDataPath + "/" + x + ".dat"); x++)
        {
            AddButton(x);
        }

    }
	
	// Update is called once per frame
	void Update () {
        //go to level.
        if (Input.GetButtonDown("SpinDown"))
        {
            if (File.Exists(Application.persistentDataPath + "/" + dropdowns.GetComponent<Dropdown>().value + ".dat"))
            {
                GameObject.Find("MrUniverse").GetComponent<TextHolder>().text = "" + dropdowns.GetComponent<Dropdown>().value;
                Application.LoadLevel("LoadStage");
            }
        }

        //delete all levels
        if (Input.GetButtonDown("SpinUp"))
        {
            for(int x = 0; File.Exists(Application.persistentDataPath + "/" + x + ".dat"); x++)
            {
                File.Delete(Application.persistentDataPath + "/" + x + ".dat");
            }
        }

        //goes to main menu
        if(Input.GetButtonDown("SpinRight"))
        {
            Application.LoadLevel("MainMenu");
        }

        //gonna delete something soon.
        if (Input.GetButtonDown("SpinLeft"))
        {
            GameObject.Find("WhereToHud").GetComponent<OnStart>().level = "" + dropdowns.GetComponent<Dropdown>().value;
        }

        //timer so selection doesnt't go 15 times every slight touch of the arrow.
        time += Time.deltaTime;
        if (time > .1f)
        {
            time = 0f;

            dropdowns.GetComponent<Dropdown>().value += (int)Input.GetAxis("DpadDown");
        }
        
	}

    //adds an element to the list.
    void AddButton(int buttonNum)
    {
        Dropdown.OptionData buttonInfo = new Dropdown.OptionData() ;
        buttonInfo.text = buttonNum + "";
        dropdowns.GetComponent<Dropdown>().options.Add(buttonInfo);

    }
}
