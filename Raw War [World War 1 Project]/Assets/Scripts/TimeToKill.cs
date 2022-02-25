using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToKill : MonoBehaviour
{
    //[11/12/21] [Friday, 5:30 PM]

    //TimeToKIll essentially takes the death parameters from the gasCloud script and applied itself to it's
    //own script. This will be applied to objects that will kill the player after a designated amount of
    //time inside of it (Sniper Range). Like literally half if these scripts, it will check if a gameObject
    //with the tag "Player" has made contact with the collider. If so, then the script will start a 
    //Coroutine. After a designated amount of time (killTime), the player will be killed. The coroutine is 
    //stopped whenever the player leaves the collider.


    public Health playerHealth;
    public FirstPersonCharacter character;
    public float killTime = 0.5f;
    public AudioSource SFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("ExampleCoroutine");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Do Something
            character.sprinting = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopCoroutine("ExampleCoroutine");
        }
    }



    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(killTime);
        while (true)
        {
            Killed();
        }
    }

    void Killed()
    {
        playerHealth.Die();
        SFX.Play();
    }
}
