using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Animator animator;        
    public GameManager GM;
    public bool AnimationAvailable;
    public GameObject SignUI;            

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        SignUI.SetActive(false);
        AnimationAvailable = true;     
    }

    void Update()
    {
        if (AnimationAvailable)
        {
            PlayAnimation();
        }
    }
                                    
    public void PlayAnimation()
    {
        float remainingTime = GM.WinTimer - GM.WinTimeElapsed;
        SignUI.SetActive(true);
        animator.SetBool("Play", true);
        AnimationAvailable = false;
    }

    public void ResetTrigger()                                                                                                                      
    {
        animator.SetBool("Play", false);
        SignUI.SetActive(false);
        AnimationAvailable = true;
    }

}
