using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageLoadControl : MonoBehaviour
{
    public int areaNum;
    public int levelNum;
    public string loadLevel;
    public Color usable;
    public Image toChange;
	
	// Manages unlocks
	void Update ()
    {
        if (areaNum < GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedAreas && toChange.color != usable)
        {
            toChange.color = usable;
        }
        else if (areaNum == GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedAreas)
        {
            if (levelNum <= GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedLevels)
                toChange.color = usable;
        }
    }

    //loads stage and changes button color if the stage is unlocked
    public void LoadIfUnlocked()
    {
        GameObject.Find("MrUniverse").GetComponent<TextHolder>().Save();
        if (areaNum < GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedAreas)
        {
            SceneManager.LoadScene(loadLevel);
        }
        else if(areaNum == GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedAreas)
        {
            if(levelNum <= GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedLevels)
                SceneManager.LoadScene(loadLevel);
        }
    }
}
