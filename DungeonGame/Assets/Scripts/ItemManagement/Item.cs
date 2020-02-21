﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    public string itemName;
    public string itemDesc;
    public bool isEquiped = false;

    public virtual void AddToInventory(Item item)
    {
        PlayerInventory.instance.items.Add(item);
    }

    

    public virtual void Equip(GameObject player, GameObject item)
    {
        item.transform.SetParent(player.transform);
        item.transform.rotation = player.transform.rotation;
        isEquiped = true;
    }

}
