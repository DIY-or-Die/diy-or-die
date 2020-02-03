using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ExitApplication);
    }

    void ExitApplication()
    {
        Application.Quit();
    }
}
