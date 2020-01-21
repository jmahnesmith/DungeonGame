using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum NeededDoorDirection
    {
        BottomDoor = 1,
        TopDoor = 2,
        LeftDoor = 3,
        RightDoor = 4
    }
    public NeededDoorDirection needeDoorDirection;

    private RoomTemplates templates;

    private int rand;
    private bool spawned = false;

    public float destroyWaitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, destroyWaitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (spawned == false)
        {
            switch (needeDoorDirection)
            {
                case NeededDoorDirection.BottomDoor:
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    spawned = true;
                    break;
                case NeededDoorDirection.TopDoor:
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    spawned = true;
                    break;
                case NeededDoorDirection.LeftDoor:
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    spawned = true;
                    break;
                case NeededDoorDirection.RightDoor:
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    spawned = true;
                    break;
            }
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            try
            {
                if (!collision.GetComponent<RoomSpawner>().spawned && !spawned)
                {
                    // Spawn walls blocking off any openings!
                    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
            catch (System.Exception e)
            {
                Destroy(gameObject);
            }
            
            spawned = true;
        }
    }
}
