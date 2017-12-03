using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeftTxt : MonoBehaviour {
    public Text enemiesLTxt;
    public static int enemiesLeft = 100;
    
    void Start()
    {
        enemiesLeft = 100;
    }

    // Update is called once per frame
    void Update () {
        enemiesLTxt.text = "Enemies Left = " + enemiesLeft;
    }
}