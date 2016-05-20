using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GenerateButtons : MonoBehaviour  {
    public GameObject dropdowns;
    float time;

    //sets up dropdown menus

	// Use this for initialization
	void Awake () {
        //coulda been OnStart.
        dropdowns.GetComponent<Dropdown>().options.Clear();
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath + "/", "*.dat");
        for(int x = 0; x < filePaths.Length; x++)
        {
            AddButton(filePaths[x].Substring(Application.persistentDataPath.Length + 1, filePaths[x].Length - (Application.persistentDataPath.Length + 5)));
        }

    }
	
	// Update is called once per frame
	void Update () {
        //go to level.
        if (Input.GetButtonDown("SpinDown"))
        {
            if (File.Exists(Application.persistentDataPath + "/" + dropdowns.GetComponent<Dropdown>().value + ".dat"))
            {
                GameObject.Find("MrUniverse").GetComponent<TextHolder>().text = dropdowns.GetComponent<Dropdown>().options[dropdowns.GetComponent<Dropdown>().value].text;
                SceneManager.LoadScene("LoadStage");
            }
        }

        //delete all levels
        if (Input.GetButtonDown("SpinUp"))
        {
            dropdowns.GetComponent<Dropdown>().options.Clear();
            string[] filePaths = Directory.GetFiles(Application.persistentDataPath + "/", "*.dat");
            for (int x = 0; x < filePaths.Length; x++)
            {
                File.Delete(filePaths[x]);
            }
        }

        //goes to main menu
        if(Input.GetButtonDown("SpinRight"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        //gonna delete something soon.
        if (Input.GetButtonDown("SpinLeft"))
        {
            string[] filePaths = Directory.GetFiles(Application.persistentDataPath + "/", "*.dat");

            File.Delete(filePaths[dropdowns.GetComponent<Dropdown>().value]);
            dropdowns.GetComponent<Dropdown>().options.Clear();
            filePaths = Directory.GetFiles(Application.persistentDataPath + "/", "*.dat");
            for (int x = 0; x < filePaths.Length; x++)
            {
                AddButton(filePaths[x].Substring(Application.persistentDataPath.Length + 1, filePaths[x].Length - (Application.persistentDataPath.Length + 5)));
            }
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
    void AddButton(string button)
    {
        Dropdown.OptionData buttonInfo = new Dropdown.OptionData() ;
        buttonInfo.text = button;
        dropdowns.GetComponent<Dropdown>().options.Add(buttonInfo);
    }
}
