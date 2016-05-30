using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    //kills player and restarts level
    public AudioClip dead;
    AudioSource fred;
    void Start()
    {
        fred = new AudioSource();
        fred.clip = dead;
    }

    void OnTriggerEnter(Collider col)
    {
        fred.Play();

        GetComponent<GoTo>().Restart();
    }
}
