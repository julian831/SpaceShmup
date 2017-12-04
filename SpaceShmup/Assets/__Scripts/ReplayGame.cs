using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour {

    public void RestartGame(int sceneMain)
    {
        SceneManager.LoadScene(sceneMain);
    }

}