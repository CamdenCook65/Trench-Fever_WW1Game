using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoKit : MonoBehaviour
{
    //[11/12/21] [Friday, 2:01 PM]

    //This script will be placed on the AmmoKit and will control the function of replenishing ammunition 
    //for the player character. In an OnTriggerEnter event, the object will determine whether the colliding
    //object is the player, then they will determine whether they themselves what weapon they belong too
    //based on their gameObject tag. There are two types of kits per weapon, an AmmoKit and a WeaponKit.
    //AmmoKits simply give the player ammo for an existing weapon while WeaponKits give the player a weapon
    //they currently don't own along with a good deal of ammunition.


    [Header("Pistol")]
    //public bool hasPistol = false;
    public AmmoManager pistol_Ammo;
    public Weapon pistol_Weapon;
    public GameObject pistol_pickup;
    public int pistol_AmmoAmount = 1;
    public int pistol_InitialKit = 5;

    [Header("Revolver")]
    //public bool hasRevolver = false;
    public AmmoManager revolver_Ammo;
    public Weapon revolver_Weapon;
    public GameObject revolver_pickup;
    public int revolver_AmmoAmount = 1;
    public int revolver_InitialKit = 3;

    [Header("Rifle")]
    //public bool hasRifle = false;
    public AmmoManager rifle_Ammo;
    public Weapon rifle_Weapon;
    public GameObject rifle_pickup;
    public int rifle_AmmoAmount = 1;
    public int rifle_InitialKit = 4;

    [Header("Shotgun")]
    //public bool hasShotgun = false;
    public AmmoManager shotgun_Ammo;
    public Weapon shotgun_Weapon;
    public GameObject shotgun_pickup;
    public int shotgun_AmmoAmount = 1;
    public int shotgun_InitialKit = 3;

    [Header("SMG")]
    //public bool hasSMG = false;
    public AmmoManager SMG_Ammo;
    public Weapon SMG_Weapon;
    public GameObject SMG_pickup;
    public int SMG_AmmoAmount = 4;
    public int SMG_InitialKit = 16;

    [Header("Lewis")]
    //public bool hasLMG = false;
    public AmmoManager LMG_Ammo;
    public Weapon LMG_Weapon;
    public GameObject LMG_pickup;
    public int LMG_AmmoAmount = 7;
    public int LMG_InitialKit = 25;

    [Header("Grenade")]
    //public bool hasGrenade = false;
    public AmmoManager launcher_Ammo;
    public Weapon launcher_Weapon;
    public GameObject launcher_pickup;
    public int launcher_AmmoAmount = 1;
    public int launcher_InitialKit = 1;

    [Header("Rocket")]
    //public bool hasRocket = false;
    public AmmoManager rocketGun_Ammo;
    public Weapon rocketGun_Weapon;
    public GameObject rocketGun_pickup;
    public int rocket_AmmoAmount = 1;
    public int rocket_InitialKit = 1;

    [Header("Flamethrower")]
    //public bool hasFlamethrower = false;
    public AmmoManager flamethrower_Ammo;
    public Weapon flamethrower_Weapon;
    public GameObject flamethrower_pickup;
    public int flamethrower_AmmoAmount = 1;
    public int flamethrower_InitialKit = 1;

    [Header("Extras")]
    public EffectOverlays screenEffects;
    public WeaponPossession possesion;


    public void Start()
    {
        pistol_Ammo = GameObject.Find("Pistol_Ammo").GetComponent<AmmoManager>();
        pistol_Weapon = GameObject.Find("Pistol").GetComponent<Weapon>();
        pistol_pickup = GameObject.Find("Pistol_PickupIcon");

        revolver_Ammo = GameObject.Find("Revolver_Ammo").GetComponent<AmmoManager>();
        revolver_Weapon = GameObject.Find("Revolver").GetComponent<Weapon>();
        revolver_pickup = GameObject.Find("Revolver_PickupIcon");

        rifle_Ammo = GameObject.Find("Rifle_Ammo").GetComponent<AmmoManager>();
        rifle_Weapon = GameObject.Find("Rifle").GetComponent<Weapon>();
        rifle_pickup = GameObject.Find("Rifle_PickupIcon");

        shotgun_Ammo = GameObject.Find("Shotgun_Ammo").GetComponent<AmmoManager>();
        shotgun_Weapon = GameObject.Find("Shotgun").GetComponent<Weapon>();
        shotgun_pickup = GameObject.Find("Shotgun_PickupIcon");

        SMG_Ammo = GameObject.Find("SMG_Ammo").GetComponent<AmmoManager>();
        SMG_Weapon = GameObject.Find("MP 18").GetComponent<Weapon>();
        SMG_pickup = GameObject.Find("SMG_PickupIcon");

        LMG_Ammo = GameObject.Find("LMG_Ammo").GetComponent<AmmoManager>();
        LMG_Weapon = GameObject.Find("Lewis").GetComponent<Weapon>();
        LMG_pickup = GameObject.Find("LMG_PickupIcon");

        launcher_Ammo = GameObject.Find("Launcher_Ammo").GetComponent<AmmoManager>();
        launcher_Weapon = GameObject.Find("Grenade Launcher").GetComponent<Weapon>();
        launcher_pickup = GameObject.Find("Grenade_PickupIcon");

        rocketGun_Ammo = GameObject.Find("RocketGun_Ammo").GetComponent<AmmoManager>();
        rocketGun_Weapon = GameObject.Find("Rocket Gun").GetComponent<Weapon>();
        rocketGun_pickup = GameObject.Find("Rocket_PickupIcon");

        flamethrower_Ammo = GameObject.Find("Flamethrower_Ammo").GetComponent<AmmoManager>();
        flamethrower_Weapon = GameObject.Find("Flamethrower").GetComponent<Weapon>();
        flamethrower_pickup = GameObject.Find("Flamethrower_PickupIcon");

        screenEffects = GameObject.Find("Character").GetComponent<EffectOverlays>();
        possesion = GameObject.Find("WeaponManager").GetComponent<WeaponPossession>();
    }


    //Checks to see if the object has collided with the player
    //Then checks the tag of the ammoKit to see what weapon the ammo will go to
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            if (gameObject.tag == "Ammo_PIS")
            {
                //Add 1 bullet to the Pistol
                if (pistol_Ammo.ammoAmount < pistol_Ammo.maximumAmount)
                {
                    pistol_Ammo.ammoAmount += pistol_AmmoAmount;
                    screenEffects.PickedUp();

                    pistol_Weapon.currentAmmo += pistol_AmmoAmount;
                    Destroy(gameObject);

                    Debug.Log("Pistol Ammo Acquired");
                }
            }

            if (gameObject.tag == "WKit_PIS" && possesion.hasPistol == false)
            {
                pistol_Ammo.ammoAmount += pistol_InitialKit;
                screenEffects.PickedUp();

                pistol_Weapon.currentAmmo += pistol_InitialKit;
                Destroy(gameObject);

                possesion.Pistol();
                pistol_pickup.SetActive(true);

                Debug.Log("Pistol Weapon Acquired");
            }








            //if (gameObject.tag == "Ammo_REV")
            //{
                //if (revolver_Ammo.ammoAmount < revolver_Ammo.maximumAmount)
                //{
                    //revolver_Ammo.ammoAmount += revolver_AmmoAmount;
                    //screenEffects.PickedUp();

                    //revolver_Weapon.currentAmmo += revolver_AmmoAmount;
                    //Destroy(gameObject);

                    //Debug.Log("Revolver Ammo Acquired");
                //}
            //}

            //if (gameObject.tag == "WKit_REV" && possesion.hasRevolver == false)
            //{
                //revolver_Ammo.ammoAmount += revolver_InitialKit;
                //screenEffects.PickedUp();

                //revolver_Weapon.currentAmmo += revolver_InitialKit;
                //Destroy(gameObject);

                //possesion.Revolver();
                //revolver_pickup.SetActive(true);


                //Debug.Log("Revolver Weapon Acquired");
            //}








            //if (gameObject.tag == "Ammo_RFL")
            //{
                //if (rifle_Ammo.ammoAmount < rifle_Ammo.maximumAmount)
                //{
                    //rifle_Ammo.ammoAmount += rifle_AmmoAmount;
                    //screenEffects.PickedUp();

                    //rifle_Weapon.currentAmmo += rifle_AmmoAmount;
                    //Destroy(gameObject);
            
                    //Debug.Log("Rifle Ammo Acquired");
                //}
            //}

            //if (gameObject.tag == "WKit_RFL" && possesion.hasRifle == false)
            //{
                //rifle_Ammo.ammoAmount += rifle_InitialKit;
                //screenEffects.PickedUp();

                //rifle_Weapon.currentAmmo += rifle_InitialKit;
                //Destroy(gameObject);

                //possesion.Rifle();
                //rifle_pickup.SetActive(true);


                //Debug.Log("Rifle Weapon Acquired");
            //}








            if (gameObject.tag == "Ammo_SHG")
            {
                if (shotgun_Ammo.ammoAmount < shotgun_Ammo.maximumAmount)
                {
                    shotgun_Ammo.ammoAmount += shotgun_AmmoAmount;
                    screenEffects.PickedUp();

                    shotgun_Weapon.currentAmmo += shotgun_AmmoAmount;
                    Destroy(gameObject);

                    Debug.Log("Shotgun Ammo Acquired");
                }
            }

            if (gameObject.tag == "WKit_SHG" && possesion.hasShotgun == false)
            {
                //shotgun_Ammo.ammoAmount += shotgun_InitialKit;
                screenEffects.PickedUp();

                shotgun_Weapon.currentAmmo += shotgun_InitialKit;
                Destroy(gameObject);

                possesion.Shotgun();
                shotgun_pickup.SetActive(true);


                Debug.Log("Shotgun Weapon Acquired");
            }








            if (gameObject.tag == "Ammo_SMG")
            {
                if (SMG_Ammo.ammoAmount < SMG_Ammo.maximumAmount)
                {
                    SMG_Ammo.ammoAmount += SMG_AmmoAmount;
                    screenEffects.PickedUp();

                    SMG_Weapon.currentAmmo += SMG_AmmoAmount;
                    Destroy(gameObject);

                    Debug.Log("SMG Ammo Acquired");
                }
            }

            if (gameObject.tag == "WKit_SMG" && possesion.hasSMG == false)
            {
                //SMG_Ammo.ammoAmount += SMG_InitialKit;
                screenEffects.PickedUp();

                SMG_Weapon.currentAmmo += SMG_InitialKit;
                Destroy(gameObject);

                possesion.SMG();
                SMG_pickup.SetActive(true);


                Debug.Log("SMG Weapon Acquired");
            }








            if (gameObject.tag == "Ammo_LMG")
            {
                if (LMG_Ammo.ammoAmount < LMG_Ammo.maximumAmount)
                {
                    LMG_Ammo.ammoAmount += LMG_AmmoAmount;
                    screenEffects.PickedUp();

                    LMG_Weapon.currentAmmo += LMG_AmmoAmount;
                    Destroy(gameObject);

                    Debug.Log("LMG Ammo Acquired");
                }
            }

            if (gameObject.tag == "WKit_LMG" && possesion.hasLewis == false)
            {
                //LMG_Ammo.ammoAmount += LMG_InitialKit;
                screenEffects.PickedUp();

                LMG_Weapon.currentAmmo += LMG_InitialKit;
                Destroy(gameObject);

                possesion.LMG();
                LMG_pickup.SetActive(true);


                Debug.Log("LMG Weapon Acquired");
            }








            if (gameObject.tag == "Ammo_GRE")
            {
                if (launcher_Ammo.ammoAmount < launcher_Ammo.maximumAmount)
                {
                    launcher_Ammo.ammoAmount += launcher_AmmoAmount;
                    screenEffects.PickedUp();

                    launcher_Weapon.currentAmmo += launcher_AmmoAmount;
                    Destroy(gameObject);

                    Debug.Log("Grenade Launcher Ammo Acquired");
                }
            }

            if (gameObject.tag == "WKit_GRE" && possesion.hasGrenade == false)
            {
                //launcher_Ammo.ammoAmount += launcher_InitialKit;
                screenEffects.PickedUp();

                launcher_Weapon.currentAmmo += launcher_InitialKit;
                Destroy(gameObject);

                possesion.Grenade();
                launcher_pickup.SetActive(true);


                Debug.Log("Grenade Launcher Weapon Acquired");
            }








            if (gameObject.tag == "Ammo_RKG")
            {
                if (rocketGun_Ammo.ammoAmount < rocketGun_Ammo.maximumAmount)
                {
                    rocketGun_Ammo.ammoAmount += rocket_AmmoAmount;
                    screenEffects.PickedUp();

                    rocketGun_Weapon.currentAmmo += rocket_AmmoAmount;
                    Destroy(gameObject);

                    Debug.Log("RocketGun Ammo Acquired");
                }
            }

            if (gameObject.tag == "WKit_RKG" && possesion.hasRocket == false)
            {
                //rocketGun_Ammo.ammoAmount += rocket_InitialKit;
                screenEffects.PickedUp();

                rocketGun_Weapon.currentAmmo += rocket_InitialKit;
                Destroy(gameObject);

                possesion.Rocket();
                rocketGun_pickup.SetActive(true);


                Debug.Log("RocketGun Weapon Acquired");
            }








            if (gameObject.tag == "Ammo_FLM")
            {
                if (flamethrower_Ammo.ammoAmount < flamethrower_Ammo.maximumAmount)
                {
                    flamethrower_Ammo.ammoAmount += flamethrower_AmmoAmount;
                    screenEffects.PickedUp();

                    flamethrower_Weapon.currentAmmo += flamethrower_AmmoAmount;
                    Destroy(gameObject);

                    Debug.Log("Flamethrower Ammo Acquired");
                }
            }

            if (gameObject.tag == "WKit_FLM" && possesion.hasFlamethrower == false)
            {
                //flamethrower_Ammo.ammoAmount += flamethrower_InitialKit;
                screenEffects.PickedUp();

                flamethrower_Weapon.currentAmmo += flamethrower_InitialKit;
                Destroy(gameObject);

                possesion.Flamethrower();
                flamethrower_pickup.SetActive(true);


                Debug.Log("Flamethrower Weapon Acquired");
            }

        }
    }
}
