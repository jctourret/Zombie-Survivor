using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact(Actor interactor)
    {
        Debug.Log("Interactor " + interactor.name + " has interacted with " + gameObject.name);

    }
}