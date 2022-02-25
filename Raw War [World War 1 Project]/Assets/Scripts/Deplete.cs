using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplete : MonoBehaviour
{
    //[11/12/21] [Friday, 3:17 PM]

    //This script will be applied to gameObjects that are meant to deplete the player's health, including
    //Barbed Wire and Phosphorous Gas. The gameobject will routinely check if a gameObject with the tag 
    //"Player" is currently colliding with it. If the player is in the gameObject, the a Coroutine will be
    //called that will deplete the player's health after a designated time called bleedTime. The coroutine
    //is restarted whenever the next one ends. A boolean called canKill will determine whether the coroutine
    //stops when the player's health is at one (saving them from death), or continue anyways and kills them.
    


    public Health playerHealth;
    public float bleedTime;
    public bool canKill;
    public AudioClip damageTaken;
    public AudioClip tangled;
    public EffectOverlays damagedEffect;

    private void Update()
    {
        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent(typeof(AudioSource));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("ExampleCoroutine");
            GetComponent<AudioSource>().PlayOneShot(tangled);
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
        yield return new WaitForSeconds(bleedTime);

        PlayerBleed();

        StartCoroutine("ExampleCoroutine");
    }

    void PlayerBleed()
    {
        if (canKill == true)
        {
            //Can kill the player 
            playerHealth.currentHealth -= 1;

            if (playerHealth.dead != true)
            {
                damagedEffect.Damaged();
                GetComponent<AudioSource>().PlayOneShot(damageTaken);
            }

            Debug.Log("can Kill: Subtract 1 Health!");

            if(playerHealth.currentHealth < 1)
            {
                playerHealth.BleedToDeath();
            }
        }

        if (canKill == false)
        {
            //Can only wear away at armor
            if (playerHealth.currentHealth > 1)
            {
                playerHealth.currentHealth -= 1;

                if (playerHealth.dead != true)
                {
                    damagedEffect.Damaged();
                    GetComponent<AudioSource>().PlayOneShot(damageTaken);
                }

                Debug.Log("can't Kill: Subtract 1 Health!");
            }

        }
    }

}
