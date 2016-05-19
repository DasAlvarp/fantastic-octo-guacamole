using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainSelector : MonoBehaviour
{

    public Button[] buttonsRight;
    public Button[] buttonsLeft;
    int selectedHeight = 0;
    int selectedSide = 0;
    Button[,] buttonsToSelect;
    DpadConversion buttonner;

    // Use this for initialization
    void Start()
    {
        buttonsToSelect = new Button[3,2];
        gameObject.AddComponent<DpadConversion>();
        
        for(int x = 0; x < 3; x++)
        {
            buttonsToSelect[x, 0] = buttonsLeft[x];
            buttonsToSelect[x, 1] = buttonsRight[x];
        }
    }

    // Update is called once per frame
    void Update()
    {

        selectedHeight -= gameObject.GetComponent<DpadConversion>().upPress;
        if (selectedHeight == -1)
            selectedHeight += 3;
        selectedHeight %= 3;

        selectedSide -= gameObject.GetComponent<DpadConversion>().sidePress;
        if (selectedSide == -1)
            selectedSide += 2;
        selectedSide %= 2;

        print(selectedHeight + ", " + selectedSide);

        buttonsToSelect[selectedHeight,selectedSide].Select();
        if (Input.GetButtonDown("SpinDown"))
        {
            buttonsToSelect[selectedHeight,selectedSide].onClick.Invoke();
        }
    }
}