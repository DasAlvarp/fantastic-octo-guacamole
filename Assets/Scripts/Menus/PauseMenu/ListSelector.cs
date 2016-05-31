using UnityEngine;
using UnityEngine.UI;

public class ListSelector : MonoBehaviour
{
    //Allows controller to kinda work on dropdown menu.
    public Button[] buttonsToSelect;
    int selected = 0;
    DpadConversion buttonner;

	void Start ()
    {
        gameObject.AddComponent<DpadConversion>();
        gameObject.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if the menu is up, pasue the game and do the pause menu thing.
        if(gameObject.GetComponent<Canvas>().enabled)
        {
            Time.timeScale = 0;
        }

        selected -= gameObject.GetComponent<DpadConversion>().upPress;
        if (selected == -1)
            selected += 3;
        selected %= 3;
        buttonsToSelect[selected].Select();
        if(Input.GetButtonDown("MenuSelect"))
        {
            buttonsToSelect[selected].onClick.Invoke() ;
        }
    }
}
