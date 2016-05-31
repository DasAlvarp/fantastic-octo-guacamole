using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    //kills player and restarts level
    public AudioClip dead;
    AudioSource fred;
    void Start()
    {
        fred = new AudioSource();
        if(dead != null )
        {
            try
            {
                fred.clip = dead;

                Debug.Log(dead.name);
            }
            catch
            {
                Debug.Log("There is no sound");
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        fred.Play();

        GetComponent<GoTo>().Restart();
    }
}
