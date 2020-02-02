using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* It is declared in StickyNoteContentUI.cs
[System.Serializable]
public class StickyNoteContent
{
    public string Name;
    public int Count;
}
*/

[CreateAssetMenu()]
public class StickyNote : ScriptableObject
{
    public ItemType ItemType;
    public string description;
    public Sprite HealingPartImage;
    public StickyNoteContent[] Combination; 
}
