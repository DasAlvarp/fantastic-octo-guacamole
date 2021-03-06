﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo : MonoBehaviour
{  
    //reloads level if not given a level.
    public void GoToStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToStage(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Restart()
    {
        GoToStage();
    }

    public void Quit()
    {
        Application.Quit();
    }
}