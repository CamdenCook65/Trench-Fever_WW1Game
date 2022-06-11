using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeOrganizer : MonoBehaviour
{
    public AudioSource instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<AudioSource>();
        }

        if(instance != null && instance != this)
        {
               //Destroy(gameObject);
        }
    }
}
