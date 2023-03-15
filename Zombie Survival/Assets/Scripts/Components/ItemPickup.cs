using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public ItemSO item;
    
    public event Action<ItemPickup,Actor> OnItemPickUp;
    public override void Interact(Actor interactor)
    {
        base.Interact(interactor);
        PickUp(interactor);
    }

    public void PickUp(Actor pickUpper)
    {
        if(pickUpper.inventory != null && pickUpper.inventory.Add(item))
        {
            OnItemPickUp?.Invoke(this, pickUpper);
            Destroy(gameObject);
        }
    }
}
