using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Animator animator;
    public Text text;
    public GameManager GM;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        this.gameObject.SetActive(false);
    }

    public void PlayAnimation()
    {
        float remainingTime = GM.WinTimer - GM.WinTimeElapsed;
        text.text = "Goal\n"+ remainingTime.ToString("0.00") +" miles";
        this.gameObject.SetActive(true);
        animator.SetBool("Play", true);
    }

    public void ResetTrigger()
    {
        animator.SetBool("Play", false);
        this.gameObject.SetActive(false);
    }

}
