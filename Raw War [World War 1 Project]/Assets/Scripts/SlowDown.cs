using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    //[11/12/21] [Friday, 5:22 PM]

    //The SlowDown script is applied to any gameObject that will slow player movement (Tear Gas, Barbed Wire,
    //Mud Pit, etc). It will detect whether a gameObject with the tag "Player" has entered it's collision. 
    //If so, then it will applied the function SlowMovement. SlowMovement means that the slowMovement
    //boolean in the FirstPersonCharacter script is true. If the player exits the collider, then
    //NormalMovement is called, which sets the boolean to false.


    public Health playerHealth;
    public FirstPersonCharacter character;
    //public bool slowed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SlowedMovement();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            NormalMovement();
        }

    }


    void SlowedMovement()
    {
        character.slowMovement = true;
    }

    void NormalMovement()
    {
        character.slowMovement = false;
    }

}