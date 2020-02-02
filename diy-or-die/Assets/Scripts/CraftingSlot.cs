using UnityEngine;

public class CraftingSlot : MonoBehaviour, IRecepticle
{
    public Droppable Item { get; set; }
    public bool UsesPart { get; private set; }

    public void ReceiveItem(Droppable item)
    {
        if (Item != null)
        {
            Item.transform.Translate(new Vector3(-1, -1));
            ReleaseItem();
        }
        item.Recepticle = this;
        Item = item;
        Item.transform.position = transform.position;
    }

    public void ReleaseItem()
    {
        Item.Recepticle = null;
        Item = null;
    }
}
