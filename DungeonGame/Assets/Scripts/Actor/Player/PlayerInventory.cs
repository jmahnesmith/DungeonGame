using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public List<Item> items = new List<Item>();
    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        
    }

    public Item GetCurrentlyEquipedItem()
    {
        if (items.Count == 0)
        {
            
        }

        foreach (Item item in items)
        {
            if(item.isEquiped)
            {
                return item;
            }
            else
            {
                
            }
        }
        return null;
    }
}
