using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEnemyMovement : MonoBehaviour
{
    public float duration = 1f;
    void Start()
    {
        if (GetComponent<AIPath>() != null)
        {
            GetComponent<AIPath>().canMove = false;
        }
        StartCoroutine(StartMovement());
    }

    private IEnumerator StartMovement()
    {
        yield return new WaitForSeconds(duration);
        if (GetComponent<AIPath>() != null)
        {
            GetComponent<AIPath>().canMove = true;
        }
        
    }
}
