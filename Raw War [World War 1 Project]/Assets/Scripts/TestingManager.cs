using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingManager : MonoBehaviour
{
    //[11/12/21] [Friday, 5:24 PM]

    //This is a basic script used for the Test Level. Whenever applied, the scene will reset if the player
    //presses Z on the keyboard. This is a more efficient means of testing code and seeing if everything is
    //working without having to exit and reenter the scene everytime the player is killed.


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            //Debug.Log("Test Test");

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();

            Debug.Log("Quit Game");
        }

    }
}
