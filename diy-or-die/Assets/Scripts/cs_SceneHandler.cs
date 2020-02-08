using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cs_SceneHandler : MonoBehaviour
{
    public void GoToPlay()
    {
        SceneManager.LoadScene("Avery");
    }

    public void GoToWin()
    {
        SceneManager.LoadScene("End_Win");
    }

    public void GoToLose()
    {
        SceneManager.LoadScene("End_Lose");
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
