using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject MainMenuUI;
    //public GameObject LevelsUI;
    //public GameObject EncyclopediaUI;
    //public GameObject CreditsUI;


    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 30);
    }

    public void Encyclopedia()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 31);
    }

    public void ReturntoMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 32);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
