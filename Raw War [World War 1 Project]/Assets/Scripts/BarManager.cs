using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Subsystems;

public class BarManager : MonoBehaviour
{
    //[11/12/21] [Friday, 3:01 PM]

    //This is a simple script, it determines whether the GunBar on the HUD is visible or not. If the player
    //has clicked a button used to switch towards another weapon, the bar will briefly appear at the top
    //of the screen so player's can see all of their available options. The bar is been setInactive after
    //a short amount of time called waitTime. The BarManager script is placed under the PlayerManager
    //gameObject.


    public GameObject gunBar;
    public float waitTime;

    void Start()
    {
        gunBar.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha6)) || (Input.GetKeyDown(KeyCode.Alpha7)) || (Input.GetKeyDown(KeyCode.Alpha8)) || (Input.GetKeyDown(KeyCode.Alpha9))))
        {
            gunBar.SetActive(true);

            StartCoroutine("ExampleCoroutine");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunBar.SetActive(false);
            StopCoroutine("ExampleCoroutine");
            //Debug.Log("Weapon Fired");
        }
    }

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            gunBar.SetActive(false);

            StopCoroutine("ExampleCoroutine");
        }
    }
}
