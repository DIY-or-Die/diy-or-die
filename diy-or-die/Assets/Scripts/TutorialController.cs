using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private Button button;
    public GameObject tutorialLayout;

    private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ToggleTutorialLayout);
    }

    void ToggleTutorialLayout()
    {
        tutorialLayout.SetActive(!tutorialLayout.activeSelf);
    }
}
