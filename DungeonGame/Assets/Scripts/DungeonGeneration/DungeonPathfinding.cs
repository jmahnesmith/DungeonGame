using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPathfinding : MonoBehaviour
{
    public static DungeonPathfinding instance;

    private void Awake()
    {
        instance = this;
    }
    public void FitGridToDungeon()
    {
        Room centerRoom = RoomController.instance.FindRoom(0, 0);
        Room highestRoom = RoomController.instance.FindHighestXYRoom();
        Vector3 centerRoomVector = new Vector3(centerRoom.transform.position.x, centerRoom.transform.position.y, 0);
        Vector3 highestRoomVector = new Vector3(highestRoom.transform.position.x, highestRoom.transform.position.y, 0f);
        var gridGraph = AstarPath.active.data.gridGraph;
    }    
}
