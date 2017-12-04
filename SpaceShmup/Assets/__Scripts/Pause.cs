using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public Text pauseTxt;
    public GameObject menuBtn;

    void Start()
    {
        Time.timeScale = 1;
        pauseTxt.text = "PAUSE";
        pauseTxt.enabled = false;
        menuBtn.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseTxt.enabled = true;
                menuBtn.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseTxt.enabled = false;
                menuBtn.SetActive(false);
            }
        }
    }
}