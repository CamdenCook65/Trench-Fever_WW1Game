using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    //[11/12/21] [Friday, 4:52 PM]

    //This script, located in the Character gameObject, will check if the player has made contact with
    //projectiles thrown by enemies. It will use a OnTiggerEnter to see if the player has come in contact
    //with gameObjects with the tags "Attack_Stormtrooper" or "Attack_TrenchRat". If the player is hit by
    //a Stormtrooper projectile, then they will deal one damage and can kill the player if their health is
    //at a value of one. If the player is hit by a Trench Rat projectile (an invisible close-range attack),
    //then they will deal one damage but player's are unable to die if their health is at one (similar to
    //can die boolean in the Deplete script).


    public Health playerHealth;
    public EffectOverlays damagedEffect;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack_Infantryman")
        {
            //Damage Player
            playerHealth.currentHealth -= 1;
            damagedEffect.Damaged();

            if (playerHealth.currentHealth < 1)
            {
                playerHealth.Die();
            }
        }



        if (other.tag == "Attack_Stormtrooper")
        {
            //Damage Player
            playerHealth.currentHealth -= 1;
            damagedEffect.Damaged();

            if (playerHealth.currentHealth < 1)
            {
                playerHealth.Die();
            }
        }



        if (other.tag == "Attack_Officer")
        {
            //Damage Player
            playerHealth.currentHealth -= 1;
            damagedEffect.Damaged();

            if (playerHealth.currentHealth < 1)
            {
                playerHealth.Die();
            }
        }



        if (other.tag == "Attack_Grenadier")
        {
            //Damage Player
            playerHealth.currentHealth -= 1;
            damagedEffect.Damaged();

            if (playerHealth.currentHealth < 1)
            {
                playerHealth.Die();
            }
        }



        if (other.tag == "Attack_Rocketeer")
        {
            //Damage Player
            playerHealth.currentHealth -= 1;
            damagedEffect.Damaged();

            if (playerHealth.currentHealth < 1)
            {
                playerHealth.Die();
            }
        }



        if (other.tag == "Attack_Flametrooper")
        {
            //Damage Player
            playerHealth.currentHealth -= 1;
            damagedEffect.Damaged();

            if (playerHealth.currentHealth < 1)
            {
                playerHealth.Die();
            }
        }



        if (other.tag == "Attack_TrenchRat")
        {
            if (playerHealth.currentHealth > 1)
            {
                //Damage Player
                playerHealth.currentHealth -= 1;
                damagedEffect.Damaged();
            }
        }
    }

}
