using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public Dial CarHealthDial;
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

    private float _carHealth;
    public float CarHealth
    {
        get
        {
            return _carHealth;
        }
        set
        {
            _carHealth = value;
            if (_carHealth < 0)
            {
                _carHealth = 0;
            }
            else if (_carHealth > 10)
            {
                _carHealth = 10;
            }
        }
    }
    private float _traction;
    public float Traction
    {
        get
        {
            return _traction;
        }
set
        {
            _traction = value;
            if (_traction < 0)
            {
                _traction = 0;
            }
            else if (_traction > 10)
            {
                _traction = 10;
            }
        }
    }
    private float _visibility;
    public float Visibility
    {
        get
        {
            return _visibility;
        }
        set
        {
            _visibility = value;
            if (_visibility < 0)
            {
                _visibility = 0;
            }
            else if (_visibility > 10)
            {
                _visibility = 10;
            }
        }
    }
    private float _temperature;
    public float Temperature
{
    get
    {
        return _temperature;
    }
    set
    {
            _temperature = value;
        if (_temperature < 0)
        {
                _temperature = 0;
        }
        else if (_temperature > 10)
        {
                _temperature = 10;
        }
    }
}

private void Start()
    {
        CarHealth = 10;
        Traction = 10;
        Visibility = 10;
        Temperature = 10;
    }

    private void Update()
    {
        CarHealth = ModifyHealth(CarHealth, CarHealthDial, CalculateCarHealthLost());
        Traction = ModifyHealth(Traction, TractionSlider, CalculateHealthTypeLost(HealthType.Traction, Traction));
        Visibility = ModifyHealth(Visibility, VisibilitySlider, CalculateHealthTypeLost(HealthType.Visibility, Visibility));
        Temperature = ModifyHealth(Temperature, TemperatureSlider, CalculateHealthTypeLost(HealthType.Temperature, Temperature));
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

    private float ModifyHealth(float currentHealth, Dial dial, float amount)
    {
        currentHealth += amount;
        dial.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Lerp(130, -130, currentHealth / 10)));
        return currentHealth;
    }

    private float CalculateHealthTypeLost(HealthType healthType, float value)
    {
        PartHub hub = Hubs.First(h => h.HealthType == healthType);

        if (!hub.Item)
        {
            return (-.25f - .025f * value) * Time.deltaTime;
        }
        return (.25f + .025f * (10 - value)) * hub.Item.RepairItem.HealthValue * Time.deltaTime;
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

        return numBrokenParts == 0 ? 0 : -Time.deltaTime * .2f * (Mathf.Pow(2, numBrokenParts) / 2 - 1);
    }
}