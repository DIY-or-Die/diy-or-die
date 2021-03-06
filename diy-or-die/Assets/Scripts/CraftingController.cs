﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class CraftingController : MonoBehaviour
{
    EventManager eventManager;
    public CraftingSlot[] Slots;
    public Droppable[] DroppablePrefabs;
    public StickyNote[] StickyNotes;

    private Dictionary<ItemType, Droppable> Droppables;
    public Dictionary<ItemType, List<Dictionary<ItemType, int>>> Recipies { get; private set; }

    private void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        AssembleRecipies();

        Droppables = new Dictionary<ItemType, Droppable>();
        foreach (Droppable droppable in DroppablePrefabs)
        {
            Droppables[droppable.RepairItem.ItemType] = droppable;
        }
    }

    public void Craft()
    {
        if (Slots.Any(s => s.Item == null))
        {
            return;
        }

        Droppable product = null;
        Dictionary<ItemType, int> items = CreateRecipie(Slots);
        RecipieComparer recipieComparer = new RecipieComparer();

        foreach (KeyValuePair<ItemType, List<Dictionary<ItemType, int>>> recipieList in Recipies)
        {
            foreach (Dictionary<ItemType, int> recipie in recipieList.Value)
            {
                if (recipieComparer.Equals(recipie, items))
                {
                    product = Instantiate(Droppables[recipieList.Key]);
                    if (eventManager != null)
                    {
                        eventManager.RaiseOnCrafted(recipieList.Key);
                    }
                }
            }
        }

        if (product == null)
        {
            product = Instantiate(Droppables[ItemType.Junk]);
        }

        foreach (CraftingSlot slot in Slots)
        {
            Destroy(slot.Item.gameObject);
            slot.ReleaseItem();
        }
    }
}
