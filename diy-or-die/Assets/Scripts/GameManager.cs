using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameIsPaused = false;

    public bool GameIsFinished = false;
    public float WinTimer = 100.0f; // seconds 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameIsFinished)
        {
            if (WinTimer > 0.0f)
            {
                WinTimer -= Time.deltaTime;
            }
            else
            {
                // Win!
                GameIsFinished = true;
            }
        }
    }

    public void QuitGame()
    {                          
        Application.Quit();
    }
                                                     
    public void Pause()
    {
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
}
