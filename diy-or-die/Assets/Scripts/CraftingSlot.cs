using UnityEngine;

public class CraftingSlot : MonoBehaviour, IRecepticle
{
    public Droppable Item { get; set; }

    public void ReceiveItem(Droppable item)
    {
        if (Item == null)
        {
            Item = item;
            Item.transform.position = transform.position;
        }
    }

    private void Update()
    {
        if (Item != null && Item.IsDragging)
        {
            EmptySlot();
        }
    }

    public void EmptySlot()
    {
        Item = null;
    }
}
