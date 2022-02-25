using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public GameObject player;
    public GameObject winEvent;
    public Timer clock;
    public GameObject winScreen;
    public Button button;

    private void Start()
    {
        Button btn = button;
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WinGame();
        }
    }

    void WinGame()
    {
        //Do Something
        clock.playing = false;
        player.SetActive(false);
        winEvent.SetActive(true);
        winScreen.SetActive(true);
    }
}
