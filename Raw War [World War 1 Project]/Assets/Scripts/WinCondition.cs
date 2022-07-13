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
    public bool WontheGame = false;
    public GameObject[] enemies;
    public GameObject enemySpawner;
    public GameObject music;
    public GameObject artilleryManager;
    public GameObject bombManager;


    private void Start()
    {
        Button btn = button;
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WinGame();
        }
    }

    void WinGame()
    {
        //Do Something
        WontheGame = true;
        clock.playing = false;
        player.SetActive(false);
        winEvent.SetActive(true);
        winScreen.SetActive(true);

        GameObject music = GameObject.FindGameObjectWithTag("LevelMusic");
        GameObject.Destroy(music);

        GameObject bombManager = GameObject.FindGameObjectWithTag("BombManager");
        GameObject.Destroy(bombManager);

        GameObject artilleryManager = GameObject.FindGameObjectWithTag("ArtilleryManager");
        GameObject.Destroy(artilleryManager);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }

        GameObject enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");

        GameObject.Destroy(enemySpawner);
    }
}
