using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public ItemSO item;
    
    public event Action<ItemPickup> OnItemPickUp;
    public override void Interact(Actor interactor, InventorySO inventory)
    {
        base.Interact(interactor,inventory);
        inventory.Add(item);
    }

    public void PickUp()
    {
        OnItemPickUp?.Invoke(this);
        Destroy(gameObject);
    }
}
