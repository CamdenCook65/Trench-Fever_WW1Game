using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public bool playing = true;
    public Text text;
    public float TimerClock;
    public float speed = 1;

    void Start()
    {
        //text = GetComponent<Text>();
    }

    void Update()
    {
        if (playing == true)
        {
            //The clock ticks upwards, Minutes:Seconds in place of Hours:Minutes
            TimerClock += Time.deltaTime * speed;
            string minutes = Mathf.Floor((TimerClock % 3600) / 60).ToString("0");
            string seconds = (TimerClock % 60).ToString("00");
            text.text = "Time" + " " + minutes + ":" + seconds;
        }
    }
}
