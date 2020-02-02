using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinHandler : MonoBehaviour
{
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.OnWin += HandleWin;
    }

    void HandleWin()
    {
        winPanel.SetActive(true);
    }
}
