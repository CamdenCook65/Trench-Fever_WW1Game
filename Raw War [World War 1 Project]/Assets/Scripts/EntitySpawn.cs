using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawn : MonoBehaviour
{
    //[2/1/22] [Tuesday, 11:50 PM]

    //The EntitySpawn script will be nested in a designated "Spawner" object and will be the single most
    //important script for enemy encounters in levels. There is various data regarding all 20 different
    //possible enemy types as well as some general stats for the spawner and total enemy data. This 
    //spawning system is a more realized version of the Artillery and Bomb Manager, one that I believe
    //is more efficient and performanc friendly, very important considering how this will be most more
    //heavily relied upon compared to either of the former. For general stats, the game will measure the
    //capacity and in-game population of both Soldier and Trench Rats. There will also be a list of 
    //possible spawning locations (represented by Transforms) as well as a principle transform that 
    //represents which of the spawning locations is currently being used. All 6 Soldiers and 14 Rats
    //have various variables necessary for successfully spawning them into the level. This include
    //a boolean that dictates whether the enemy is even active in this part of the game, a float that
    //determines at what interval they spawn, another float that shows the current value in the 
    //interval process, and (of course) the Enemy prefab itself. 
    
    //The whole spawning procedure goes something like this: Every second, the game runs a check to 
    //determine which enemies are capable of spawning into the level. The script will check the enemies
    //current interval variable value, which is changed to a random number between 0 and the designated
    //interval number. If the variable equals one or less (and the boolean check is true), then the enemy
    //will successfully spawn. The Spawn Location system is very similar in design. Every second, the game
    //will pick a random Transform from the list provided. A spawning enemy will appear at the location of
    //whatever Transform is selected at the time of their Instantiation. This script sounds really 
    //complicated, but it's really an elegant system and I'm overjoyed it's working as well as it is!

    [SerializeField]

    [Header("General")]
    public int SoldierCapacity;
    public int TrenchRatCapacity;
    public int SoldierAmount;
    public int TrenchRatAmount;
    public Transform[] spawns;
    public Transform random;
    public int index;
    public Visibility visSpawner;



    [Header("Infantryman")]
    public bool IFN_Active;
    public GameObject IFN_Enemy;
    public float IFN_Interval;
    public float IFN_Value;

    [Header("Officer")]
    public bool OFF_Active;
    public GameObject OFF_Enemy;
    public float OFF_Interval;
    public float OFF_Value;

    [Header("Stormtrooper")]
    public bool STR_Active;
    public GameObject STR_Enemy;
    public float STR_Interval;
    public float STR_Value;

    [Header("Grenadier")]
    public bool GRE_Active;
    public GameObject GRE_Enemy;
    public float GRE_Interval;
    public float GRE_Value;

    [Header("Rocketeer")]
    public bool RCK_Active;
    public GameObject RCK_Enemy;
    public float RCK_Interval;
    public float RCK_Value;

    [Header("Flametrooper")]
    public bool FLM_Active;
    public GameObject FLM_Enemy;
    public float FLM_Interval;
    public float FLM_Value;




    [Header("Brown Rat")]
    public bool BR_TR_Active;
    public GameObject BR_TR_Enemy;
    public float BR_TR_Interval;
    public float BR_TR_Value;

    [Header("Cinnamon Rat")]
    public bool CN_TR_Active;
    public GameObject CN_TR_Enemy;
    public float CN_TR_Interval;
    public float CN_TR_Value;

    [Header("Chocolate Rat")]
    public bool CH_TR_Active;
    public GameObject CH_TR_Enemy;
    public float CH_TR_Interval;
    public float CH_TR_Value;

    [Header("Ash Rat")]
    public bool AH_TR_Active;
    public GameObject AH_TR_Enemy;
    public float AH_TR_Interval;
    public float AH_TR_Value;

    [Header("Grey Rat")]
    public bool GR_TR_Active;
    public GameObject GR_TR_Enemy;
    public float GR_TR_Interval;
    public float GR_TR_Value;

    [Header("Black Rat")]
    public bool BK_TR_Active;
    public GameObject BK_TR_Enemy;
    public float BK_TR_Interval;
    public float BK_TR_Value;

    [Header("White Rat")]
    public bool WH_TR_Active;
    public GameObject WH_TR_Enemy;
    public float WH_TR_Interval;
    public float WH_TR_Value;

    [Header("Rusty Rat")]
    public bool RS_TR_Active;
    public GameObject RS_TR_Enemy;
    public float RS_TR_Interval;
    public float RS_TR_Value;

    [Header("Blonde Rat")]
    public bool BL_TR_Active;
    public GameObject BL_TR_Enemy;
    public float BL_TR_Interval;
    public float BL_TR_Value;

    [Header("Sick Rat")]
    public bool SK_TR_Active;
    public GameObject SK_TRN_Enemy;
    public float SK_TR_Interval;
    public float SK_TR_Value;

    [Header("Naked Rat")]
    public bool NK_TR_Active;
    public GameObject NK_TR_Enemy;
    public float NK_TR_Interval;
    public float NK_TR_Value;

    [Header("Albino Rat")]
    public bool AL_TR_Active;
    public GameObject AL_TR_Enemy;
    public float AL_TR_Interval;
    public float AL_TR_Value;

    [Header("Melanistic Rat")]
    public bool ML_TR_Active;
    public GameObject ML_TR_Enemy;
    public float ML_TR_Interval;
    public float ML_TR_Value;

    [Header("Golden Rat")]
    public bool GL_TR_Active;
    public GameObject GL_TR_Enemy;
    public float GL_TR_Interval;
    public float GL_TR_Value;

    private void Start()
    {
        //visSpawner = random.GetComponent<Visibility>();

        StartCoroutine("Coroutine");

        SoldierAmount = 0;
        TrenchRatAmount = 0;
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1);

        Check();

        StartCoroutine("Coroutine");
    }

    void Check()
    {
        //Infantryman Check
        if((IFN_Active == true) && (SoldierAmount <= SoldierCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            IFN_Value = Random.Range(0, IFN_Interval);
            if (IFN_Value <= 1 && visSpawner.visible == true)
            {
                Infantryman();
                AddEnemySoldier();
            }
        }

        //Officer Check
        if((OFF_Active == true) && (SoldierAmount <= SoldierCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            OFF_Value = Random.Range(0, OFF_Interval);
            if (OFF_Value <= 1 && visSpawner.visible == true)
            {
                Officer();
                AddEnemySoldier();
            }
        }

        //Stormtrooper Check
        if((STR_Active == true) && (SoldierAmount <= SoldierCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            STR_Value = Random.Range(0, STR_Interval);
            if (STR_Value <= 1 && visSpawner.visible == true)
            {
                Stormtrooper();
                AddEnemySoldier();
            }
        }

        //Grenadier Check
        if((GRE_Active == true) && (SoldierAmount <= SoldierCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            GRE_Value = Random.Range(0, GRE_Interval);
            if (GRE_Value <= 1 && visSpawner.visible == true)
            {
                Grenadier();
                AddEnemySoldier();
            }
        }

        //Rocketeer Check
        if((RCK_Active == true) && (SoldierAmount <= SoldierCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            RCK_Value = Random.Range(0, RCK_Interval);
            if (RCK_Value <= 1 && visSpawner.visible == true)
            {
                Rocketeer();
                AddEnemySoldier();
            }
        }

        //Flametrooper Check
        if((FLM_Active == true) && (SoldierAmount <= SoldierCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            FLM_Value = Random.Range(0, FLM_Interval);
            if (FLM_Value <= 1 && visSpawner.visible == true)
            {
                Flametrooper();
                AddEnemySoldier();
            }
        }
        





        //Brown Rat Check
        if((BR_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            BR_TR_Value = Random.Range(0, BR_TR_Interval);
            if (BR_TR_Value <= 1 && visSpawner.visible == true)
            {
                BrownRat();
                AddEnemyTrenchRat();
            }
        }

        //Cinnamon Rat Check
        if((CN_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            CN_TR_Value = Random.Range(0, CN_TR_Interval);
            if (CN_TR_Value <= 1 && visSpawner.visible == true)
            {
                CinnamonRat();
                AddEnemyTrenchRat();
            }
        }

        //Chocolate Rat Check
        if((CH_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            CH_TR_Value = Random.Range(0, CH_TR_Interval);
            if (CH_TR_Value <= 1 && visSpawner.visible == true)
            {
                ChocolateRat();
                AddEnemyTrenchRat();
            }
        }

        //Ash Rat Check
        if((AH_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            AH_TR_Value = Random.Range(0, AH_TR_Interval);
            if (AH_TR_Value <= 1 && visSpawner.visible == true)
            {
                AshRat();
                AddEnemyTrenchRat();
            }
        }

        //Grey Rat Check
        if((GR_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            GR_TR_Value = Random.Range(0, GR_TR_Interval);
            if (GR_TR_Value <= 1 && visSpawner.visible == true)
            {
                GreyRat();
                AddEnemyTrenchRat();
            }
        }

        //Black Rat Check
        if((BK_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            BK_TR_Value = Random.Range(0, BK_TR_Interval);
            if (BK_TR_Value <= 1 && visSpawner.visible == true)
            {
                BlackRat();
                AddEnemyTrenchRat();
            }
        }

        //White Rat Check
        if((WH_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            WH_TR_Value = Random.Range(0, WH_TR_Interval);
            if (WH_TR_Value <= 1 && visSpawner.visible == true)
            {
                WhiteRat();
                AddEnemyTrenchRat();
            }
        }

        //Rusty Rat Check
        if((RS_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            RS_TR_Value = Random.Range(0, RS_TR_Interval);
            if (RS_TR_Value <= 1 && visSpawner.visible == true)
            {
                RustyRat();
                AddEnemyTrenchRat();
            }
        }

        //Blonde Rat Check
        if((BL_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            BL_TR_Value = Random.Range(0, BL_TR_Interval);
            if (BL_TR_Value <= 1 && visSpawner.visible == true)
            {
                BlondeRat();
                AddEnemyTrenchRat();
            }
        }

        //Sick Rat Check
        if((SK_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            SK_TR_Value = Random.Range(0, SK_TR_Interval);
            if (SK_TR_Value <= 1 && visSpawner.visible == true)
            {
                SickRat();
                AddEnemyTrenchRat();
            }
        }

        //Naked Rat Check
        if((NK_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            NK_TR_Value = Random.Range(0, NK_TR_Interval);
            if (NK_TR_Value <= 1 && visSpawner.visible == true)
            {
                NakedRat();
                AddEnemyTrenchRat();
            }
        }

        //Albino Rat Check
        if((AL_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            AL_TR_Value = Random.Range(0, AL_TR_Interval);
            if (AL_TR_Value <= 1 && visSpawner.visible == true)
            {
                AlbinoRat();
                AddEnemyTrenchRat();
            }
        }

        //Melanistic Rat Check
        if((ML_TR_Active == true) && (TrenchRatAmount <= TrenchRatCapacity))
        {
            visSpawner = random.GetComponent<Visibility>();

            ML_TR_Value = Random.Range(0, ML_TR_Interval);
            if (ML_TR_Value <= 1 && visSpawner.visible == true)
            {
                visSpawner = random.GetComponent<Visibility>();
                MelanisticRat();
                AddEnemyTrenchRat();
            }
        }

        //Golden Demise Check
        if(GL_TR_Active == true)
        {
            visSpawner = random.GetComponent<Visibility>();

            GL_TR_Value = Random.Range(0, GL_TR_Interval);
            if (GL_TR_Value <= 1 && visSpawner.visible == true)
            {
                visSpawner = random.GetComponent<Visibility>();
                GoldenDemise();
                //AddEnemyTrenchRat();
            }
        }
    }

    private void Update()
    {
        //visSpawner = random.GetComponent<Visibility>();

        index = Random.Range(0, spawns.Length);
        random = spawns[index];
    }

    public void AddEnemySoldier()
    {
        SoldierAmount += 1;
        Debug.Log("Soldier Added!");
    }

    public void AddEnemyTrenchRat()
    {
        TrenchRatAmount += 1;
        Debug.Log("Trench Rat Added!");
    }



    public void RemoveEnemySoldier()
    {
        SoldierAmount -= 1;
        Debug.Log("Solder Killed!");
    }

    public void RemoveEnemyTrenchRat()
    {
        TrenchRatAmount -= 1;
        Debug.Log("Trench Rat Killed!");
    }




    //Added a feature that checks if the random spawner is visible to the player. If so, the enemy will not
    //spawn in. It's a relatively simple feature but one that will help sustain player immersion.
    void Infantryman()
    {
        Instantiate(IFN_Enemy, random);
    }

    void Officer()
    {
        Instantiate(OFF_Enemy, random);
    }

    void Stormtrooper()
    {
        Instantiate(STR_Enemy, random);
    }

    void Grenadier()
    {
        Instantiate(GRE_Enemy, random);
    }

    void Rocketeer()
    {
        Instantiate(RCK_Enemy, random);
    }

    void Flametrooper()
    {
        Instantiate(FLM_Enemy, random);
    }

    void BrownRat()
    {
        Instantiate(BR_TR_Enemy, random);
    }

    void CinnamonRat()
    {
        Instantiate(CN_TR_Enemy, random);
    }

    void ChocolateRat()
    {
        Instantiate(CH_TR_Enemy, random);
    }

    void AshRat()
    {
        Instantiate(AH_TR_Enemy, random);
    }

    void GreyRat()
    {
        Instantiate(GR_TR_Enemy, random);
    }

    void BlackRat()
    {
        Instantiate(BK_TR_Enemy, random);
    }

    void WhiteRat()
    {
        Instantiate(WH_TR_Enemy, random);
    }

    void RustyRat()
    {
        Instantiate(RS_TR_Enemy, random);
    }

    void BlondeRat()
    {
        Instantiate(BL_TR_Enemy, random);
    }

    void SickRat()
    {
        Instantiate(SK_TRN_Enemy, random);
    }

    void NakedRat()
    {
        Instantiate(NK_TR_Enemy, random);
    }

    void AlbinoRat()
    {
        Instantiate(AL_TR_Enemy, random);
    }

    void MelanisticRat()
    {
        Instantiate(ML_TR_Enemy, random);
    }

    void GoldenDemise()
    {
        Instantiate(GL_TR_Enemy, random);
    }


} 

