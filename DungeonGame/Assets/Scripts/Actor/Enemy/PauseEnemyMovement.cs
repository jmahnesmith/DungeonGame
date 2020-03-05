using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEnemyMovement : MonoBehaviour
{
    void Start()
    {
        RoomController.instance.nextRoomDelegate += StartMovement;
        Debug.Log("PauseEnemyMovemnt is now subscribed to nextRoomDelegate");
        if (GetComponent<AIPath>() != null)
        {
            GetComponent<AIPath>().canMove = false;
        }
    }

    private void StartMovement(Room room)
    {
        if (GetComponent<AIPath>() != null)
        {
            GetComponent<AIPath>().canMove = true;
        }
        RoomController.instance.nextRoomDelegate -= StartMovement;
    }
}
