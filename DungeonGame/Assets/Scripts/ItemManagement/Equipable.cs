using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Equipable : MonoBehaviour
{
    public bool isEquiped = false;
    public virtual void Equip(GameObject player, GameObject item)
    {
        item.transform.position = player.transform.position;
        item.transform.rotation = player.transform.rotation;
        item.transform.SetParent(player.transform);

        isEquiped = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Equip(collision.gameObject, this.gameObject);
        }
    }
}
