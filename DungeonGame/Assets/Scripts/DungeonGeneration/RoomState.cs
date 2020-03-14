using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomState : MonoBehaviour
{
    public bool playerInRoom = false;
    public bool enemyInRoomm = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            playerInRoom = true;
        } 
        if(other.tag == "Enemy")
        {
            enemyInRoomm = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            playerInRoom = false;
        } 
        if(other.tag == "Enemy")
        {
            enemyInRoomm = false;
        }
    }
}
