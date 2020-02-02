using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;

    public enum ItemType
    {
        None,
        Consumable,
        Equiptable
    }
    public ItemType itemType;
}
