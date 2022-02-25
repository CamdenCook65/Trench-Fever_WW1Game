using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    //[11/12/21] [Friday, 3:09 PM]

    //This is the script attached to the Bombs gameObjects spawned by the BombManager. When a Bombs is 
    //spawned, it will travel downwards toward's the ground using Rigidbody gravity. As determined by this
    //script, whenever the bomb hit's the a gameobject with the tag "Ground", it will spawn as explosion
    //and destroy itself. The Bomb is not very different from the Artillery in that regard.


    public GameObject explosionPrefab;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
