using UnityEngine;
using UnityEngine.SceneManagement;

public class EndProgression : MonoBehaviour
{
    public int levelNumber;
    public int areaNumber;
    public string nextLevel;

    //campaign exit point.
    void OnTriggerEnter(Collider col)
    {
        GameObject.Find("MrUniverse").GetComponent<TextHolder>().AddLevel(areaNumber, levelNumber);
        SceneManager.LoadScene(nextLevel);
    }
}
