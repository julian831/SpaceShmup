﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public int startTime = 0;
    public Text clockText;
    private int timeCount;
    static public bool TimeStop { get; set; }

    // Use this for initialization
    void Start()
    {
        TimeStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount = startTime + (int)Time.time;
        //if (timeCount <= 0 || TimesUp == true)
        //{
          //  TimeStop = true;
            //clockText.text = "Time Left = 0:00";
        //}
        //else
        //{
            int minutes = timeCount / 60;
            int seconds = timeCount % 60;
            clockText.text = "Timer = " + minutes + ":" + seconds.ToString("D2");
        //}
    }
}