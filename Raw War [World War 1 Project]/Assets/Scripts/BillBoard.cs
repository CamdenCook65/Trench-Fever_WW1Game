using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    //[11/12/21] [Friday, 3:04 PM]

    //Perhaps the most simgle script current in the game, the BillBoard script is applied to all sprites
    //and forces their rotation to match that of the cameras, resulting in the image always facing towards
    //the player's position. This was a technique used decades ago to create the illussion of 3D objects 
    //back when many computers couldn't handle 3D. Now, I'm using it as a 3D object illussion because I 
    //don't have the time, resources or experience to properly create 3D models and have them fit into my
    //game world the way I intend. Instead, I'm relying in a tried and tested technique that stylistically
    //works and doesn't require as much effort or time spent.


    public Transform camTransform;

    void Start()
    {
        camTransform = GameObject.FindWithTag("MainCamera").transform;
    }

    private void Update()
    {
        transform.rotation = camTransform.rotation;
    }
}
