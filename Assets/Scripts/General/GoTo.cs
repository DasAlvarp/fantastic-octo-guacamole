using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo : MonoBehaviour {
    //manages game state.
    
        //reloads level if not given a level.
    public void GoToStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToStage(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}