using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTextController : MonoBehaviour {

    public GameManager gameManager;
    private Text progressText;

    // Start is called before the first frame update
    void Start()
    {
        progressText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        double milesLeft = System.Math.Floor((double) gameManager.WinTimer - gameManager.WinTimeElapsed);
        progressText.text = "Miles To Safe House: " + milesLeft;
    }
}
