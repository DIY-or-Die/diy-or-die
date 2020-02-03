using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    private Button button;

    private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Avery");
    }
}
