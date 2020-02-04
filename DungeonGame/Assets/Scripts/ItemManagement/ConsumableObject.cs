using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Item/Consumable")]
public class ConsumableObject : ItemObject
{
    private void Awake()
    {
        type = ItemType.Consumable;
    }
}
