using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
                        
[System.Serializable]
public class StickyNoteContent
{
    public string Name;
    public int Count;
}
                              
public class StickyNoteContentUI : MonoBehaviour
{
    public StickyNoteContent Content;
    public Text Name;
    public Text Count;

    private void Start()
    {
        Init(Content);
    }

    public void Init(StickyNoteContent content)
    {
        if (content == null) return; // raise an error or warning?
        Content = content;      
        Name.text = content.Name;
        Count.text = "x" + content.Count.ToString();    
    }
}
