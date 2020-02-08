using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public Car car;
    public GameObject GameOverMenu;
    public GameObject BackgroundDim;
    public Canvas Canvas;

    void Update()
    {
        if (car.CarHealth <= 0)
        {
            Canvas.GetComponent<cs_SceneHandler>().GoToLose();
            //GameOverMenu.SetActive(true);
            //BackgroundDim.SetActive(true);
        }
    }
}
