using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEnemyMovement : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<CameraController>().nextRoomDelegate += StartMovement;
        Debug.Log("PauseEnemyMovemnt is now subscribed to nextRoomDelegate");
        if (GetComponent<AIPath>() != null)
        {
            GetComponent<AIPath>().canMove = false;
        }
    }

    private void StartMovement()
    {
        if (GetComponent<AIPath>() != null)
        {
            GetComponent<AIPath>().canMove = true;
        }
        FindObjectOfType<CameraController>().nextRoomDelegate -= StartMovement;
    }
}
