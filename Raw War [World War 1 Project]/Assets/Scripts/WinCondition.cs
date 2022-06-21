﻿using System.Collections;
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
        WontheGame = true;
        clock.playing = false;
        player.SetActive(false);
        winEvent.SetActive(true);
        winScreen.SetActive(true);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }

        GameObject enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");

        GameObject.Destroy(enemySpawner);
    }
}
