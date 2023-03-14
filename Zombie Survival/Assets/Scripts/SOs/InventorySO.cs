using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class InventorySO : ScriptableObject
{
    List<ItemSO> inventory;

    public void Add(ItemSO item)
    {
        inventory.Add(item);
    }

    public void Remove(ItemSO item)
    {
        inventory.Remove(item);
    }
}
