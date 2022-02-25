using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    //[2/1/22] [Tuesday, 11:53 PM]

    //Here is a script that's about as simple as it gets. If the host Gameobject of this script is currently
    //active, then the designated prefab will be instantiated at the objects location. There's really 
    //nothing more to that. It's a simple but really versatile function that can be applicable in hundreds
    //of possible scenerios. Hopefully it does me wonders!


    public GameObject prefab;
    public Transform place;

    void Update()
    {
        if (gameObject != null)
        {
            Instantiate(prefab, place);
            Debug.Log("Success!");
        }
        
    }
}
