using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Timer : MonoBehaviour
{
    public static int secondsPassed;
    public static int minutesPassed;
    public Text timerText;
    public static bool stopTimer;

    //public AudioClip clip;
    //AudioSource audio;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("TimeCounter");
        minutesPassed = 0;
        secondsPassed = 0;
        stopTimer = false;
        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = ("Time: " + minutesPassed + ":" + secondsPassed.ToString("00"));

        if (stopTimer == true) 
        { 
            StopTimer();
            stopTimer = false;
        }
    }


    IEnumerator TimeCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            secondsPassed++;
            if(secondsPassed == 60)
            {
                secondsPassed = 0;
                minutesPassed++;
            }
        }
    }

    public void StopTimer()
    {
        StopCoroutine("TimeCounter");
    }

}