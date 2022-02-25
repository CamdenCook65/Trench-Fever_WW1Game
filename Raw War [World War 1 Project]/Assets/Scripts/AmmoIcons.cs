using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoIcons : MonoBehaviour
{
    //[11/12/21] [Friday, 1:51 PM]

    //Camden Cook, this is it... I couldn't figure out a better method of getting my ammoIcons to properly 
    //present themselves in a manner that I found satisfactory. I am so incredibly difficult to please that
    //I slaved away to create these 1,200 lines of code simply to get my HUD to accurretly reflect how many
    //bullets I have left on my gun. It could have been much worse, I could have addressed each AmmoIcon per
    //number instead of simply one per number if the amount if equal to or greater. A method with gameobject
    //arrays wouldn't properly work (because my rookie 4 years of experience is showing) so I resorted to my
    //most ashamed method to date. Maybe in the future when I look back on this code (with all of the years 
    //of experience I would SURELY have), I can either feel like my past self is a complete dumbass or I 
    //could have a full understanding that this isn't half bad and that I'm overreacting to something I 
    //know nothing about, pick your poison...

    //So this script is simple, I preform a check for each of AmmoIcons to see if my AmmoAmount value is 
    //equal to or greater than a certain number. If it is, then the corresponding AmmoIcon is set active. 
    //If it's not, then it will be setInactive. Here is a visualized example:


            //If (shotgun.ammoAmount >= 4)
            //{
                    //shotgun_Ammo04.SetActive(true);
            //}

            //else
            //{
                    //shotgun_Ammo04.SetActive(false);
            //}


    [Header("Pistol")]
    public AmmoManager pistol;
    public GameObject pistol_Ammo01;
    public GameObject pistol_Ammo02;
    public GameObject pistol_Ammo03;
    public GameObject pistol_Ammo04;
    public GameObject pistol_Ammo05;
    public GameObject pistol_Ammo06;
    public GameObject pistol_Ammo07;
    public GameObject pistol_Ammo08;
    public GameObject pistol_Ammo09;
    public GameObject pistol_Ammo10;

    [Header("Shotgun")]
    public AmmoManager shotgun;
    public GameObject shotgun_Ammo01;
    public GameObject shotgun_Ammo02;
    public GameObject shotgun_Ammo03;
    public GameObject shotgun_Ammo04;
    public GameObject shotgun_Ammo05;

    [Header("SMG")]
    public AmmoManager SMG;
    public GameObject SMG_Ammo01;
    public GameObject SMG_Ammo02;
    public GameObject SMG_Ammo03;
    public GameObject SMG_Ammo04;
    public GameObject SMG_Ammo05;
    public GameObject SMG_Ammo06;
    public GameObject SMG_Ammo07;
    public GameObject SMG_Ammo08;
    public GameObject SMG_Ammo09;
    public GameObject SMG_Ammo10;
    public GameObject SMG_Ammo11;
    public GameObject SMG_Ammo12;
    public GameObject SMG_Ammo13;
    public GameObject SMG_Ammo14;
    public GameObject SMG_Ammo15;
    public GameObject SMG_Ammo16;
    public GameObject SMG_Ammo17;
    public GameObject SMG_Ammo18;
    public GameObject SMG_Ammo19;
    public GameObject SMG_Ammo20;
    public GameObject SMG_Ammo21;
    public GameObject SMG_Ammo22;
    public GameObject SMG_Ammo23;
    public GameObject SMG_Ammo24;
    public GameObject SMG_Ammo25;
    public GameObject SMG_Ammo26;
    public GameObject SMG_Ammo27;
    public GameObject SMG_Ammo28;
    public GameObject SMG_Ammo29;
    public GameObject SMG_Ammo30;
    public GameObject SMG_Ammo31;
    public GameObject SMG_Ammo32;

    [Header("Lewis")]
    public AmmoManager Lewis;
    public GameObject Lewis_Ammo01;
    public GameObject Lewis_Ammo02;
    public GameObject Lewis_Ammo03;
    public GameObject Lewis_Ammo04;
    public GameObject Lewis_Ammo05;
    public GameObject Lewis_Ammo06;
    public GameObject Lewis_Ammo07;
    public GameObject Lewis_Ammo08;
    public GameObject Lewis_Ammo09;
    public GameObject Lewis_Ammo10;
    public GameObject Lewis_Ammo11;
    public GameObject Lewis_Ammo12;
    public GameObject Lewis_Ammo13;
    public GameObject Lewis_Ammo14;
    public GameObject Lewis_Ammo15;
    public GameObject Lewis_Ammo16;
    public GameObject Lewis_Ammo17;
    public GameObject Lewis_Ammo18;
    public GameObject Lewis_Ammo19;
    public GameObject Lewis_Ammo20;
    public GameObject Lewis_Ammo21;
    public GameObject Lewis_Ammo22;
    public GameObject Lewis_Ammo23;
    public GameObject Lewis_Ammo24;
    public GameObject Lewis_Ammo25;
    public GameObject Lewis_Ammo26;
    public GameObject Lewis_Ammo27;
    public GameObject Lewis_Ammo28;
    public GameObject Lewis_Ammo29;
    public GameObject Lewis_Ammo30;
    public GameObject Lewis_Ammo31;
    public GameObject Lewis_Ammo32;
    public GameObject Lewis_Ammo33;
    public GameObject Lewis_Ammo34;
    public GameObject Lewis_Ammo35;
    public GameObject Lewis_Ammo36;
    public GameObject Lewis_Ammo37;
    public GameObject Lewis_Ammo38;
    public GameObject Lewis_Ammo39;
    public GameObject Lewis_Ammo40;
    public GameObject Lewis_Ammo41;
    public GameObject Lewis_Ammo42;
    public GameObject Lewis_Ammo43;
    public GameObject Lewis_Ammo44;
    public GameObject Lewis_Ammo45;
    public GameObject Lewis_Ammo46;
    public GameObject Lewis_Ammo47;

    [Header("Grenade")]
    public AmmoManager grenade;
    public GameObject grenade_Ammo01;
    public GameObject grenade_Ammo02;
    public GameObject grenade_Ammo03;

    [Header("Rocket")]
    public AmmoManager rocket;
    public GameObject rocket_Ammo01;

    [Header("Flamethrower")]
    public AmmoManager flamethrower;
    public GameObject flame_Ammo01;




    public void Update()
    {
        //Pistol Ammo Icons
        if (pistol.ammoAmount >= 1)
        {
            pistol_Ammo01.SetActive(true);
        }
        else
        {
            pistol_Ammo01.SetActive(false);
        }



        if (pistol.ammoAmount >= 2)
        {
            pistol_Ammo02.SetActive(true);
        }
        else
        {
            pistol_Ammo02.SetActive(false);
        }



        if (pistol.ammoAmount >= 3)
        {
            pistol_Ammo03.SetActive(true);
        }
        else
        {
            pistol_Ammo03.SetActive(false);
        }



        if (pistol.ammoAmount >= 4)
        {
            pistol_Ammo04.SetActive(true);
        }
        else
        {
            pistol_Ammo04.SetActive(false);
        }



        if (pistol.ammoAmount >= 5)
        {
            pistol_Ammo05.SetActive(true);
        }
        else
        {
            pistol_Ammo05.SetActive(false);
        }



        if (pistol.ammoAmount >= 6)
        {
            pistol_Ammo06.SetActive(true);
        }
        else
        {
            pistol_Ammo06.SetActive(false);
        }



        if (pistol.ammoAmount >= 7)
        {
            pistol_Ammo07.SetActive(true);
        }
        else
        {
            pistol_Ammo07.SetActive(false);
        }



        if (pistol.ammoAmount >= 8)
        {
            pistol_Ammo08.SetActive(true);
        }
        else
        {
            pistol_Ammo08.SetActive(false);
        }



        if (pistol.ammoAmount >= 9)
        {
            pistol_Ammo09.SetActive(true);
        }
        else
        {
            pistol_Ammo09.SetActive(false);
        }



        if (pistol.ammoAmount >= 10)
        {
            pistol_Ammo10.SetActive(true);
        }
        else
        {
            pistol_Ammo10.SetActive(false);
        }








        //Shotgun
        if (shotgun.ammoAmount >= 1)
        {
            shotgun_Ammo01.SetActive(true);
        }
        else
        {
            shotgun_Ammo01.SetActive(false);
        }



        if (shotgun.ammoAmount >= 2)
        {
            shotgun_Ammo02.SetActive(true);
        }
        else
        {
            shotgun_Ammo02.SetActive(false);
        }



        if (shotgun.ammoAmount >= 3)
        {
            shotgun_Ammo03.SetActive(true);
        }
        else
        {
            shotgun_Ammo03.SetActive(false);

        }



        if (shotgun.ammoAmount >= 4)
        {
            shotgun_Ammo04.SetActive(true);
        }
        else
        {
            shotgun_Ammo04.SetActive(false);
        }



        if (shotgun.ammoAmount >= 5)
        {
            shotgun_Ammo05.SetActive(true);
        }
        else
        {
            shotgun_Ammo05.SetActive(false);
        }








        //SMG
        if (SMG.ammoAmount >= 1)
        {
            SMG_Ammo01.SetActive(true);
        }
        else
        {
            SMG_Ammo01.SetActive(false);
        }



        if (SMG.ammoAmount >= 2)
        {
            SMG_Ammo02.SetActive(true);
        }
        else
        {
            SMG_Ammo02.SetActive(false);
        }



        if (SMG.ammoAmount >= 3)
        {
            SMG_Ammo03.SetActive(true);
        }
        else
        {
            SMG_Ammo03.SetActive(false);
        }



        if (SMG.ammoAmount >= 4)
        {
            SMG_Ammo04.SetActive(true);
        }
        else
        {
            SMG_Ammo04.SetActive(false);
        }



        if (SMG.ammoAmount >= 5)
        {
            SMG_Ammo05.SetActive(true);
        }
        else
        {
            SMG_Ammo05.SetActive(false);
        }



        if (SMG.ammoAmount >= 6)
        {
            SMG_Ammo06.SetActive(true);
        }
        else
        {
            SMG_Ammo06.SetActive(false);
        }



        if (SMG.ammoAmount >= 7)
        {
            SMG_Ammo07.SetActive(true);
        }
        else
        {
            SMG_Ammo07.SetActive(false);
        }



        if (SMG.ammoAmount >= 8)
        {
            SMG_Ammo08.SetActive(true);
        }
        else
        {
            SMG_Ammo08.SetActive(false);
        }



        if (SMG.ammoAmount >= 9)
        {
            SMG_Ammo09.SetActive(true);
        }
        else
        {
            SMG_Ammo09.SetActive(false);
        }



        if (SMG.ammoAmount >= 10)
        {
            SMG_Ammo10.SetActive(true);
        }
        else
        {
            SMG_Ammo10.SetActive(false);
        }



        if (SMG.ammoAmount >= 11)
        {
            SMG_Ammo11.SetActive(true);
        }
        else
        {
            SMG_Ammo11.SetActive(false);
        }



        if (SMG.ammoAmount >= 12)
        {
            SMG_Ammo12.SetActive(true);
        }
        else
        {
            SMG_Ammo12.SetActive(false);
        }



        if (SMG.ammoAmount >= 13)
        {
            SMG_Ammo13.SetActive(true);
        }
        else
        {
            SMG_Ammo13.SetActive(false);
        }



        if (SMG.ammoAmount >= 14)
        {
            SMG_Ammo14.SetActive(true);
        }
        else
        {
            SMG_Ammo14.SetActive(false);
        }



        if (SMG.ammoAmount >= 15)
        {
            SMG_Ammo15.SetActive(true);
        }
        else
        {
            SMG_Ammo15.SetActive(false);
        }



        if (SMG.ammoAmount >= 16)
        {
            SMG_Ammo16.SetActive(true);
        }
        else
        {
            SMG_Ammo16.SetActive(false);
        }



        if (SMG.ammoAmount >= 17)
        {
            SMG_Ammo17.SetActive(true);
        }
        else
        {
            SMG_Ammo17.SetActive(false);
        }



        if (SMG.ammoAmount >= 18)
        {
            SMG_Ammo18.SetActive(true);
        }
        else
        {
            SMG_Ammo18.SetActive(false);
        }



        if (SMG.ammoAmount >= 19)
        {
            SMG_Ammo19.SetActive(true);
        }
        else
        {
            SMG_Ammo19.SetActive(false);
        }



        if (SMG.ammoAmount >= 20)
        {
            SMG_Ammo20.SetActive(true);
        }
        else
        {
            SMG_Ammo20.SetActive(false);
        }



        if (SMG.ammoAmount >= 21)
        {
            SMG_Ammo21.SetActive(true);
        }
        else
        {
            SMG_Ammo21.SetActive(false);
        }



        if (SMG.ammoAmount >= 22)
        {
            SMG_Ammo22.SetActive(true);
        }
        else
        {
            SMG_Ammo22.SetActive(false);
        }



        if (SMG.ammoAmount >= 23)
        {
            SMG_Ammo23.SetActive(true);
        }
        else
        {
            SMG_Ammo23.SetActive(false);
        }



        if (SMG.ammoAmount >= 24)
        {
            SMG_Ammo24.SetActive(true);
        }
        else
        {
            SMG_Ammo24.SetActive(false);
        }



        if (SMG.ammoAmount >= 25)
        {
            SMG_Ammo25.SetActive(true);
        }
        else
        {
            SMG_Ammo25.SetActive(false);
        }



        if (SMG.ammoAmount >= 26)
        {
            SMG_Ammo26.SetActive(true);
        }
        else
        {
            SMG_Ammo26.SetActive(false);
        }



        if (SMG.ammoAmount >= 27)
        {
            SMG_Ammo27.SetActive(true);
        }
        else
        {
            SMG_Ammo27.SetActive(false);
        }



        if (SMG.ammoAmount >= 28)
        {
            SMG_Ammo28.SetActive(true);
        }
        else
        {
            SMG_Ammo28.SetActive(false);
        }



        if (SMG.ammoAmount >= 29)
        {
            SMG_Ammo29.SetActive(true);
        }
        else
        {
            SMG_Ammo29.SetActive(false);
        }



        if (SMG.ammoAmount >= 30)
        {
            SMG_Ammo30.SetActive(true);
        }
        else
        {
            SMG_Ammo30.SetActive(false);
        }



        if (SMG.ammoAmount >= 31)
        {
            SMG_Ammo31.SetActive(true);
        }
        else
        {
            SMG_Ammo31.SetActive(false);
        }



        if (SMG.ammoAmount >= 32)
        {
            SMG_Ammo32.SetActive(true);
        }
        else
        {
            SMG_Ammo32.SetActive(false);
        }








        //Lewis
        if (Lewis.ammoAmount >= 1)
        {
            Lewis_Ammo01.SetActive(true);
        }
        else
        {
            Lewis_Ammo01.SetActive(false);
        }



        if (Lewis.ammoAmount >= 2)
        {
            Lewis_Ammo02.SetActive(true);
        }
        else
        {
            Lewis_Ammo02.SetActive(false);
        }



        if (Lewis.ammoAmount >= 3)
        {
            Lewis_Ammo03.SetActive(true);
        }
        else
        {
            Lewis_Ammo03.SetActive(false);
        }



        if (Lewis.ammoAmount >= 4)
        {
            Lewis_Ammo04.SetActive(true);
        }
        else
        {
            Lewis_Ammo04.SetActive(false);
        }



        if (Lewis.ammoAmount >= 5)
        {
            Lewis_Ammo05.SetActive(true);
        }
        else
        {
            Lewis_Ammo05.SetActive(false);
        }



        if (Lewis.ammoAmount >= 6)
        {
            Lewis_Ammo06.SetActive(true);
        }
        else
        {
            Lewis_Ammo06.SetActive(false);
        }



        if (Lewis.ammoAmount >= 7)
        {
            Lewis_Ammo07.SetActive(true);
        }
        else
        {
            Lewis_Ammo07.SetActive(false);
        }



        if (Lewis.ammoAmount >= 8)
        {
            Lewis_Ammo08.SetActive(true);
        }
        else
        {
            Lewis_Ammo08.SetActive(false);
        }



        if (Lewis.ammoAmount >= 9)
        {
            Lewis_Ammo09.SetActive(true);
        }
        else
        {
            Lewis_Ammo09.SetActive(false);
        }



        if (Lewis.ammoAmount >= 10)
        {
            Lewis_Ammo10.SetActive(true);
        }
        else
        {
            Lewis_Ammo10.SetActive(false);
        }



        if (Lewis.ammoAmount >= 11)
        {
            Lewis_Ammo11.SetActive(true);
        }
        else
        {
            Lewis_Ammo11.SetActive(false);
        }



        if (Lewis.ammoAmount >= 12)
        {
            Lewis_Ammo12.SetActive(true);
        }
        else
        {
            Lewis_Ammo12.SetActive(false);
        }



        if (Lewis.ammoAmount >= 13)
        {
            Lewis_Ammo13.SetActive(true);
        }
        else
        {
            Lewis_Ammo13.SetActive(false);
        }



        if (Lewis.ammoAmount >= 14)
        {
            Lewis_Ammo14.SetActive(true);
        }
        else
        {
            Lewis_Ammo14.SetActive(false);
        }



        if (Lewis.ammoAmount >= 15)
        {
            Lewis_Ammo15.SetActive(true);
        }
        else
        {
            Lewis_Ammo15.SetActive(false);
        }



        if (Lewis.ammoAmount >= 16)
        {
            Lewis_Ammo16.SetActive(true);
        }
        else
        {
            Lewis_Ammo16.SetActive(false);
        }



        if (Lewis.ammoAmount >= 17)
        {
            Lewis_Ammo17.SetActive(true);
        }
        else
        {
            Lewis_Ammo17.SetActive(false);
        }



        if (Lewis.ammoAmount >= 18)
        {
            Lewis_Ammo18.SetActive(true);
        }
        else
        {
            Lewis_Ammo18.SetActive(false);
        }



        if (Lewis.ammoAmount >= 19)
        {
            Lewis_Ammo19.SetActive(true);
        }
        else
        {
            Lewis_Ammo19.SetActive(false);
        }



        if (Lewis.ammoAmount >= 20)
        {
            Lewis_Ammo20.SetActive(true);
        }
        else
        {
            Lewis_Ammo20.SetActive(false);
        }



        if (Lewis.ammoAmount >= 21)
        {
            Lewis_Ammo21.SetActive(true);
        }
        else
        {
            Lewis_Ammo21.SetActive(false);
        }



        if (Lewis.ammoAmount >= 22)
        {
            Lewis_Ammo22.SetActive(true);
        }
        else
        {
            Lewis_Ammo22.SetActive(false);
        }



        if (Lewis.ammoAmount >= 23)
        {
            Lewis_Ammo23.SetActive(true);
        }
        else
        {
            Lewis_Ammo23.SetActive(false);
        }



        if (Lewis.ammoAmount >= 24)
        {
            Lewis_Ammo24.SetActive(true);
        }
        else
        {
            Lewis_Ammo24.SetActive(false);
        }



        if (Lewis.ammoAmount >= 25)
        {
            Lewis_Ammo25.SetActive(true);
        }
        else
        {
            Lewis_Ammo25.SetActive(false);
        }



        if (Lewis.ammoAmount >= 26)
        {
            Lewis_Ammo26.SetActive(true);
        }
        else
        {
            Lewis_Ammo26.SetActive(false);
        }



        if (Lewis.ammoAmount >= 27)
        {
            Lewis_Ammo27.SetActive(true);
        }
        else
        {
            Lewis_Ammo27.SetActive(false);
        }



        if (Lewis.ammoAmount >= 28)
        {
            Lewis_Ammo28.SetActive(true);
        }
        else
        {
            Lewis_Ammo28.SetActive(false);
        }



        if (Lewis.ammoAmount >= 29)
        {
            Lewis_Ammo29.SetActive(true);
        }
        else
        {
            Lewis_Ammo29.SetActive(false);
        }



        if (Lewis.ammoAmount >= 30)
        {
            Lewis_Ammo30.SetActive(true);
        }
        else
        {
            Lewis_Ammo30.SetActive(false);
        }



        if (Lewis.ammoAmount >= 31)
        {
            Lewis_Ammo31.SetActive(true);
        }
        else
        {
            Lewis_Ammo31.SetActive(false);
        }



        if (Lewis.ammoAmount >= 32)
        {
            Lewis_Ammo32.SetActive(true);
        }
        else
        {
            Lewis_Ammo32.SetActive(false);
        }



        if (Lewis.ammoAmount >= 33)
        {
            Lewis_Ammo33.SetActive(true);
        }
        else
        {
            Lewis_Ammo33.SetActive(false);
        }



        if (Lewis.ammoAmount >= 34)
        {
            Lewis_Ammo34.SetActive(true);
        }
        else
        {
            Lewis_Ammo34.SetActive(false);
        }



        if (Lewis.ammoAmount >= 35)
        {
            Lewis_Ammo35.SetActive(true);
        }
        else
        {
            Lewis_Ammo35.SetActive(false);
        }



        if (Lewis.ammoAmount >= 36)
        {
            Lewis_Ammo36.SetActive(true);
        }
        else
        {
            Lewis_Ammo36.SetActive(false);
        }



        if (Lewis.ammoAmount >= 37)
        {
            Lewis_Ammo37.SetActive(true);
        }
        else
        {
            Lewis_Ammo37.SetActive(false);
        }



        if (Lewis.ammoAmount >= 38)
        {
            Lewis_Ammo38.SetActive(true);
        }
        else
        {
            Lewis_Ammo38.SetActive(false);
        }



        if (Lewis.ammoAmount >= 39)
        {
            Lewis_Ammo39.SetActive(true);
        }
        else
        {
            Lewis_Ammo39.SetActive(false);
        }



        if (Lewis.ammoAmount >= 40)
        {
            Lewis_Ammo40.SetActive(true);
        }
        else
        {
            Lewis_Ammo40.SetActive(false);
        }



        if (Lewis.ammoAmount >= 41)
        {
            Lewis_Ammo41.SetActive(true);
        }
        else
        {
            Lewis_Ammo41.SetActive(false);
        }



        if (Lewis.ammoAmount >= 42)
        {
            Lewis_Ammo42.SetActive(true);
        }
        else
        {
            Lewis_Ammo42.SetActive(false);
        }



        if (Lewis.ammoAmount >= 43)
        {
            Lewis_Ammo43.SetActive(true);
        }
        else
        {
            Lewis_Ammo43.SetActive(false);
        }



        if (Lewis.ammoAmount >= 44)
        {
            Lewis_Ammo44.SetActive(true);
        }
        else
        {
            Lewis_Ammo44.SetActive(false);
        }



        if (Lewis.ammoAmount >= 45)
        {
            Lewis_Ammo45.SetActive(true);
        }
        else
        {
            Lewis_Ammo45.SetActive(false);
        }



        if (Lewis.ammoAmount >= 46)
        {
            Lewis_Ammo46.SetActive(true);
        }
        else
        {
            Lewis_Ammo46.SetActive(false);
        }



        if (Lewis.ammoAmount >= 47)
        {
            Lewis_Ammo47.SetActive(true);
        }
        else
        {
            Lewis_Ammo47.SetActive(false);
        }








        //Grenade Launcher
        if (grenade.ammoAmount >= 1)
        {
            grenade_Ammo01.SetActive(true);
        }
        else
        {
            grenade_Ammo01.SetActive(false);
        }



        if (grenade.ammoAmount >= 2)
        {
            grenade_Ammo02.SetActive(true);
        }
        else
        {
            grenade_Ammo02.SetActive(false);
        }



        if (grenade.ammoAmount >= 3)
        {
            grenade_Ammo03.SetActive(true);
        }
        else
        {
            grenade_Ammo03.SetActive(false);

        }








        //Rocket Gun
        if (rocket.ammoAmount >= 1)
        {
            rocket_Ammo01.SetActive(true);
        }
        else
        {
            rocket_Ammo01.SetActive(false);
        }








        //Flamethrower
        if (flamethrower.ammoAmount >= 1)
        {
            flame_Ammo01.SetActive(true);
        }
        else
        {
            flame_Ammo01.SetActive(false);
        }

    }
}
