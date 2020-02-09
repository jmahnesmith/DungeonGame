using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunItem : Item, IEquipable
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Equip()
    {
        transform.SetParent(player.transform);
        transform.rotation = player.transform.rotation;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Equip();
        }
    }

}
