using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DungeonGenerator : MonoBehaviour
{

    
    public DungeonGenerationData dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;


    //Event
    public event Action GenerationCompleteEvent;

    private void Awake()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void Start()
    {

        StartCoroutine(GenerationCompleteCoroutene());
        Debug.Log("GenerationCompleteEvent");
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        List<PossibleRoom> roomTypes = RoomController.instance.possibleRooms;

        RoomController.instance.LoadRoom("Start", 0, 0);
        foreach (Vector2Int roomLocation in rooms)
        {
            int randomRoomIndex = UnityEngine.Random.Range(0, roomTypes.Count);
            PossibleRoom randomRoom = roomTypes[randomRoomIndex];
            

            if(randomRoom.counter == randomRoom.maxSpawns)
            {
                roomTypes.Remove(randomRoom);
                //Reset random index after removal
                randomRoomIndex = UnityEngine.Random.Range(0, roomTypes.Count);
                randomRoom = roomTypes[randomRoomIndex];
            }

            RoomController.instance.LoadRoom(randomRoom.sceneName, roomLocation.x, roomLocation.y);
            randomRoom.counter++;
            
        }
        
    }

    private IEnumerator GenerationCompleteCoroutene()
    {
        yield return new WaitForSeconds(1);
        GenerationCompleteEvent?.Invoke();
        yield return null;
    }


    
}
