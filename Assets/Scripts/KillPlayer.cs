using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    //kills player and restarts level
    public AudioClip dead;
    public AudioSource fred;
    void Start()
    {
        fred.clip = dead;
    }

    void OnCollisionEnter(Collision col)
    {
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
