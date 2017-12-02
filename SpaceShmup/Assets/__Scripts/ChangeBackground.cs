using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour {

    public GameObject[] items;

    void Start()
    {
        items[0].SetActive(true);
        items[1].SetActive(true);
        items[2].SetActive(false);
    }
    
    // Update is called once per frame
    void Update () {
        if (EnemiesLeftTxt.enemiesLeft == 90)
        {
            items[0].SetActive(false);
            items[1].SetActive(false);
            items[2].SetActive(true);
        }
    }
}