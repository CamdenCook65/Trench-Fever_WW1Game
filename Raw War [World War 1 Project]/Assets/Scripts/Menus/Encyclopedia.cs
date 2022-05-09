using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encyclopedia : MonoBehaviour
{
    public GameObject BasicMenu;
    public GameObject WW1Menu;
    public GameObject WeaponsMenu;
    public GameObject EnemyMenu;

    public GameObject WWM_WW1;
    public GameObject WWM_WesternFront;
    public GameObject WWM_France;
    public GameObject WWM_Britian;
    public GameObject WWM_Russia;
    public GameObject WWM_USA;
    public GameObject WWM_Germany;
    public GameObject WWM_AustriaHungary;
    public GameObject WWM_Ottoman;

    public GameObject W_TrenchClub;
    public GameObject W_Pistol;
    public GameObject W_Shotgun;
    public GameObject W_SMG;
    public GameObject W_LMG;
    public GameObject W_Launcher;
    public GameObject W_RocketGun;
    public GameObject W_Flamethrower;

    public GameObject E_Infantryman;
    public GameObject E_Officer;
    public GameObject E_Stormtrooper;
    public GameObject E_Grenadier;
    public GameObject E_Rocketeer;
    public GameObject E_Flametrooper;
    public GameObject E_TrenchRat;

    public void backToMain()
    {
        BasicMenu.gameObject.SetActive(true);
        WW1Menu.gameObject.SetActive(false);
        WeaponsMenu.gameObject.SetActive(false);
        EnemyMenu.gameObject.SetActive(false);

        WWM_WW1.gameObject.SetActive(false);
        WWM_WesternFront.gameObject.SetActive(false);
        WWM_France.gameObject.SetActive(false);
        WWM_Britian.gameObject.SetActive(false);
        WWM_Russia.gameObject.SetActive(false);
        WWM_USA.gameObject.SetActive(false);
        WWM_Germany.gameObject.SetActive(false);
        WWM_AustriaHungary.gameObject.SetActive(false);
        WWM_Ottoman.gameObject.SetActive(false);

        W_TrenchClub.gameObject.SetActive(false);
        W_Pistol.gameObject.SetActive(false);
        W_Shotgun.gameObject.SetActive(false);
        W_SMG.gameObject.SetActive(false);
        W_LMG.gameObject.SetActive(false);
        W_Launcher.gameObject.SetActive(false);
        W_RocketGun.gameObject.SetActive(false);
        W_Flamethrower.gameObject.SetActive(false);

        E_Infantryman.gameObject.SetActive(false);
        E_Officer.gameObject.SetActive(false);
        E_Stormtrooper.gameObject.SetActive(false);
        E_Grenadier.gameObject.SetActive(false);
        E_Rocketeer.gameObject.SetActive(false);
        E_Flametrooper.gameObject.SetActive(false);
        E_TrenchRat.gameObject.SetActive(false);
    }

    public void WW1()
    {
        BasicMenu.gameObject.SetActive(false);
        WW1Menu.gameObject.SetActive(true);
        WeaponsMenu.gameObject.SetActive(false);
        EnemyMenu.gameObject.SetActive(false);
    }

    public void WorldWar()
    {
        WWM_WW1.gameObject.SetActive(true);
        WWM_WesternFront.gameObject.SetActive(false);
        WWM_France.gameObject.SetActive(false);
        WWM_Britian.gameObject.SetActive(false);
        WWM_Russia.gameObject.SetActive(false);
        WWM_USA.gameObject.SetActive(false);
        WWM_Germany.gameObject.SetActive(false);
        WWM_AustriaHungary.gameObject.SetActive(false);
        WWM_Ottoman.gameObject.SetActive(false);
    }

    public void WesternFront()
    {
        WWM_WW1.gameObject.SetActive(false);
        WWM_WesternFront.gameObject.SetActive(true);
        WWM_France.gameObject.SetActive(false);
        WWM_Britian.gameObject.SetActive(false);
        WWM_Russia.gameObject.SetActive(false);
        WWM_USA.gameObject.SetActive(false);
        WWM_Germany.gameObject.SetActive(false);
        WWM_AustriaHungary.gameObject.SetActive(false);
        WWM_Ottoman.gameObject.SetActive(false);
    }

    public void France()
    {
        WWM_WW1.gameObject.SetActive(false);
        WWM_WesternFront.gameObject.SetActive(false);
        WWM_France.gameObject.SetActive(true);
        WWM_Britian.gameObject.SetActive(false);
        WWM_Russia.gameObject.SetActive(false);
        WWM_USA.gameObject.SetActive(false);
        WWM_Germany.gameObject.SetActive(false);
        WWM_AustriaHungary.gameObject.SetActive(false);
        WWM_Ottoman.gameObject.SetActive(false);
    }

    public void Britain()
    {
        WWM_WW1.gameObject.SetActive(false);
        WWM_WesternFront.gameObject.SetActive(false);
        WWM_France.gameObject.SetActive(false);
        WWM_Britian.gameObject.SetActive(true);
        WWM_Russia.gameObject.SetActive(false);
        WWM_USA.gameObject.SetActive(false);
        WWM_Germany.gameObject.SetActive(false);
        WWM_AustriaHungary.gameObject.SetActive(false);
        WWM_Ottoman.gameObject.SetActive(false);
    }

    public void Russia()
    {
        WWM_WW1.gameObject.SetActive(false);
        WWM_WesternFront.gameObject.SetActive(false);
        WWM_France.gameObject.SetActive(false);
        WWM_Britian.gameObject.SetActive(false);
        WWM_Russia.gameObject.SetActive(true);
        WWM_USA.gameObject.SetActive(false);
        WWM_Germany.gameObject.SetActive(false);
        WWM_AustriaHungary.gameObject.SetActive(false);
        WWM_Ottoman.gameObject.SetActive(false);
    }

    public void USA()
    {
        WWM_WW1.gameObject.SetActive(false);
        WWM_WesternFront.gameObject.SetActive(false);
        WWM_France.gameObject.SetActive(false);
        WWM_Britian.gameObject.SetActive(false);
        WWM_Russia.gameObject.SetActive(false);
        WWM_USA.gameObject.SetActive(true);
        WWM_Germany.gameObject.SetActive(false);
        WWM_AustriaHungary.gameObject.SetActive(false);
        WWM_Ottoman.gameObject.SetActive(false);
    }

    public void Germany()
    {
        WWM_WW1.gameObject.SetActive(false);
        WWM_WesternFront.gameObject.SetActive(false);
        WWM_France.gameObject.SetActive(false);
        WWM_Britian.gameObject.SetActive(false);
        WWM_Russia.gameObject.SetActive(false);
        WWM_USA.gameObject.SetActive(false);
        WWM_Germany.gameObject.SetActive(true);
        WWM_AustriaHungary.gameObject.SetActive(false);
        WWM_Ottoman.gameObject.SetActive(false);
    }

    public void AustriaHungary()
    {
        WWM_WW1.gameObject.SetActive(false);
        WWM_WesternFront.gameObject.SetActive(false);
        WWM_France.gameObject.SetActive(false);
        WWM_Britian.gameObject.SetActive(false);
        WWM_Russia.gameObject.SetActive(false);
        WWM_USA.gameObject.SetActive(false);
        WWM_Germany.gameObject.SetActive(false);
        WWM_AustriaHungary.gameObject.SetActive(true);
        WWM_Ottoman.gameObject.SetActive(false);
    }

    public void Ottoman()
    {
        WWM_WW1.gameObject.SetActive(false);
        WWM_WesternFront.gameObject.SetActive(false);
        WWM_France.gameObject.SetActive(false);
        WWM_Britian.gameObject.SetActive(false);
        WWM_Russia.gameObject.SetActive(false);
        WWM_USA.gameObject.SetActive(false);
        WWM_Germany.gameObject.SetActive(false);
        WWM_AustriaHungary.gameObject.SetActive(false);
        WWM_Ottoman.gameObject.SetActive(true);
    }



    public void Weapons()
    {
        BasicMenu.gameObject.SetActive(false);
        WW1Menu.gameObject.SetActive(false);
        WeaponsMenu.gameObject.SetActive(true);
        EnemyMenu.gameObject.SetActive(false);
    }

    public void TrenchClub()
    {
        W_TrenchClub.gameObject.SetActive(true);
        W_Pistol.gameObject.SetActive(false);
        W_Shotgun.gameObject.SetActive(false);
        W_SMG.gameObject.SetActive(false);
        W_LMG.gameObject.SetActive(false);
        W_Launcher.gameObject.SetActive(false);
        W_RocketGun.gameObject.SetActive(false);
        W_Flamethrower.gameObject.SetActive(false);
    }

    public void Pistol()
    {
        W_TrenchClub.gameObject.SetActive(false);
        W_Pistol.gameObject.SetActive(true);
        W_Shotgun.gameObject.SetActive(false);
        W_SMG.gameObject.SetActive(false);
        W_LMG.gameObject.SetActive(false);
        W_Launcher.gameObject.SetActive(false);
        W_RocketGun.gameObject.SetActive(false);
        W_Flamethrower.gameObject.SetActive(false);
    }

    public void Shotgun()
    {
        W_TrenchClub.gameObject.SetActive(false);
        W_Pistol.gameObject.SetActive(false);
        W_Shotgun.gameObject.SetActive(true);
        W_SMG.gameObject.SetActive(false);
        W_LMG.gameObject.SetActive(false);
        W_Launcher.gameObject.SetActive(false);
        W_RocketGun.gameObject.SetActive(false);
        W_Flamethrower.gameObject.SetActive(false);
    }

    public void SMG()
    {
        W_TrenchClub.gameObject.SetActive(false);
        W_Pistol.gameObject.SetActive(false);
        W_Shotgun.gameObject.SetActive(false);
        W_SMG.gameObject.SetActive(true);
        W_LMG.gameObject.SetActive(false);
        W_Launcher.gameObject.SetActive(false);
        W_RocketGun.gameObject.SetActive(false);
        W_Flamethrower.gameObject.SetActive(false);
    }

    public void LMG()
    {
        W_TrenchClub.gameObject.SetActive(false);
        W_Pistol.gameObject.SetActive(false);
        W_Shotgun.gameObject.SetActive(false);
        W_SMG.gameObject.SetActive(false);
        W_LMG.gameObject.SetActive(true);
        W_Launcher.gameObject.SetActive(false);
        W_RocketGun.gameObject.SetActive(false);
        W_Flamethrower.gameObject.SetActive(false);
    }

    public void Launcher()
    {
        W_TrenchClub.gameObject.SetActive(false);
        W_Pistol.gameObject.SetActive(false);
        W_Shotgun.gameObject.SetActive(false);
        W_SMG.gameObject.SetActive(false);
        W_LMG.gameObject.SetActive(false);
        W_Launcher.gameObject.SetActive(true);
        W_RocketGun.gameObject.SetActive(false);
        W_Flamethrower.gameObject.SetActive(false);
    }

    public void RocketGun()
    {
        W_TrenchClub.gameObject.SetActive(false);
        W_Pistol.gameObject.SetActive(false);
        W_Shotgun.gameObject.SetActive(false);
        W_SMG.gameObject.SetActive(false);
        W_LMG.gameObject.SetActive(false);
        W_Launcher.gameObject.SetActive(false);
        W_RocketGun.gameObject.SetActive(true);
        W_Flamethrower.gameObject.SetActive(false);
    }

    public void Flamethrower()
    {
        W_TrenchClub.gameObject.SetActive(false);
        W_Pistol.gameObject.SetActive(false);
        W_Shotgun.gameObject.SetActive(false);
        W_SMG.gameObject.SetActive(false);
        W_LMG.gameObject.SetActive(false);
        W_Launcher.gameObject.SetActive(false);
        W_RocketGun.gameObject.SetActive(false);
        W_Flamethrower.gameObject.SetActive(true);
    }



    public void Enemies()
    {
        BasicMenu.gameObject.SetActive(false);
        WW1Menu.gameObject.SetActive(false);
        WeaponsMenu.gameObject.SetActive(false);
        EnemyMenu.gameObject.SetActive(true);
    }

    public void Infantryman()
    {
        E_Infantryman.gameObject.SetActive(true);
        E_Officer.gameObject.SetActive(false);
        E_Stormtrooper.gameObject.SetActive(false);
        E_Grenadier.gameObject.SetActive(false);
        E_Rocketeer.gameObject.SetActive(false);
        E_Flametrooper.gameObject.SetActive(false);
        E_TrenchRat.gameObject.SetActive(false);
    }

    public void Officer()
    {
        E_Infantryman.gameObject.SetActive(false);
        E_Officer.gameObject.SetActive(true);
        E_Stormtrooper.gameObject.SetActive(false);
        E_Grenadier.gameObject.SetActive(false);
        E_Rocketeer.gameObject.SetActive(false);
        E_Flametrooper.gameObject.SetActive(false);
        E_TrenchRat.gameObject.SetActive(false);
    }

    public void Stormtrooper()
    {
        E_Infantryman.gameObject.SetActive(false);
        E_Officer.gameObject.SetActive(false);
        E_Stormtrooper.gameObject.SetActive(true);
        E_Grenadier.gameObject.SetActive(false);
        E_Rocketeer.gameObject.SetActive(false);
        E_Flametrooper.gameObject.SetActive(false);
        E_TrenchRat.gameObject.SetActive(false);
    }

    public void Grenadier()
    {
        E_Infantryman.gameObject.SetActive(false);
        E_Officer.gameObject.SetActive(false);
        E_Stormtrooper.gameObject.SetActive(false);
        E_Grenadier.gameObject.SetActive(true);
        E_Rocketeer.gameObject.SetActive(false);
        E_Flametrooper.gameObject.SetActive(false);
        E_TrenchRat.gameObject.SetActive(false);
    }

    public void Rocketeer()
    {
        E_Infantryman.gameObject.SetActive(false);
        E_Officer.gameObject.SetActive(false);
        E_Stormtrooper.gameObject.SetActive(false);
        E_Grenadier.gameObject.SetActive(false);
        E_Rocketeer.gameObject.SetActive(true);
        E_Flametrooper.gameObject.SetActive(false);
        E_TrenchRat.gameObject.SetActive(false);
    }

    public void Flametrooper()
    {
        E_Infantryman.gameObject.SetActive(false);
        E_Officer.gameObject.SetActive(false);
        E_Stormtrooper.gameObject.SetActive(false);
        E_Grenadier.gameObject.SetActive(false);
        E_Rocketeer.gameObject.SetActive(false);
        E_Flametrooper.gameObject.SetActive(true);
        E_TrenchRat.gameObject.SetActive(false);
    }

    public void TrenchRat()
    {
        E_Infantryman.gameObject.SetActive(false);
        E_Officer.gameObject.SetActive(false);
        E_Stormtrooper.gameObject.SetActive(false);
        E_Grenadier.gameObject.SetActive(false);
        E_Rocketeer.gameObject.SetActive(false);
        E_Flametrooper.gameObject.SetActive(false);
        E_TrenchRat.gameObject.SetActive(true);
    }
}
