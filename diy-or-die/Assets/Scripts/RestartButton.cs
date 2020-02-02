using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{

    public GameManager gameManager;
    public Button button;

    private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
    }

    void Update()
    {
        button.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
