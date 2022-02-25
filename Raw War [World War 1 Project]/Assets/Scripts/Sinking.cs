using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinking : MonoBehaviour
{
    //[11/12/21] [Friday, 5:14 PM]

    //In this script, applied to any gameObject that you want to effect player height (Mud Pit), will lower
    //the Player's capsule collider height if they make contact with it. The gameObject will check if they
    //have made contact with another object with the tag "Player". If so, then the OnTriggerEnter will
    //play an enterSplash sound effect. In the OnTriggerStay function, the script will lower the player's 
    //height over a period of time known as sinkingTime. If the player reached a height value known as
    //final height, then they will be killed in a death event known as Drown(). If the player were to leave
    //the collider before death, they will return to their normal height and play an exitSplash sound effect.


    public Health playerHealth;
    public FirstPersonCharacter character;
    public CapsuleCollider player;
    public float sinkingTime;
    public float tickInterger;
    public float finalHeight;
    public float regainTime;
    public AudioSource enterSplash;
    public AudioSource exitSplash;
    public AudioSource wade;
    public AudioSource drown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Do Something
            enterSplash.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Do Something
            character.HeightAdjust = true;
            character.adjustingHeight();
            player.height -= Time.deltaTime * sinkingTime;
            wade.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Do Something
            player.height = 2f;

            //if (player.height != 2f)
            {
                //player.height += Time.deltaTime * regainTime;
            }
            //else
            {
                //player.height = 2f;
            }


            exitSplash.Play();
        }
    }

    private void Update()
    {
        if (player.height <= finalHeight)
        {
            playerHealth.Drown();
        }
    }
}
