using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSelector : MonoBehaviour
{
    public AudioClip pickIt;
    public string lastMenu;

    public Button[] buttonsRight;
    public Button[] buttonsLeft;
    int selectedHeight = 0;
    int selectedSide = 0;
    AudioSource sound;
    Button[,] buttonsToSelect;
    DpadConversion buttonner;

    // Use this for initialization
    void Start()
    {
        //get sound
        sound = GameObject.Find("MrUniverse").AddComponent<AudioSource>();
        sound.clip = pickIt;

        buttonsToSelect = new Button[3,2];
        gameObject.AddComponent<DpadConversion>();
        
        //fill buttons
        for(int x = 0; x < buttonsRight.Length; x++)
        {
            buttonsToSelect[x, 0] = buttonsLeft[x];
            buttonsToSelect[x, 1] = buttonsRight[x];
        }
    }

    //Selecting b/t things
    void Update()
    {
        selectedHeight -= gameObject.GetComponent<DpadConversion>().upPress;
        if (selectedHeight == -1)
            selectedHeight += buttonsRight.Length;
        selectedHeight %= buttonsRight.Length;

        selectedSide -= gameObject.GetComponent<DpadConversion>().sidePress;
        if (selectedSide == -1)
            selectedSide += 2;
        selectedSide %= 2;

        buttonsToSelect[selectedHeight,selectedSide].Select();
        if (Input.GetButtonDown("MenuSelect"))
        {
            GameObject.Find("MrUniverse").GetComponent<AudioSource>().Play();
            buttonsToSelect[selectedHeight,selectedSide].onClick.Invoke();
        }

        if(Input.GetButtonDown("MenuBack"))
        {
            SceneManager.LoadScene(lastMenu);
        }
    }
}