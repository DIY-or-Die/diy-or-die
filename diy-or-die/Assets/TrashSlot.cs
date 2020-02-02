using UnityEngine;

public class TrashSlot : MonoBehaviour, IRecepticle
{
    public void ReceiveItem(Droppable item)
    {
        Destroy(item.gameObject);
    }
}
