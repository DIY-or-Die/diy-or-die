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
        foreach (StickyNote stickyNote in StickyNotes)
        {
            if (!Recipies.ContainsKey(stickyNote.ItemType))
            {
                Recipies[stickyNote.ItemType] = new List<Dictionary<ItemType, int>>();
            }

            Dictionary<ItemType, int> recipie = new Dictionary<ItemType, int>();
            foreach (StickyNoteContent content in stickyNote.Combination)
            {
                if (!recipie.ContainsKey(content.Type))
                {
                    recipie[content.Type] = 0;
                }
                recipie[content.Type] += 1;
            }
            Recipies[stickyNote.ItemType].Add(recipie);
        };
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