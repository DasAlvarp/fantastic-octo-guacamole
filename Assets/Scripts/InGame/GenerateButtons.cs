using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GenerateButtons : MonoBehaviour  {
    public GameObject dropdowns;
    float time;

	// Use this for initialization
	void Awake () {
        print(Application.persistentDataPath);

        DontDestroyOnLoad(gameObject.transform.parent.gameObject);
        dropdowns.GetComponent<Dropdown>().options.Clear();
        int x = 0;
        for (x = 0; File.Exists(Application.persistentDataPath + "/" + x + ".dat"); x++)
        {
            AddButton(x);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("SpinDown"))
        {
            if (File.Exists(Application.persistentDataPath + "/" + dropdowns.GetComponent<Dropdown>().value + ".dat"))
            {
                GameObject.Find("MrUniverse").GetComponent<TextHolder>().text = "" + dropdowns.GetComponent<Dropdown>().value;
                Application.LoadLevel("LoadStage");



                Destroy(gameObject.transform.parent.gameObject);

            }
        }
        if (Input.GetButtonDown("SpinUp"))
        {
            for(int x = 0; File.Exists(Application.persistentDataPath + "/" + x + ".dat"); x++)
            {
                File.Delete(Application.persistentDataPath + "/" + x + ".dat");
            }
        }
        if(Input.GetButtonDown("SpinRight"))
        {
            Application.LoadLevel("MainMenu");
            Destroy(gameObject.transform.parent.gameObject);

        }
        if (Input.GetButtonDown("SpinLeft"))
        {
            GameObject.Find("WhereToHud").GetComponent<OnStart>().level = "" + dropdowns.GetComponent<Dropdown>().value;

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
