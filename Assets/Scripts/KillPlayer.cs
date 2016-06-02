using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    //kills player and restarts level
    public AudioClip dead;
    AudioSource fred;
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        fred = gameObject.AddComponent<AudioSource>();
        fred.playOnAwake = false;
        fred.clip = dead;
        fred.Play();
        col.gameObject.SetActive(false);
        StartCoroutine(WaitForFred(fred));
    }

    IEnumerator WaitForFred(AudioSource fred)
    {
        while(fred.isPlaying)
        {
            yield return null;
        }
        GetComponent<GoTo>().Restart();
        yield return null;
    }
}
