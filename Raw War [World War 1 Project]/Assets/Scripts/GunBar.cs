using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBar : MonoBehaviour
{
    //[11/12/21] [Friday, 4:19 PM]

    //The GunBar is nested in the WeaponBar gameObject of the HUD and controls how the WeaponBar operates
    //in game. When the player starts a new level without progression, they will only have their club and
    //a pistol with a max round. All of the other weapon's will need to be found in the level. If the 
    //player doesn't have a weapon yet, the corresponding icon will be dark. A contrast to the yellow icon
    //of an acquired weapon. If the player has a weapon and doesn't have any ammo for it, then the icon
    //will appear red on the WeaponBar. When the player is cycling through their weapons, the weapon they
    //are currently switched too will have a highlight behind the icons. The highlights will be the flag 
    //of the respected nation that primarily used the selected weapon (German Empire for the C96, British
    //for the Lewis, etc.) This script primarily uses a system of If/Ands to set gameObject Active and 
    //Inactive.


    //References to other Scripts
    [Header("Referneces")]
    public WeaponPossession possession;

    //Weapon Icon that depects the weapon WITH ammo
    [Header("Full Weapon Icons")]
    public GameObject club_Icon;
    public GameObject pistol_Icon;
    //public GameObject revolver_Icon;
    //public GameObject rifle_Icon;
    public GameObject shotgun_Icon;
    public GameObject SMG_Icon;
    public GameObject LMG_Icon;
    public GameObject Launcher_Icon;
    public GameObject RocketGun_Icon;
    public GameObject flamethrower_Icon;

    [Header("Unacquired Weapon Icons")]
    //public GameObject revolver_unknown;
    //public GameObject rifle_unknown;
    public GameObject shotgun_unknown;
    public GameObject SMG_unknown;
    public GameObject LMG_unknown;
    public GameObject launcher_unknown;
    public GameObject rocketGun_unknown;
    public GameObject flamethrower_unknown;

    //References to the respected AmmoManager scripts
    [Header("Ammo References")]
    public AmmoManager pistol_Ammo;
    //public AmmoManager revolver_Ammo;
    //public AmmoManager rifle_Ammo;
    public AmmoManager shotgun_Ammo;
    public AmmoManager SMG_Ammo;
    public AmmoManager LMG_Ammo;
    public AmmoManager Launcher_Ammo;
    public AmmoManager RocketGun_Ammo;
    public AmmoManager flamethrower_Ammo;

    //The highlight that showcases a weapon is selected
    [Header("Weapon Highlights")]
    public GameObject club_Check;
    public GameObject pistol_Check;
    //public GameObject revolver_Check;
    //public GameObject rifle_Check;
    public GameObject shotgun_Check;
    public GameObject SMG_Check;
    public GameObject LMG_Check;
    public GameObject Launcher_Check;
    public GameObject RocketGun_Check;
    public GameObject flamethrower_Check;

    void Start()
    {
        club_Icon.SetActive(true);
        pistol_Icon.SetActive(true);
        //revolver_Icon.SetActive(true);
        //rifle_Icon.SetActive(true);
        shotgun_Icon.SetActive(true);
        SMG_Icon.SetActive(true);
        LMG_Icon.SetActive(true);
        Launcher_Icon.SetActive(true);
        RocketGun_Icon.SetActive(true);
        flamethrower_Icon.SetActive(true);

        //revolver_unknown.SetActive(true);
        //rifle_unknown.SetActive(true);
        shotgun_unknown.SetActive(true);
        SMG_unknown.SetActive(true);
        LMG_unknown.SetActive(true);
        launcher_unknown.SetActive(true);
        rocketGun_unknown.SetActive(true);
        flamethrower_unknown.SetActive(true);

        club_Check.SetActive(false);
        pistol_Check.SetActive(true);
        //revolver_Check.SetActive(false);
        //rifle_Check.SetActive(false);
        shotgun_Check.SetActive(false);
        SMG_Check.SetActive(false);
        LMG_Check.SetActive(false);
        Launcher_Check.SetActive(false);
        RocketGun_Check.SetActive(false);
        flamethrower_Check.SetActive(false);
        
    }

    void Update()
    {
        //Checks if the Player is in possession of the corresponding weapons
        //Revolver
        //if(possession.hasRevolver == true)
        //{
            //revolver_unknown.SetActive(false);
        //}

        //Rifle
        //if(possession.hasRifle == true)
        //{
            //rifle_unknown.SetActive(false);
        //}

        //Shotgun
        if(possession.hasShotgun == true)
        {
            shotgun_unknown.SetActive(false);
        }

        //SMG
        if(possession.hasSMG == true)
        {
            SMG_unknown.SetActive(false);
        }

        //Lewis Gun
        if(possession.hasLewis == true)
        {
            LMG_unknown.SetActive(false);
        }

        //Grenade Launcher
        if(possession.hasGrenade == true)
        {
            launcher_unknown.SetActive(false);
        }

        //Rocket Gun
        if(possession.hasRocket == true)
        {
            rocketGun_unknown.SetActive(false);
        }

        //Flamethrower
        if(possession.hasFlamethrower == true)
        {
            flamethrower_unknown.SetActive(false);
        }


        //DETERMINES WHEN THE WEAPON HIGHLIGHT IS SET ACTIVE
        //Club
        if (Input.GetKeyDown(KeyCode.E))
        {
            club_Check.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha6)) || (Input.GetKeyDown(KeyCode.Alpha7))))
        {
            club_Check.SetActive(false);
        }
        
            
        //Pistol    
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol_Check.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha2) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha6)) || (Input.GetKeyDown(KeyCode.Alpha7))))
        {
            pistol_Check.SetActive(false);
        }


        //Revolver
        //if (Input.GetKeyDown(KeyCode.Alpha2) && possession.hasRevolver == true)
        //{
            //revolver_Check.SetActive(true);
        //}

        //if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha6)) || (Input.GetKeyDown(KeyCode.Alpha7)) || (Input.GetKeyDown(KeyCode.Alpha8)) || (Input.GetKeyDown(KeyCode.Alpha9))))
        //{
            //revolver_Check.SetActive(false);
        //}


        //Rifle
        //if (Input.GetKeyDown(KeyCode.Alpha3) && possession.hasRifle == true)
        //{
            //rifle_Check.SetActive(true);
        //}

        //if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha6)) || (Input.GetKeyDown(KeyCode.Alpha7)) || (Input.GetKeyDown(KeyCode.Alpha8)) || (Input.GetKeyDown(KeyCode.Alpha9))))
        //{
            //rifle_Check.SetActive(false);
        //}


        //Shotgun
        if (Input.GetKeyDown(KeyCode.Alpha2) && possession.hasShotgun == true)
        {
            shotgun_Check.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha6)) || (Input.GetKeyDown(KeyCode.Alpha7))))
        {
            shotgun_Check.SetActive(false);
        }


        //SMG
        if (Input.GetKeyDown(KeyCode.Alpha3) && possession.hasSMG == true)
        {
            SMG_Check.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha6)) || (Input.GetKeyDown(KeyCode.Alpha7))))
        {
            SMG_Check.SetActive(false);
        }


        //LMG
        if (Input.GetKeyDown(KeyCode.Alpha4) && possession.hasLewis == true)
        {
            LMG_Check.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha6)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha7))))
        {
            LMG_Check.SetActive(false);
        }


        //Launcher
        if (Input.GetKeyDown(KeyCode.Alpha5) && possession.hasGrenade == true)
        {
            Launcher_Check.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha7)) || (Input.GetKeyDown(KeyCode.Alpha6))))
        {
            Launcher_Check.SetActive(false);
        }


        //RocketGun
        if (Input.GetKeyDown(KeyCode.Alpha6) && possession.hasRocket == true)
        {
            RocketGun_Check.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha7))))
        {
            RocketGun_Check.SetActive(false);
        }


        //Flamethrower
        if (Input.GetKeyDown(KeyCode.Alpha7) && possession.hasFlamethrower == true)
        {
            flamethrower_Check.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha6))))
        {
            flamethrower_Check.SetActive(false);
        }





        //DETERMINES WHEN THE WEAPON ICON IS SET ACTIVE
        //Pistol
        if (pistol_Ammo.ammoAmount <= pistol_Ammo.emptyAmount)
        {
            pistol_Icon.SetActive(false);
        }

        if (pistol_Ammo.ammoAmount > pistol_Ammo.emptyAmount && possession.hasPistol == true)
        {
            pistol_Icon.SetActive(true);
        }


        //Revolver
        //if (revolver_Ammo.ammoAmount <= revolver_Ammo.emptyAmount)
        //{
            //revolver_Icon.SetActive(false);
        //}

        //if (revolver_Ammo.ammoAmount > revolver_Ammo.emptyAmount && possession.hasRevolver == true)
        //{
            //revolver_Icon.SetActive(true);
        //}


        //Rifle
        //if (rifle_Ammo.ammoAmount <= rifle_Ammo.emptyAmount)
        //{
            //rifle_Icon.SetActive(false);
        //}

        //if (rifle_Ammo.ammoAmount > rifle_Ammo.emptyAmount && possession.hasRifle == true)
        //{
            //rifle_Icon.SetActive(true);
        //}


        //Shotgun
        if (shotgun_Ammo.ammoAmount <= shotgun_Ammo.emptyAmount)
        {
            shotgun_Icon.SetActive(false);
        }

        if (shotgun_Ammo.ammoAmount > shotgun_Ammo.emptyAmount && possession.hasShotgun == true)
        {
            shotgun_Icon.SetActive(true);
        }


        //SMG
        if (SMG_Ammo.ammoAmount <= SMG_Ammo.emptyAmount)
        {
            SMG_Icon.SetActive(false);
        }

        if (SMG_Ammo.ammoAmount > SMG_Ammo.emptyAmount && possession.hasSMG == true)
        {
            SMG_Icon.SetActive(true);
        }


        //LMG
        if (LMG_Ammo.ammoAmount <= LMG_Ammo.emptyAmount)
        {
            LMG_Icon.SetActive(false);
        }

        if (LMG_Ammo.ammoAmount > LMG_Ammo.emptyAmount && possession.hasLewis == true)
        {
            LMG_Icon.SetActive(true);
        }


        //Launcher
        if (Launcher_Ammo.ammoAmount <= Launcher_Ammo.emptyAmount)
        {
            Launcher_Icon.SetActive(false);
        }

        if (Launcher_Ammo.ammoAmount > Launcher_Ammo.emptyAmount && possession.hasGrenade == true)
        {
            Launcher_Icon.SetActive(true);
        }


        //RocketGun
        if (RocketGun_Ammo.ammoAmount <= RocketGun_Ammo.emptyAmount)
        {
            RocketGun_Icon.SetActive(false);
        }


        if (RocketGun_Ammo.ammoAmount > RocketGun_Ammo.emptyAmount && possession.hasRocket == true)
        {
            RocketGun_Icon.SetActive(true);
        }


        //Flamethrower
        if (flamethrower_Ammo.ammoAmount <= flamethrower_Ammo.emptyAmount)
        {
            flamethrower_Icon.SetActive(false);
        }

        if (flamethrower_Ammo.ammoAmount > flamethrower_Ammo.emptyAmount && possession.hasFlamethrower == true)
        {
            flamethrower_Icon.SetActive(true);
        }

    }
}
