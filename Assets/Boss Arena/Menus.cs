using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
    }

    public void restartGame() 
    {
        StateManager.over = false;
        StateManager.lives = 3;
        StateManager.score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene ("Arena");
    }

}