using System;
using UnityEngine;

[CreateAssetMenu()]
public class RepairItem : ScriptableObject
{
    public Sprite Sprite;
    public ItemType ItemType;
    public float TractionValue;
    public float VisibilityValue;
    public float TemperatureValue;
}