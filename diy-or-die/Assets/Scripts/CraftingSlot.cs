using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlot : MonoBehaviour, IRecepticle
{
    public Droppable Item { get; set; }

    public void ReceiveItem(Droppable item)
    {
        Item = item;
        Item.transform.position = transform.position;
    }
}
