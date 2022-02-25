using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCam : MonoBehaviour
{
    //[11/12/21] [Friday, 3:12 PM]

    //Whenever the player is killed, the Character gameobject will be destroyed and the DeathEvent object
    //will be set active. A Death Camera will spawn that will mimic the player's head falling to the ground.
    //This script will be located on the DeathEvent gameObject under the folder "=====[  PLAYERS  ]=====".
    //The Death Camera's rotation and position will match that of the MainCamera until the player's death,
    //this is so that the transition between living and dead will be smooth and seamless.


    public Transform player;
    public Transform mainCamera;
    public Vector3 offset;

    public GameObject heart_Full;                       
    public GameObject heart_Empty;

    public GameObject Shield1_Full;
    public GameObject Shield1_Empty;

    public GameObject Shield2_Full;
    public GameObject Shield2_Empty;

    public GameObject Shield3_Full;
    public GameObject Shield3_Empty;

    void Update()
    {
        transform.position = player.position + offset;
        transform.rotation = mainCamera.rotation;

        if (player == null)
        {
            Debug.Log("Player is Dead");
            heart_Full.SetActive(false);
            heart_Empty.SetActive(true);

            Shield1_Full.SetActive(false);
            Shield1_Empty.SetActive(true);

            Shield2_Full.SetActive(false);
            Shield2_Empty.SetActive(true);

            Shield3_Full.SetActive(false);
            Shield3_Empty.SetActive(true);
        }
        
    }
}
