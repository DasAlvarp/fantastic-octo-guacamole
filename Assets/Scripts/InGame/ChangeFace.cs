using UnityEngine;

public class ChangeFace : MonoBehaviour {
    public Material offSt;
    public Material onSt;
    bool state;

    void OnStart()
    {
        state = true;
    }

    //toggles state of textures on lever.
    public bool Toggle()
    {       
        if (state)
        {
            gameObject.GetComponent<Renderer>().material = offSt;
            state = false;
            return true;
        }
        gameObject.GetComponent<Renderer>().material = onSt;
        state = true;
        return false;
     }
}