using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickyNoteUI : MonoBehaviour
{
    public StickyNote Note;
    public Text DescText;
    public Image PartImage;
    public Image StickyNoteImage;
    public Transform ContentHolder;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Note!=null)
            Init(Note);
    }

    public void Init(StickyNote _Note)
    {
        StickyNoteManager manager = FindObjectOfType<StickyNoteManager>();
        if (_Note)
        {
            DescText.text = _Note.description;
            PartImage.sprite = _Note.HealingPartImage;
            StickyNoteImage.color = manager.StickyColor[(int)_Note.Color];
            foreach (StickyNoteContent mat in _Note.Combination)
            {
                GameObject obj = Instantiate(manager.PrefabStickyNoteContent, ContentHolder);
                obj.GetComponent<StickyNoteContentUI>().Init(mat);
            }
        }
    }
}
