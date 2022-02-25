using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //[11/12/21] [Friday, 5:40 PM]

    //The WeaponManager, applied to the Weapon Manager gameObject, keeps track if which weapon to setActive
    //based on what weapon select button the player pressed. The script also sets the respected 
    //AmmoManagers active whenever a weapon is selected. Essentially, if the player is not dead, 
    //has pressed the corresponding button, and currently possess the weapon, then the weapon will be set
    //active while the other weapons will be setInactive.


    public GameObject player;
    public WeaponPossession weapon;

    public GameObject ammoManager01;
    public GameObject ammoManager02;
    public GameObject ammoManager03;
    public GameObject ammoManager04;
    public GameObject ammoManager05;
    public GameObject ammoManager06;
    public GameObject ammoManager07;
    //public GameObject ammoManager08;
    //public GameObject ammoManager09;

    public GameObject HUDicons01;
    public GameObject HUDicons02;
    public GameObject HUDicons03;
    public GameObject HUDicons04;
    public GameObject HUDicons05;
    public GameObject HUDicons06;
    public GameObject HUDicons07;
    //public GameObject HUDicons08;
    //public GameObject HUDicons09;

    void Update()
    {
        //Set Corresponding ammo manager active
        //Set Ammo HUD icons active
        if (player != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ammoManager01.SetActive(false);
                ammoManager02.SetActive(false);
                ammoManager03.SetActive(false);
                ammoManager04.SetActive(false);
                ammoManager05.SetActive(false);
                ammoManager06.SetActive(false);
                ammoManager07.SetActive(false);
                //ammoManager08.SetActive(false);
                //ammoManager09.SetActive(false);

                HUDicons01.SetActive(false);
                HUDicons02.SetActive(false);
                HUDicons03.SetActive(false);
                HUDicons04.SetActive(false);
                HUDicons05.SetActive(false);
                HUDicons06.SetActive(false);
                HUDicons07.SetActive(false);
                //HUDicons08.SetActive(false);
                //HUDicons09.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ammoManager01.SetActive(true);
                ammoManager02.SetActive(false);
                ammoManager03.SetActive(false);
                ammoManager04.SetActive(false);
                ammoManager05.SetActive(false);
                ammoManager06.SetActive(false);
                ammoManager07.SetActive(false);
                //ammoManager08.SetActive(false);
                //ammoManager09.SetActive(false);

                HUDicons01.SetActive(true);
                HUDicons02.SetActive(false);
                HUDicons03.SetActive(false);
                HUDicons04.SetActive(false);
                HUDicons05.SetActive(false);
                HUDicons06.SetActive(false);
                HUDicons07.SetActive(false);
                //HUDicons08.SetActive(false);
                //HUDicons09.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && weapon.hasShotgun == true)
            {
                ammoManager01.SetActive(false);
                ammoManager02.SetActive(true);
                ammoManager03.SetActive(false);
                ammoManager04.SetActive(false);
                ammoManager05.SetActive(false);
                ammoManager06.SetActive(false);
                ammoManager07.SetActive(false);
                //ammoManager08.SetActive(false);
                //ammoManager09.SetActive(false);

                HUDicons01.SetActive(false);
                HUDicons02.SetActive(true);
                HUDicons03.SetActive(false);
                HUDicons04.SetActive(false);
                HUDicons05.SetActive(false);
                HUDicons06.SetActive(false);
                HUDicons07.SetActive(false);
                //HUDicons08.SetActive(false);
                //HUDicons09.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && weapon.hasSMG == true)
            {
                ammoManager01.SetActive(false);
                ammoManager02.SetActive(false);
                ammoManager03.SetActive(true);
                ammoManager04.SetActive(false);
                ammoManager05.SetActive(false);
                ammoManager06.SetActive(false);
                ammoManager07.SetActive(false);
                //ammoManager08.SetActive(false);
                //ammoManager09.SetActive(false);

                HUDicons01.SetActive(false);
                HUDicons02.SetActive(false);
                HUDicons03.SetActive(true);
                HUDicons04.SetActive(false);
                HUDicons05.SetActive(false);
                HUDicons06.SetActive(false);
                HUDicons07.SetActive(false);
                //HUDicons08.SetActive(false);
                //HUDicons09.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && weapon.hasLewis == true)
            {
                ammoManager01.SetActive(false);
                ammoManager02.SetActive(false);
                ammoManager03.SetActive(false);
                ammoManager04.SetActive(true);
                ammoManager05.SetActive(false);
                ammoManager06.SetActive(false);
                ammoManager07.SetActive(false);
                //ammoManager08.SetActive(false);
                //ammoManager09.SetActive(false);

                HUDicons01.SetActive(false);
                HUDicons02.SetActive(false);
                HUDicons03.SetActive(false);
                HUDicons04.SetActive(true);
                HUDicons05.SetActive(false);
                HUDicons06.SetActive(false);
                HUDicons07.SetActive(false);
                //HUDicons08.SetActive(false);
                //HUDicons09.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha5) && weapon.hasGrenade == true)
            {
                ammoManager01.SetActive(false);
                ammoManager02.SetActive(false);
                ammoManager03.SetActive(false);
                ammoManager04.SetActive(false);
                ammoManager05.SetActive(true);
                ammoManager06.SetActive(false);
                ammoManager07.SetActive(false);
                //ammoManager08.SetActive(false);
                //ammoManager09.SetActive(false);

                HUDicons01.SetActive(false);
                HUDicons02.SetActive(false);
                HUDicons03.SetActive(false);
                HUDicons04.SetActive(false);
                HUDicons05.SetActive(true);
                HUDicons06.SetActive(false);
                HUDicons07.SetActive(false);
                //HUDicons08.SetActive(false);
                //HUDicons09.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha6) && weapon.hasRocket == true)
            {
                ammoManager01.SetActive(false);
                ammoManager02.SetActive(false);
                ammoManager03.SetActive(false);
                ammoManager04.SetActive(false);
                ammoManager05.SetActive(false);
                ammoManager06.SetActive(true);
                ammoManager07.SetActive(false);
                //ammoManager08.SetActive(false);
                //ammoManager09.SetActive(false);

                HUDicons01.SetActive(false);
                HUDicons02.SetActive(false);
                HUDicons03.SetActive(false);
                HUDicons04.SetActive(false);
                HUDicons05.SetActive(false);
                HUDicons06.SetActive(true);
                HUDicons07.SetActive(false);
                //HUDicons08.SetActive(false);
                //HUDicons09.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.Alpha7) && weapon.hasFlamethrower == true)
            {
                ammoManager01.SetActive(false);
                ammoManager02.SetActive(false);
                ammoManager03.SetActive(false);
                ammoManager04.SetActive(false);
                ammoManager05.SetActive(false);
                ammoManager06.SetActive(false);
                ammoManager07.SetActive(true);
                //ammoManager08.SetActive(false);
                //ammoManager09.SetActive(false);

                HUDicons01.SetActive(false);
                HUDicons02.SetActive(false);
                HUDicons03.SetActive(false);
                HUDicons04.SetActive(false);
                HUDicons05.SetActive(false);
                HUDicons06.SetActive(false);
                HUDicons07.SetActive(true);
                //HUDicons08.SetActive(false);
                //HUDicons09.SetActive(false);

            }
        }
    }
}
