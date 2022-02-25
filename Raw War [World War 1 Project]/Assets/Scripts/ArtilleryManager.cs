using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryManager : MonoBehaviour
{
    //[11/12/21] [Friday, 2:52 PM]

    //This is the Manager that controls when the Artillery are spawned in the game. Placed in a Manager 
    //GameObject, this script controls nearly ever aspect of Artillery spawning: from which artillery will
    //spawn in the level, where they will spawn, and how frequently they will spawn. First, the script uses
    //booleans to see which of the three artillery will be spawned: Grenade, Mortar or Artillery. Because
    //of the way the script is set up, this manager can be heavily customized to greatly adjust every
    //aspect of this new enemy. 

    //The Artillery Prefabs are what are spawned at these locations. 
    //Intervals are float arrays that determine the timing between artillery spawning.
    //Array Spawners keep track of where these Artillery prefabs will be spawned.
    //Statistics simply display which Interval element is currently selected, this is updated per frame.

    //Essentially, how my random intervals and spawning works is that the game cycles through a list of
    //float arrays in the update function. The cycled values can be visually seen under the Statistics
    //header of the Manager. Whenever the interval value hits ZERO, then the Artillery is spawned at a
    //one of the listed spawning locations, with the exact one being randomly selected.


    [Header("General")]
    public Transform[] spawnPoint;
    public Transform random;
    public int index;

    [Header("Grenade")]
    public bool grenade;
    public GameObject grenadePrefab;
    public float Grenade_Value;
    public float GRE_Interval;

    [Header("Mortar")]
    public bool mortar;
    public GameObject mortarPrefab;
    public float Mortar_Value;
    public float MOR_Interval;

    [Header("Artillery")]
    public bool artillery;
    public GameObject artilleryPrefab;
    public float Artillery_Value;
    public float ART_Interval;


    private void Start()
    {
        StartCoroutine("Checking");

        StartCoroutine("Spawners");
    }

    IEnumerator Checking()
    {
        yield return new WaitForSeconds(1);

        Check();

        StartCoroutine("Checking");
    }

    IEnumerator Spawners()
    {
        yield return new WaitForSeconds(1);

        index = Random.Range(0, spawnPoint.Length);
        random = spawnPoint[index];

        StartCoroutine("Spawners");
    }

    void Check()
    {
        if (grenade == true)
        {
            GRE_Interval = Random.Range(0, Grenade_Value);
            if(GRE_Interval <= 1)
            {
                SpawnGrenade();
            }
        }

        if (mortar == true)
        {
            MOR_Interval = Random.Range(0, Mortar_Value);
            if(MOR_Interval <= 1)
            {
                SpawnMortar();
            }
        }

        if (artillery == true)
        {
            ART_Interval = Random.Range(0, Artillery_Value);
            if(ART_Interval <= 1)
            {
                SpawnArtillery();
            }
        }
    }

    void SpawnGrenade()
    {
        Instantiate(grenadePrefab, random);
        Debug.Log("Spawn Grenade");
    }

    void SpawnMortar()
    {
        Instantiate(mortarPrefab, random);
        Debug.Log("Spawn Mortar");
    }

    void SpawnArtillery()
    {
        Instantiate(artilleryPrefab, random);
        Debug.Log("Spawn Artillery");
    }
}
