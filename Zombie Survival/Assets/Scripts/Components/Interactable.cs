using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactionRadius;

    public virtual void Interact(Actor interactor, InventorySO inventory)
    {
        Debug.Log("Interactor "+ interactor.name + " has interacted with " + gameObject.name);
    }
}
