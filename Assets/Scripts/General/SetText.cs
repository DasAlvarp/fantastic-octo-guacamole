using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {
    public GameObject textThing;

    //just holds text. 
    public void TextIt(string text)
    {
        textThing.GetComponent<Text>().text = text;
    }
}
