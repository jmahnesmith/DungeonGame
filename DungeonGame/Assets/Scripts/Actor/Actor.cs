using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    protected void Aim(Vector3 target)
    {
        Vector2 dir = (transform.position - target).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }

    protected void Move(Vector2 dir)
    {
        float pen = 1;
        if ((dir.x > 0.5f || dir.x < -0.5f) && (dir.y > 0.5f || dir.y < -0.5f))
        {
            pen = 1.35f;
        }

        rb.velocity = dir.normalized * speed * pen;
    }
}
