using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class InventorySO : ScriptableObject
{
    public static event Action OnInventoryChange;
    public List<ItemSO> items;
    private int space = 10;
    public bool Add(ItemSO item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Inventory Full");
            return false;
        }
        else
        {
            items.Add(item);
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            OnInventoryChange?.Invoke();
            return true;
        }
    }

    public void Remove(ItemSO item)
    {
        items.Remove(item);
    }
}
