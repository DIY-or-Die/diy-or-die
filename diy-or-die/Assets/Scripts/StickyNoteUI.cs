using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickyNoteUI : MonoBehaviour
{
    public StickyNote Note;
    public Text DescText;
    public Transform ContentHolder;
    
    // Start is called before the first frame update
    void Start()
    {
        StickyNoteManager manager = FindObjectOfType<StickyNoteManager>(); 

        if (Note)
        {
            DescText.text = Note.description;
            foreach (StickyNoteContent mat in Note.Combination)
            {
                GameObject obj = Instantiate(manager.PrefabStickyNoteContent, ContentHolder);
                obj.GetComponent<StickyNoteContentUI>().Init(mat);
            }
        }
    }
}
