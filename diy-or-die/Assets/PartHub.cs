using UnityEngine;

public class PartHub : MonoBehaviour, IRecepticle
{
    public Droppable Item { get; set; }

    public Car Car;

    public void ReceiveItem(Droppable item)
    {
        if (item.RepairItem.IsMaterial)
        {
            Car.Traction += item.RepairItem.TractionValue;
            Car.Visibility += item.RepairItem.VisibilityValue;
            Car.Temperature += item.RepairItem.TemperatureValue;
            Destroy(item.gameObject);
        }
        else
        {
            if (Item == null)
            {
                item.Recepticle = this;
                Item = item;
                Item.transform.position = transform.position;
            }
        }
    }

    public void ReleaseItem()
    {
        Item.Recepticle = null;
        Item = null;
    }
}
