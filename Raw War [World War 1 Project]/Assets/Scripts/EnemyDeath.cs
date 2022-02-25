using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    //[2/7/22] [Monday, 9:44 PM]

    //A Simple script really, attached to any of the various Death Prefabs for all of the Enemies. This code 
    //references the Enemy spawner prefab as possesses two booleans to determine if the death prefab belongs to
    //a Soldier or a Trench Rat. Upon Start, the script will preform it's sole action, which is to deduct one
    //point from either the SoldierAmount or TrenchRatAmount depending on which enemy the death prefab belongs to.
    //This is a short yet very effective script.


    public EntitySpawn spawner;
    public bool Soldier;
    public bool TrenchRat;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EntitySpawn>();

        if (Soldier == true)
        {
            spawner.RemoveEnemySoldier();
        }

        if (TrenchRat == true)
        {
            spawner.RemoveEnemyTrenchRat();
        }
    }
}
