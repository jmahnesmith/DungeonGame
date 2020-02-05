using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunItem : Item, IEquipable
{
    private GameObject player;
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player");
    }
    public void Equip()
    {
        Debug.Log(player.GetComponentInChildren<GameObject>().name);
    }
    
}
