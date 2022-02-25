using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveTimer : MonoBehaviour
{
    //[11/12/21] [Friday, 5:05 PM]

    //In this script, applied to any gameObject that I want to be active only temporarily in this world,
    //will ensure that active gameObjects will be setInactive after a designated period of time. If the 
    //script detects that the gameObject it' applied to is in the Hierarchy, then it will start a Coroutine.
    //Once the coroutine is over (as determined by the float effectTimer), then the gameObject will be 
    //SetInactive.


    public float effectTimer;

    public void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine("ExampleCoroutine");
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(effectTimer);

        gameObject.SetActive(false);
    }
}
