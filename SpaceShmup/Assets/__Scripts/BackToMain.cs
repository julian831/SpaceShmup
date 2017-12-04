using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour {
    
    // Update is called once per frame
    public void  ReturnMainMenu(int sceneMain) {
        SceneManager.LoadScene(sceneMain);        
    }
}