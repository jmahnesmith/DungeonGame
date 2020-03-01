using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolItem : Item
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Equip(GameObject player, GameObject item)
    {
        base.Equip(player, this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isEquiped)
        {
            Equip(player, this.gameObject);
            AddToInventory(this);
            if (GetComponent<Shooting>())
                GetComponent<Shooting>().ToggleShooting();
        }
    }
}
