using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{

    private Button button;

    private void Start()
    {
        Debug.LogError("restartStart");
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        Debug.LogError("please");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
