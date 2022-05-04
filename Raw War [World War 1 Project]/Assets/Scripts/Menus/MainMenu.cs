using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject LevelsUI;
    public GameObject EncyclopediaUI;
    public GameObject CreditsUI;


    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        MainMenuUI.SetActive(false);
        LevelsUI.SetActive(true);
        EncyclopediaUI.SetActive(false);
        CreditsUI.SetActive(false);

    }

    public void Encyclopedia()
    {
        MainMenuUI.SetActive(false);
        LevelsUI.SetActive(false);
        EncyclopediaUI.SetActive(true);
        CreditsUI.SetActive(false);
    }

    public void ReturntoMain()
    {
        MainMenuUI.SetActive(true);
        LevelsUI.SetActive(false);
        EncyclopediaUI.SetActive(false);
        CreditsUI.SetActive(false);
    }

    public void Credits()
    {
        MainMenuUI.SetActive(false);
        LevelsUI.SetActive(false);
        EncyclopediaUI.SetActive(false);
        CreditsUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
