using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public float xOffSet;
    public float yOffSet;
    public void SpawnEnemies(Room room)
    {
        Vector2 randomPos = GetRandomPosition(room);
        Instantiate(enemy, randomPos, Quaternion.identity);
    }

    private Vector2 GetRandomPosition(Room room)
    {
        BoxCollider2D roomCollider = room.GetComponent<BoxCollider2D>();
        Vector2 colliderPos = roomCollider.transform.position;
        float randomPosX = Random.Range(colliderPos.x - (roomCollider.size.x + xOffSet) / 2, colliderPos.x + (roomCollider.size.x - xOffSet) / 2);
        float randomPosY = Random.Range(colliderPos.y - (roomCollider.size.y + yOffSet) / 2, colliderPos.y + (roomCollider.size.y - yOffSet) / 2);
        return new Vector2(randomPosX, randomPosY);
    }

    private void SetEnemyTarget()
    {

    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, boxColliderSize);
    }*/
}
