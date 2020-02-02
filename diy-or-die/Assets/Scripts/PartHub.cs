using UnityEngine;

public class PartHub : MonoBehaviour, IRecepticle
{
    public Droppable Item { get; set; }
    public bool UsesPart { get; private set; }

    public Car Car;
    public HealthType HealthType;

    private void Start()
    {
        UsesPart = true;
    }

    public void ReceiveItem(Droppable item)
    {
        if (item.RepairItem.IsMaterial)
        {
            switch (HealthType)
            {
                case HealthType.Traction:
                    Car.Traction += item.RepairItem.TractionValue;
                    break;
                case HealthType.Visibility:
                    Car.Visibility += item.RepairItem.VisibilityValue;
                    break;
                case HealthType.Temperature:
                    Car.Temperature += item.RepairItem.TemperatureValue;
                    break;
                default:
                    break;
            }
            Destroy(item.gameObject);
        }
        else if (item.RepairItem.HealthType != HealthType)
        {
            Car.AssignItem(item);
        }
        else
        {
            if (Item != null)
            {
                Item.transform.Translate(new Vector3(1, 1));
                ReleaseItem();
            }
            item.Recepticle = this;
            Item = item;
            Item.transform.position = transform.position;
            Item.transform.Translate(new Vector3(0, -1.6f, 0));
        }
    }

    public void ReleaseItem()
    {
        Item.Recepticle = null;
        Item = null;
    }
}
