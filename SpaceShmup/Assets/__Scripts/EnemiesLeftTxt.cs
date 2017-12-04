using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeftTxt : MonoBehaviour {
    public Text enemiesLTxt;
    public static int enemiesLeft = 0;
    
    void Start()
    {
        enemiesLeft = 0;
    }

    // Update is called once per frame
    void Update () {
        enemiesLTxt.text = "Enemies Killed = " + enemiesLeft;
    }
}