using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackground : MonoBehaviour {

    public GameObject[] items;
    public Text levelTxt;

    void Start()
    {
        items[0].SetActive(true);
        items[1].SetActive(true);
        items[2].SetActive(false);
        items[3].SetActive(false);
        levelTxt.text = "LEVEL 1";
        Invoke("DisableText", 2f);
    }
    
    // Update is called once per frame
    void Update () {
        if (EnemiesLeftTxt.enemiesLeft == 95)
        {
            items[0].SetActive(false);
            items[1].SetActive(false);
            items[2].SetActive(true);
            items[3].SetActive(false);
            levelTxt.text = "LEVEL 2";
            levelTxt.enabled = true;
            Invoke("DisableText", 2f);
        }
        if (EnemiesLeftTxt.enemiesLeft == 90)
        {
            items[0].SetActive(false);
            items[1].SetActive(false);
            items[2].SetActive(false);
            items[3].SetActive(true);
            levelTxt.text = "LEVEL 3";
            levelTxt.enabled = true;
            Invoke("DisableText", 2f);
        }
    }

    void DisableText()
    {
        levelTxt.enabled = false;
    }
}