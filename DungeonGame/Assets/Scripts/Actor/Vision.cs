using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public Transform targetTransform;
    public float viewDistance = 1000f;
    public LayerMask rayCastLayerMask;
    public bool canSeePlayer()
    {
        var heading = targetTransform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, viewDistance, rayCastLayerMask);
        Debug.DrawRay(transform.position, direction * viewDistance, Color.red);
        if (hit)
        {
            if (hit.collider.tag == "Player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
