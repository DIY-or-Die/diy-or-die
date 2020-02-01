using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class CraftingController : MonoBehaviour
{
    public CraftingSlot[] Slots;
    public Droppable[] DroppablePrefabs;

    private Dictionary<ItemType, Droppable> Droppables;
    private Dictionary<ItemType, List<Dictionary<ItemType, int>>> Recipies;

    private void Start()
    {
        AssembleRecipies();

        Droppables = new Dictionary<ItemType, Droppable>();
        foreach (Droppable droppable in DroppablePrefabs)
        {
            Droppables[droppable.RepairItem.ItemType] = droppable;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Craft();
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
            slot.EmptySlot();
        }
    }
}
