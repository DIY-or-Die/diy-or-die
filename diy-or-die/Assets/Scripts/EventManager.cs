using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnCrafted(ItemType type);
    public event OnCrafted onCrafted;

    public void RaiseOnCrafted(ItemType type)
    {
        onCrafted?.Invoke( type );
    }
}
