using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardManager : MonoBehaviour
{
    public GameObject PrefabStickyNoteContent;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {     
    }

    public void Open()
    {
        animator.SetBool("IsOpen", true);
    }

    public void Close()
    {
        animator.SetBool("IsOpen", false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
