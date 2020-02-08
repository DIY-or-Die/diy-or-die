using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private Button button;
    public GameObject tutorialLayout;
    public GameObject creditsLayout;

    // added this script to the Canvas object instead of individual buttons
    // public methods are called by the buttons referencing the canvas via OnClick()

    /* private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ToggleTutorialLayout);
    } */

    public void ToggleTutorialLayout()
    {
        tutorialLayout.SetActive(!tutorialLayout.activeSelf);
    }
    public void ToggleCreditsLayout()
    {
        creditsLayout.SetActive(!creditsLayout.activeSelf);
    }
}
