using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public partial class CraftingController : MonoBehaviour
{
    private void AssembleRecipies()
    {
        Recipies = new Dictionary<ItemType, List<Dictionary<ItemType, int>>>();
        Recipies[ItemType.Tire] = new List<Dictionary<ItemType, int>>();
        Recipies[ItemType.Wipers] = new List<Dictionary<ItemType, int>>();
        Recipies[ItemType.Radiator] = new List<Dictionary<ItemType, int>>();

        Dictionary<ItemType, int> tireRecipie = new Dictionary<ItemType, int>();
        tireRecipie[ItemType.Rubber] = 1;
        tireRecipie[ItemType.Metal] = 1;
        tireRecipie[ItemType.Bolts] = 1;
        Recipies[ItemType.Tire].Add(tireRecipie);

        Dictionary<ItemType, int> wiperRecipie = new Dictionary<ItemType, int>();
        wiperRecipie[ItemType.Rubber] = 1;
        wiperRecipie[ItemType.Fluid] = 1;
        wiperRecipie[ItemType.Plastic] = 1;
        Recipies[ItemType.Wipers].Add(wiperRecipie);

        Dictionary<ItemType, int> radiatorRecipie = new Dictionary<ItemType, int>();
        radiatorRecipie[ItemType.Fluid] = 1;
        radiatorRecipie[ItemType.Metal] = 1;
        radiatorRecipie[ItemType.Spring] = 1;
        Recipies[ItemType.Radiator].Add(radiatorRecipie);
    }

    private Dictionary<ItemType, int> CreateRecipie(CraftingSlot[] slots)
    {
        Dictionary<ItemType, int> recipie = new Dictionary<ItemType, int>();

        foreach (ItemType val in Enum.GetValues(typeof(ItemType)))
        {
            recipie[val] = 0;
        }

        foreach (CraftingSlot slot in slots)
        {
            recipie[slot.Item.RepairItem.ItemType] += 1;
        }
        return recipie;
    }
}

public class RecipieComparer : IEqualityComparer<Dictionary<ItemType, int>>
{
    public bool Equals(Dictionary<ItemType, int> recipie, Dictionary<ItemType, int> items)
    {
        foreach (KeyValuePair<ItemType, int> kvp in recipie)
        {
            if (!items.ContainsKey(kvp.Key) || items[kvp.Key] < kvp.Value)
            {
                return false;
            }
        }
        return true;
    }

    public int GetHashCode(Dictionary<ItemType, int> obj)
    {
        throw new NotImplementedException();
    }
}