using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public Slider CarHealthSlider;
    public Slider TractionSlider;
    public Slider VisibilitySlider;
    public PartHub[] Hubs;

    internal void AssignItem(Droppable item)
    {
        foreach (PartHub hub in Hubs)
        {
            if (hub.Item == null && item.RepairItem.HealthType == hub.HealthType)
            {
                hub.ReceiveItem(item);
            }
        }
    }

    public Slider TemperatureSlider;

    public float CarHealth { get; set; }
    public float Traction { get; set; }
    public float Visibility { get; set; }
    public float Temperature { get; set; }

    private void Start()
    {
        CarHealth = 10;
        Traction = 10;
        Visibility = 10;
        Temperature = 10;
    }

    private void Update()
    {
        CarHealth = ModifyHealth(CarHealth, CarHealthSlider, CalculateCarHealthLost());
        Traction = ModifyHealth(Traction, TractionSlider, -Time.deltaTime * 0.1f);
        Visibility = ModifyHealth(Visibility, VisibilitySlider, -Time.deltaTime * 0.1f);
        Temperature = ModifyHealth(Temperature, TemperatureSlider, -Time.deltaTime * 0.1f);
    }

    // Changes the slider by the specified amount
    // Returns the resulting value to set to the input health variable
    // Ran into an issue modifying the input health by reference.
    // Fix is adding return value and setting the variable with that value.
    private float ModifyHealth(float currentHealth, Slider slider, float amount)
    {
        currentHealth += amount;
        slider.value = currentHealth / 10;

        return currentHealth;
    }

    private float CalculateHealthTypeLost(HealthType healthType)
    {
        PartHub hub = Hubs.First(h => h.HealthType == healthType);

        if (!hub.Item)
        {
            return -.1f * Time.deltaTime;
        }
        return .1f * hub.Item.RepairItem.HealthValue * Time.deltaTime;
    }

    private float CalculateCarHealthLost()
    {
        float numBrokenParts = 0;
        if (Traction <= 0)
        {
            numBrokenParts++;
        }
        if (Visibility <= 0)
        {
            numBrokenParts++;

        }
        if (Temperature <= 0)
        {
            numBrokenParts++;
        }

        return -Time.deltaTime * (.10f + numBrokenParts);
    }
}