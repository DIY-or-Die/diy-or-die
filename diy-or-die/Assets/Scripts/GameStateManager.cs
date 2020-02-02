using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public Car car;
    public GameObject GameOverMenu;
    public GameObject BackgroundDim;

    void Update()
    {
        if (car.CarHealth <= 0)
        {
            GameOverMenu.SetActive(true);
            BackgroundDim.SetActive(true);
        }
    }
}
