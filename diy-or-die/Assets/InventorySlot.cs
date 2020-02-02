using UnityEngine;

public class InventorySlot : MonoBehaviour, IRecepticle
{
    public Droppable Item { get; set; }

    public void ReceiveItem(Droppable item)
    {
        if (Item == null)
        {
            item.Recepticle = this;
            Item = item;
            Item.transform.position = transform.position;
        }
    }

    public void ReleaseItem()
    {
        Item.Recepticle = null;
        Item = null;
    }
}
