using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTheme : MonoBehaviour
{
    public GameObject instance;
    public int CheckValue;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //CheckValue = SceneManager.GetActiveScene().buildIndex;

        if (instance == null)
        {
            instance = GameObject.Find("MainMenuTheme");
        }

        if (instance != null && instance == this.gameObject)
        {
            //Do Nothing
        }
        else
        {
            //Debug.Log("It's my Fault!");
            Destroy(gameObject);
            return;
        }
    }

    //Checks if the current scene is one of the menu scenes. If not, then the gameObject will be destroyed.
    void Update()
    {
        CheckValue = SceneManager.GetActiveScene().buildIndex;

        if ((CheckValue == 0) || (CheckValue == 30) || (CheckValue == 31) || (CheckValue == 32))
        {
            //Do Nothing
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
