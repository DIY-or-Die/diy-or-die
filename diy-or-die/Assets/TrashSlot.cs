﻿using UnityEngine;

public class TrashSlot : MonoBehaviour, IRecepticle
{
    public Droppable Item { get; set; }

    public void ReceiveItem(Droppable item)
    {
        Destroy(item.gameObject);
    }

    public void ReleaseItem()
    {
        Item.Recepticle = null;
        Item = null;
    }
}
