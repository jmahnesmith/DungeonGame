using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class RoomInfo
{
    public string name;
    public int x;
    public int y;
}


public class RoomController : MonoBehaviour
{
    public static RoomController instance;

    public List<PossibleRoom> possibleRooms = new List<PossibleRoom>();

    private EnemySpawner enemyController;

    string currentWorldName = "Level1";

    RoomInfo currentLoadRoomData;

    Room currRoom;

    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    public List<Room> loadedRooms = new List<Room>();

    bool isLoadingRoom = false;
    bool spawnedBoosRoom = false;
    bool updatedRoom = false;

    private void Awake()
    {
        instance = this;
        enemyController = GetComponent<EnemySpawner>();
    }

    private void Update()
    {
        UpdateRoomQueue();
    }

    private void UpdateRoomQueue()
    {
        if(isLoadingRoom)
        {
            return;
        }
        if (loadRoomQueue.Count == 0)
        {
            if (!spawnedBoosRoom)
            {
                StartCoroutine(SpawnBossRoom());
            }
            else if (spawnedBoosRoom && !updatedRoom)
            {
                foreach(Room room in loadedRooms)
                {
                    room.RemoveUnconnectedDoors();
                }
                updatedRoom = true;
            }
            return;
        }

        currentLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;

        StartCoroutine(loadRoomRoutine(currentLoadRoomData));
    }

    IEnumerator SpawnBossRoom()
    {
        spawnedBoosRoom = true;
        yield return new WaitForSeconds(0.5f);
        if(loadRoomQueue.Count == 0)
        {
            Room bossRoom = loadedRooms[loadedRooms.Count - 1];
            Room tempRoom = new Room(bossRoom.x, bossRoom.y);
            Destroy(bossRoom.gameObject);

            var roomToRemove = loadedRooms.Single(r => r.x == tempRoom.x && r.y == tempRoom.y);
            loadedRooms.Remove(roomToRemove);
            LoadRoom("End", tempRoom.x, tempRoom.y);
        }
    }

    public void LoadRoom(string name, int x, int y)
    {
        if(DoesRoomExist(x, y))
        {
            return;
        }
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = name;
        newRoomData.x = x;
        newRoomData.y = y;

        loadRoomQueue.Enqueue(newRoomData);
    }

    /// <summary>
    /// Loads the room into the scene.
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    IEnumerator loadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;

        AsyncOperation loadRoom = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while(loadRoom.isDone == false)
        {
            yield return null;
        }
    }

    public void RegisterRoom(Room room)
    {
        if (!DoesRoomExist(currentLoadRoomData.x, currentLoadRoomData.y))
        {
            room.transform.position = new Vector3
            (
            currentLoadRoomData.x * room.width,
            currentLoadRoomData.y * room.height,
            0);

            room.x = currentLoadRoomData.x;
            room.y = currentLoadRoomData.y;
            room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.x + ", " + room.y;
            room.transform.parent = transform;

            isLoadingRoom = false;

            if (loadedRooms.Count == 0)
            {
                CameraController.instance.currRoom = room;
            }

            loadedRooms.Add(room);
            
        }
        else
        {
            Destroy(room.gameObject);
            isLoadingRoom = false;
        }
        
    }

    public Room FindRoom(int x, int y)
    { 
        return loadedRooms.Find(item => item.x == x && item.y == y);
    }

    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find(item => item.x == x && item.y == y);
    }

    public void OnPlayerEnterRoom(Room room)
    {
        CameraController.instance.currRoom = room;
        currRoom = room;

    }
    private Room FindHighestYRoom()
    {
        Room highestYRoom = new Room(0,0);
        int highestY = 0;
        foreach (Room room in loadedRooms)
        {
            if (highestY <= room.y)
            {
                highestY = room.y;
                highestYRoom = room;
            }
                
        }
        return highestYRoom;
    }
    private Room FindHighestXRoom()
    {
        Room highestXRoom = new Room(0, 0);
        int highestX = 0;
        foreach (Room room in loadedRooms)
        {
            if (highestX <= room.x)
            {
                highestX = room.x;
                highestXRoom = room;
            }

        }
        return highestXRoom;
    }
    public Room FindHighestXYRoom()
    {
        if(FindHighestXRoom().x >= FindHighestYRoom().y)
        {
            return FindHighestXRoom();
        }
        else
        {
            return FindHighestYRoom();
        }
        
    }
}
