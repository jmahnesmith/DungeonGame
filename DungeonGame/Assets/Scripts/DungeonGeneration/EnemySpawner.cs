using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public float xOffSet;
    public float yOffSet;

    private int numberOfEnemies;
    private int indexOfRandomEnemy;

    private void Start()
    {
        
        //RoomController.instance.nextRoomDelegate += SpawnEnemies;
        
    }

    /*private void SpawnEnemies(Room room)
    {
        numberOfEnemies = Random.Range(room.minEnemySpawns, room.maxEnemySpawns);

        if (!room.roomDefeated && room.playerInRoom && room.canSpawnEnemy)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Vector2 randomPos = GetRandomPosition(room);
                indexOfRandomEnemy = Random.Range(0, enemies.Length);
                GameObject enemy = Instantiate(enemies[indexOfRandomEnemy], randomPos, Quaternion.identity);
            }
            Debug.Log("Spawning Enemies at " + room.name);
            
        }

        
    }
    */


    /*private Vector2 GetRandomPosition(Room room)
    {
        BoxCollider2D roomCollider = room.GetComponent<BoxCollider2D>();
        Vector2 colliderPos = roomCollider.transform.position;
        float randomPosX = Random.Range(colliderPos.x - (roomCollider.size.x + xOffSet) / 2, colliderPos.x + (roomCollider.size.x + xOffSet) / 2);
        float randomPosY = Random.Range(colliderPos.y - (roomCollider.size.y + yOffSet) / 2, colliderPos.y + (roomCollider.size.y + yOffSet) / 2);
        
        return new Vector2(randomPosX, randomPosY);
    }
    */
    



    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, boxColliderSize);
    }*/
}
