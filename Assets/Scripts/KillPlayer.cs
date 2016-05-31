using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    //kills player and restarts level
    public AudioClip dead;
    public AudioSource fred;
    void Start()
    {
        fred = Instantiate(new AudioSource());
        fred.clip = dead;
    }

    void OnCollisionEnter(Collision col)
    {
        fred.Play();
        Destroy(col.gameObject);
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
