using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : MonoBehaviour
{
    //[11/12/21] [Friday, 2:14 PM]

    //This simple script is placed on the Artillery gameObjects that are spawned from my "ArtilleryManager".
    //Whenever an Artillery gameObject is spawned, it will display a little effect on the ground known as
    //the Anticipation, this will occure for a set amount of time designated at the waitTime in this script.
    //Whenever the waitTime is up, the Artillery will spawn an explosion and the gameObject is destroyed.
    //It's a nice and simple way of doing things and it works beautifully!


    public float waitTime;
    public GameObject explosionPrefab;

    void Start()
    {
        StartCoroutine("ExplodeCoroutine");
    }

    IEnumerator ExplodeCoroutine()
    {
        //Do Something
        yield return new WaitForSeconds(waitTime);

        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //transform.localPosition = new Vector3(0, 0, 0);

        Destroy(gameObject);
    }

}
