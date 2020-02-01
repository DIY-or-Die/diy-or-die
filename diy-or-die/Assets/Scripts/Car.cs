using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public Slider TractionSlider;
    public Slider VisibilitySlider;
    public Slider TemperatureSlider;

    public float Traction { get; set; }
    public float Visibility { get; set; }
    public float Temperature { get; set; }

    private void Start()
    {
        Traction = 10;
        Visibility = 10;
        Temperature = 10;
    }

    private void Update()
    {
        Traction -= Time.deltaTime;
        Visibility -= Time.deltaTime;
        Temperature -= Time.deltaTime;

        TractionSlider.value = Traction / 10;
        VisibilitySlider.value = Visibility / 10;
        TemperatureSlider.value = Temperature / 10;
    }

    public void ConsumeItem(Consumable item)
    {
        Traction += item.TractionValue;
        Visibility += item.VisibilityValue;
        Temperature += item.TemperatureValue;
    }
}