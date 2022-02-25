using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    //[11/12/21] [Friday, 4:29 PM]

    //This is a simple script that is applied to any HealthKits. The gameObject will use OnTriggerEnter to
    //determine wheather a gameObject with the tag "Player" has made contact with it. If it has, then the
    //script will reference back to the Player's Health to see if their health is full. If the Player's 
    //health is full, then nothing happens. If the health isn't full, then the HealthKit will destroy itself.
    


    public Health player;

    //Checks to see if the object has collided with the player
    //Then checks if the player's healthFull bool is true or false
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player.healthFull == false)
            {
                Destroy(gameObject);
            }
        }
    }
}
