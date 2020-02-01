using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameManager GM;
    public Text text;
    public Button button;                             

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        button.onClick.AddListener(HandleClick);
        // When game is currently paused, this button works as resume button
        if (GM.GameIsPaused)
            text.text = "Resume";
        else
            text.text = "Pause";
    }
              
    void HandleClick()
    {
        if (GM.GameIsPaused)
        {
            GM.Resume();
            // It resumes and the button is going to work as pause button again
            text.text = "Pause";
        }
        else
        {
            GM.Pause();
            text.text = "Resume";
        }
    }
                                     
}
