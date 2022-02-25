using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPossession : MonoBehaviour
{
    //[11/12/21] [Friday, 5:42 PM]

    //This script is simple, and is applied to the Weapon Manager gameObject. It keeps track of each weapon
    //that the player is currently in possession of. Essentially, this serves as a reference point for other
    //scripts to ensure that the player has possession of the weapon so they can preform their tasks. If
    //the corresponding boolean is set to true, then the player has the weapon, and nothing in the game can
    //set that inActive as long as the player is alive.


    public bool hasPistol = true;
    public bool hasShotgun = false;
    public bool hasSMG = false;
    public bool hasLewis = false;
    public bool hasGrenade = false;
    public bool hasRocket = false;
    public bool hasFlamethrower = false;

    public void Pistol()
    {
        hasPistol = true;
    }

    public void Shotgun()
    {
        hasShotgun = true;
    }

    public void SMG()
    {
        hasSMG = true;
    }

    public void LMG()
    {
        hasLewis = true;
    }

    public void Grenade()
    {
        hasGrenade = true;
    }

    public void Rocket()
    {
        hasRocket = true;
    }

    public void Flamethrower()
    {
        hasFlamethrower = true;
    }

}
