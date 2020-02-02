using System;
using UnityEngine;

[CreateAssetMenu()]
public class RepairItem : ScriptableObject
{
    public bool IsMaterial;
    public Sprite Sprite;
    public ItemType ItemType;
    public float TractionValue;
    public float VisibilityValue;
    public float TemperatureValue;
}