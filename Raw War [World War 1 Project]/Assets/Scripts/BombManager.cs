using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    //[11/12/21] [Friday, 3:06 PM]

    //The Bomb Manager is essentially idential to the Artillery Manager except that all of the Bombs will
    //spawns at one selected spot located 50 Meters above the player's position at all times. Go check out
    //the ArtilleryManager to gain a better understanding of how the system works since this is literally
    //identical to that system.


    [Header("General")]
    public Transform spawner;

    [Header("Standard Bomb")]
    public bool bomb;
    public GameObject bombPrefab;
    public float Bomb_Value;
    public float BMB_Interval;

    [Header("Flechette")]
    public bool flechette;
    public GameObject flechettePrefab;
    public float Flechette_Value;
    public float FLE_Interval;


    [Header("High Explosive Bomb")]
    public bool hEBomb;
    public GameObject hEBombPrefab;
    public float HE_Value;
    public float HEB_Interval;



    private void Start()
    {
        StartCoroutine("Coroutine");
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1);

        Check();

        StartCoroutine("Coroutine");
    }

    void Check()
    {
        if (bomb == true)
        {
            BMB_Interval = Random.Range(0, Bomb_Value);
            if(BMB_Interval <= 1)
            {
                SpawnBomb();
            }
        }

        if (flechette == true)
        {
            FLE_Interval = Random.Range(0, Flechette_Value);
            if(FLE_Interval <= 1)
            {
                SpawnFlechette();
            }
        }

        if (hEBomb == true)
        {
            HEB_Interval = Random.Range(0, HE_Value);
            if(HEB_Interval <= 1)
            {
                SpawnHighExplosive();
            }
        }
    }

    void SpawnBomb()
    {
        Instantiate(bombPrefab, spawner.position, spawner.rotation);
        Debug.Log("Spawning Bomb!");
    }

    void SpawnFlechette()
    {
        Instantiate(flechettePrefab, spawner.position, spawner.rotation);
        Debug.Log("Spawning Flechettes!");
    }

    void SpawnHighExplosive()
    {
        Instantiate(hEBombPrefab, spawner.position, spawner.rotation);
        Debug.Log("Spawning High Explosive!");
    }
}
