using UnityEngine;

public class EndProgression : MonoBehaviour {
    public int levelNumber;
    public int areaNumber;
    public string nextLevel;

    //campaign exit point.
    void OnTriggerEnter(Collider col)
    {
        GameObject.Find("MrUniverse").GetComponent<TextHolder>().AddLevel(areaNumber, levelNumber);
        Application.LoadLevel(nextLevel);
    }
}
