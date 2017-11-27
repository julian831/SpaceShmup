using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeftTxt : MonoBehaviour {
    public Text enemiesLTxt;
    
    // Update is called once per frame
    void FixedUpdate () {
        enemiesLTxt.text = "Enemies Left = " + Enemy.enemiesLeft;
    }
}