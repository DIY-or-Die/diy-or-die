using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Animator animator;
    public Text text;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void PlayAnimation()
    {
        this.gameObject.SetActive(true);
        animator.SetBool("Play", true);
    }

    public void ResetTrigger()
    {
        animator.SetBool("Play", false);
        this.gameObject.SetActive(false);
    }

}
