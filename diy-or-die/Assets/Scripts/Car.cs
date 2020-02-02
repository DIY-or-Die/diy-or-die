﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour, IRecepticle
{
    public Slider CarHealthSlider;
    public Slider TractionSlider;
    public Slider VisibilitySlider;
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
        CarHealth = ModifyHealth(CarHealth, CarHealthSlider, -Time.deltaTime * 10);
        Traction = ModifyHealth(Traction, TractionSlider, -Time.deltaTime);
        Visibility = ModifyHealth(Visibility, VisibilitySlider, -Time.deltaTime);
        Temperature = ModifyHealth(Temperature, TemperatureSlider, -Time.deltaTime);
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

    public void ReceiveItem(Droppable item)
    {
        Traction += item.RepairItem.TractionValue;
        Visibility += item.RepairItem.VisibilityValue;
        Temperature += item.RepairItem.TemperatureValue;
    }
}