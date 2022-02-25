using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour
{
    //[11/12/21] [Friday, 4:35 PM]

    //This script will be located in any gameObject that would prevent the player from jumping (Barbed wire,
    //Mud pits, etc). The script will check if a gameObject with the tag "Player" has entered their collider.
    //If so, then the canJump boolean in the player's Health script will be set to false. This will prevent
    //the player from jumping. Whenever the player exits the collider, then the boolean will be set active
    //and they will be allowed to jump again!


    public FirstPersonCharacter character;
    public Collider collision;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Do Something
            character.canJump = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Do Something
            character.canJump = true;
        }
    }
}
