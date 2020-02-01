using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    public int width;
    public int height;
    public int x;
    public int y;

    [SerializeField]
    private bool enemyInRoom = false;
    [SerializeField]
    private bool playerInRoom = false;
    [SerializeField]
    private bool doorsClosed = false;
    [SerializeField]
    private bool updatedDoors = false;
    [SerializeField]
    private bool roomDefeated = false;

    public Room(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    

    public Door leftDoor;
    public Door rightDoor;
    public Door topDoor;
    public Door bottomDoor;

    public List<Door> doors = new List<Door>();

    // Start is called before the first frame update
    void Start()
    { 

        if(RoomController.instance == null)
        {
            return;
        }
        //Cache EnemyController
        enemySpawner = GetComponent<EnemySpawner>();

        Door[] ds = GetComponentsInChildren<Door>();
        foreach( Door d in ds)
        {
            doors.Add(d);
            switch(d.doorType)
            {
                case Door.DoorType.right:
                    rightDoor = d;
                    break;
                case Door.DoorType.left:
                    leftDoor = d;
                    break;
                case Door.DoorType.top:
                    topDoor = d;
                    break;
                case Door.DoorType.bottom:
                    bottomDoor = d;
                    break;
            }
        }

        RoomController.instance.RegisterRoom(this);

    }

    private void Update()
    {
        if (name.Contains("End") && !updatedDoors)
        {
            RemoveUnconnectedDoors();
            updatedDoors = true;
        }

        if(enemyInRoom && playerInRoom)
        {
            CloseDoors();
            doorsClosed = true;
        }
        if (doorsClosed && !enemyInRoom)
        {
            OpenDoors();
            doorsClosed = false;
        }
        
    }

    public void RemoveUnconnectedDoors()
    {
        foreach (Door door in doors)
        {
            switch (door.doorType)
            {
                case Door.DoorType.right:
                    if(GetRight() == null)
                    {
                        CloseDoor(door);
                        door.active = false;
                    }
                    break;
                case Door.DoorType.left:
                    if (GetLeft() == null)
                    {
                        CloseDoor(door);
                        door.active = false;
                    }
                    break;
                case Door.DoorType.top:
                    if (GetTop() == null)
                    {
                        CloseDoor(door);
                        door.active = false;
                    }
                    break;
                case Door.DoorType.bottom:
                    if (GetBottom() == null)
                    {
                        CloseDoor(door);
                        door.active = false;
                    }
                    break;
            }
        }
    }

    private static void CloseDoor(Door door)
    {
        door.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        door.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
    private static void OpenDoor(Door door)
    {
        door.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        door.GetComponentInChildren<SpriteRenderer>().color = Color.black;
    }

    public Room GetRight()
    {
        if(RoomController.instance.DoesRoomExist(x+1, y))
        {
            return RoomController.instance.FindRoom(x + 1, y);
        }
        return null;
    }
    public Room GetLeft()
    {
        if (RoomController.instance.DoesRoomExist(x -1, y))
        {
            return RoomController.instance.FindRoom(x - 1, y);
        }
        return null;
    }
    public Room GetTop()
    {
        if (RoomController.instance.DoesRoomExist(x , y + 1))
        {
            return RoomController.instance.FindRoom(x , y + 1);
        }
        return null;
    }
    public Room GetBottom()
    {
        if (RoomController.instance.DoesRoomExist(x, y - 1))
        {
            return RoomController.instance.FindRoom(x, y - 1);
        }
        return null;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    public Vector3 GetRoomCenter()
    {
        return new Vector3(x * width, y * height);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if(collision.tag == "Player")
        {
            RoomController.instance.OnPlayerEnterRoom(this);

            //Flag that player is in room.
            playerInRoom = true;

            //SpawnEnemies
            if (enemySpawner != null && playerInRoom)
            {
                Invoke("SpawnEnemies", 0.2f);
            }
                
        }

        //Close / Open Doors
        if (collision.tag == "Enemy")
        {
            enemyInRoom = true;
        }
    }
    private void SpawnEnemies()
    {
        if(roomDefeated == false)
        enemySpawner.SpawnEnemies(this);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length - 1 == 0)
            enemyInRoom = false;
            roomDefeated = true;
        }
        if (collision.tag == "Player")
        {
            playerInRoom = false;
        }
    }
    public void CloseDoors()
    {
        foreach (Door door in doors)
        {
            if (door.active && playerInRoom && enemyInRoom)
            CloseDoor(door);

        }
    }
    private void OpenDoors()
    {
        foreach (Door door in doors)
        {
            if(door.active)
            OpenDoor(door);

        }
    }
}
