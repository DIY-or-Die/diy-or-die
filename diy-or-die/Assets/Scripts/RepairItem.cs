using System;
using UnityEngine;

[CreateAssetMenu()]
public class RepairItem : ScriptableObject
{
    public bool IsMaterial;
    public HealthType HealthType;
    public float HealthValue;
    public Sprite Sprite;
    public ItemType ItemType;
    public float TractionValue;
    public float VisibilityValue;
    public float TemperatureValue;
}