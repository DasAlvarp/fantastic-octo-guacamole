using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;

public class ListGeneration : MonoBehaviour
{
    public Text itemList;
    public Text selector;
    public Text selectedItem;
    float time;
    ArrayList options;
    int selected;
    DpadConversion dpad;

    //sets up dropdown menus

    // Use this for initialization
    void Awake()
    {
        //coulda been OnStart.
        dpad = gameObject.AddComponent<DpadConversion>();
        options = new ArrayList();
        selected = 0;
        PopulateOptions();
        UpdateOptions();
    }

    void PopulateOptions()
    {
        options.Clear();

        string[] filePaths = Directory.GetFiles(Application.persistentDataPath + "/", "*.dat");
        for (int x = 0; x < filePaths.Length; x++)
        {
            options.Add(filePaths[x].Substring(Application.persistentDataPath.Length + 1, filePaths[x].Length - (Application.persistentDataPath.Length + 5)));
        }
    }

    // this is for dropdown moving and selecting stuff. It's still pretty voodoo to me.
    void Update()
    {
        //go to level.
        if (Input.GetButtonDown("MenuSelect"))
        {
            if (File.Exists(Application.persistentDataPath + "/" + options[selected] + ".dat"))
            {
                GameObject.Find("MrUniverse").GetComponent<TextHolder>().text = (string)options[selected];
                SceneManager.LoadScene("LoadStage");
            }
        }

        //delete all levels
        if (Input.GetButtonDown("MenuDeleteAll"))
        {
            options.Clear();
            string[] filePaths = Directory.GetFiles(Application.persistentDataPath + "/", "*.dat");
            for (int x = 0; x < filePaths.Length; x++)
            {
                File.Delete(filePaths[x]);
            }
            UpdateOptions();
        }

        //goes to main menu
        if (Input.GetButtonDown("MenuBack"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        //deletes a specific item.
        if (Input.GetButtonDown("MenuDelete"))
        {
            string[] filePaths = Directory.GetFiles(Application.persistentDataPath + "/", "*.dat");

            File.Delete(filePaths[selected]);
            PopulateOptions();
            UpdateOptions();
        }
        UpdateSelector();

        if (options.Count > 0)
        {
            selected -= dpad.upPress;
            if (selected < 0)
                selected += options.Count;
            selected %= options.Count;
        }
    }

    //update selecing thingy.
    void UpdateSelector()
    {
        selector.text = "";
        for(int x = 0; x < selected; x++)
        {
            selector.text += "\n";
        }
        selector.text += "+";
        selectedItem.text = (string)options[selected];
    }

    //updates UI list
    void UpdateOptions()
    {
        itemList.text = "";
        for(int x = 0; x < options.Count; x++)
        {
            itemList.text += "   " + options[x] + "\n";
        }
    }
}