using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public int startTime;
    public Text clockText;
    private int timeCount;
    static public bool timeStop { get; set; }

    // Use this for initialization
    void Start()
    {
        startTime = 0;
        timeStop = true;
    }

    void Awake()
    {
        timeStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStop == false)
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
}