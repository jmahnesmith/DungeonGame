using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;
    bool updatedGrid = false;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
        Invoke("UpdatePathfindingGrid", 1f);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        List<PossibleRoom> roomTypes = RoomController.instance.possibleRooms;

        RoomController.instance.LoadRoom("Start", 0, 0);
        foreach (Vector2Int roomLocation in rooms)
        {
            int randomRoomIndex = Random.Range(0, roomTypes.Count);
            PossibleRoom randomRoom = roomTypes[randomRoomIndex];
            

            if(randomRoom.counter == randomRoom.maxSpawns)
            {
                roomTypes.Remove(randomRoom);
                //Reset random index after removal
                randomRoomIndex = Random.Range(0, roomTypes.Count);
                randomRoom = roomTypes[randomRoomIndex];
            }

            RoomController.instance.LoadRoom(randomRoom.sceneName, roomLocation.x, roomLocation.y);
            randomRoom.counter++;
            




        }
        
    }

    private void UpdatePathfindingGrid()
    {
        AstarPath.active = FindObjectOfType<AstarPath>();
        AstarPath.active.Scan();
    }
}
