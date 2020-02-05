using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    void Start()
    {
        
    }

    private void Update()
    {
        foreach(IEquipable item in items)
        {
            item.Equip();
        }
    }
}
