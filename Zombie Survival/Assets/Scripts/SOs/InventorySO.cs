using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class InventorySO : ScriptableObject
{
    public List<ItemSO> inventory;

    public void Add(ItemSO item)
    {
        inventory.Add(item);
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }

    public void Remove(ItemSO item)
    {
        inventory.Remove(item);
    }
}
