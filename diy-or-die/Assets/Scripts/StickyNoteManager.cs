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

    EventManager eventManager;
    void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        eventManager.onCrafted += HandleOnCrafted;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            eventManager.RaiseOnCrafted(ItemType.Antifreeze);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            eventManager.RaiseOnCrafted(ItemType.Engine);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            eventManager.RaiseOnCrafted(ItemType.Wipers);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            eventManager.RaiseOnCrafted(ItemType.Tire);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            eventManager.RaiseOnCrafted(ItemType.SnowTire);
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            eventManager.RaiseOnCrafted(ItemType.SpeedWipers);
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            eventManager.RaiseOnCrafted(ItemType.Radiator);
        }                                         
    }

    void HandleOnCrafted(ItemType type)
    {   
        // search all hidden sticky notes 
        foreach ( Transform notetrs in transform)
        {
            if (notetrs.gameObject.activeSelf == false)
            {                                   
                // if the type is just crafted is one of the recipe ingredients of this sticky note
                // set this sticky note active.
                StickyNoteUI NoteUI = notetrs.GetComponent<StickyNoteUI>();
                foreach (StickyNoteContent material in NoteUI.Note.Combination)
                {
                    if (material.Type == type)
                    {
                        notetrs.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
