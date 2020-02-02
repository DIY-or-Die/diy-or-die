﻿using UnityEngine;

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
            Car.Traction += item.RepairItem.TractionValue;
            Car.Visibility += item.RepairItem.VisibilityValue;
            Car.Temperature += item.RepairItem.TemperatureValue;
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
        }
    }

    public void ReleaseItem()
    {
        Item.Recepticle = null;
        Item = null;
    }
}
