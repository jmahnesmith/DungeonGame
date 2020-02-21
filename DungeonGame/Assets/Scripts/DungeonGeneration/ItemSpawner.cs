using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    private Room room;
    private int roomX;
    private int roomY;

    void Start()
    {
        FindObjectOfType<DungeonGenerator>().GenerationCompleteEvent += SpawnItem;
        Debug.Log("ItemSpawner Subscribed to Dungeon Generation Event.");
        
    }

    private void SpawnItem()
    {
        room = GetComponent<Room>();
        roomX = room.x;
        roomY = room.y;

        int randomNumber = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomNumber], RoomController.instance.FindRoom(roomX, roomY).GetRoomCenter(), Quaternion.identity);

        Debug.Log("Spawning Item...");
        FindObjectOfType<DungeonGenerator>().GenerationCompleteEvent -= SpawnItem;
    }
}
