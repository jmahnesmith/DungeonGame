using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Item/Consumable")]
public class EquiptableObject : ItemObject
{
    private void Awake()
    {
        type = ItemType.Equipable;
    }
}
