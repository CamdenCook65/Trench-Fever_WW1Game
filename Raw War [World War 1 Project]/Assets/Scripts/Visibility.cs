using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    public bool visible;
    public bool invisible;

    private void Start()
    {
        visible = false;
        invisible = true;
    }

    private void Update()
    {
        if(visible == true)
        {
            invisible = false;
        }

        if(invisible == true)
        {
            visible = false;
        }
    }

    public void OnBecameVisible()
    {
        visible = true;
        invisible = false;
        Debug.Log("Spawner Visible!");
    }

    public void OnBecameInvisible()
    {
        visible = false;
        invisible = true;
        Debug.Log("Spawner Invisible!");
    }


}
