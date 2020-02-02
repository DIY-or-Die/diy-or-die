using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StickyNoteColor {
    Yellow = 0,
    Pink = 1,
    Blue = 2,
}


public class StickyNoteManager : MonoBehaviour
{
    public GameObject PrefabStickyNoteContent;           
    // Start is called before the first frame update
    public Color[] StickyColor;

    void Start()
    {
        EventManager eventManager = FindObjectOfType<EventManager>();
        eventManager.onCrafted += HandleOnCrafted;
    }

    void HandleOnCrafted(ItemType type)
    {
        StickyNoteUI[] children = GetComponentsInChildren<StickyNoteUI>();

        // search all hidden sticky notes 
        foreach ( StickyNoteUI note in children )
        {
            if (!note.gameObject.activeSelf)
            {
                // if the type is just crafted is one of the recipe ingredients of this sticky note
                // set this sticky note active.
                foreach (StickyNoteContent material in note.Note.Combination)
                {
                    if (material.Type == type)
                    {
                        note.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
