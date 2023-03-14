using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class ItemSO : ScriptableObject
{
    public int ItemId;
    new public string name = "New Item";
    public Sprite icon;

    public virtual void Use()
    {

    }
}
