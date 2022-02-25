using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    //[11/12/21] [Friday, 2:10 PM]

    //This is the AmmoManager, and it was originally going to be more involved with the AmmoIcons system
    //on the HUD but unfortunately I couldn't find a good way to make the system work using GameObject
    //arrays, perhaps I could find a more preformance friendly method in the future. Any who, the script 
    //now serves the purpose of housing ammo-related data for each of the weapons, something that can be
    //referenced from other scripts such as the Easy Weapons' "Weapon" and my own "AmmoKit" script. The 
    //ammo's current value, starting value, maximum value and empty value are all displayed in this script.
    //This script is vital for the AmmoKits to function and keeps the ammunition amount in this and the
    //Weapon script at an equal value. It's not much, but it's doing a great job!


    [SerializeField]
    //public GameObject[] ammo;
    public int ammoAmount;
    public int startingAmount;
    public int maximumAmount;
    public int emptyAmount = 0;
    public bool fullAmmo;
    public Weapon reference;

    private void Start()
    {
        ammoAmount = startingAmount;
    }

    public void Update()
    {
        if (ammoAmount == maximumAmount)
        {
            fullAmmo = true;
        }
        else
        {
            fullAmmo = false;
        }
    }
}
