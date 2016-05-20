using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageLoadControl : MonoBehaviour {

    public int stageNum;
    public int levelNum;
    public string loadLevel;
    public Color usable;
    public Image toChange;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (stageNum < GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedAreas)
        {
            toChange.color = usable;
            
        }
        else if (stageNum == GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedAreas)
        {
            if (levelNum <= GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedLevels)
                toChange.color = usable;
        }
    }

    public void LoadIfUnlocked()
    {
        if(stageNum < GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedAreas)
        {
            Application.LoadLevel(loadLevel);
        }
        else if(stageNum == GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedAreas)
        {
            if(levelNum <= GameObject.Find("MrUniverse").GetComponent<TextHolder>().unlockedLevels)
                Application.LoadLevel(loadLevel);

        }
    }
}
