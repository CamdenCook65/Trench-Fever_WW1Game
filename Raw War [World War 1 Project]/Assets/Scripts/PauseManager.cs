using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool pausing = false;
    public Text text;
    public float TimerClock = 3;
    public float speed = -1;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pausing = true;
            pauseMenu.SetActive(true);
            StartCoroutine("ExampleCoroutine");
        }
        else if (!Input.GetKey(KeyCode.Escape))
        {
            pausing = false;
            StopCoroutine("ExampleCoroutine");
            pauseMenu.SetActive(false);
        }


        if (pausing == false)
        {
            TimerClock = 4;
        }

        if (pausing == true)
        {
            TimerClock += Time.deltaTime * speed;
            string seconds = Mathf.Floor((TimerClock % 60)).ToString("0");
            text.text = seconds;
        }
    }

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            SceneManager.LoadScene(0);

        }


    }
}
