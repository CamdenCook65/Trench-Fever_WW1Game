using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFade : MonoBehaviour
{
    public AudioSource audiosource;
    public int waitTime = 6;


    void Start()
    {
        StartCoroutine("Coroutine"); 
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(waitTime);

        while (audiosource.volume > 0)
        {
            yield return null;
            audiosource.volume-= Time.deltaTime;
        }
    }


}
