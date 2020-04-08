using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;


    public void Aim(Vector3 target)
    {
        Vector2 dir = (transform.position - target).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = angle + 90;


        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    private  IEnumerator RotateOverTimeCoroutine(Vector3 originalPosition, Vector3 finalPosition, float duration)
    {
        if(duration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            transform.rotation = GetAngle(originalPosition);
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                // progress will equal 0 at startTime, 1 at endTime.
                transform.rotation = Quaternion.Slerp(GetAngle(originalPosition), GetAngle(finalPosition), progress);
                yield return null;
            }
        }
        transform.rotation = GetAngle(finalPosition);
    }

    public void RotateOverTime(Vector3 originalPosition, Vector3 finalPosition, float duration)
    {
        StartCoroutine(RotateOverTimeCoroutine(originalPosition, finalPosition, duration));
    }

    public void Move(Vector2 dir)
    {
        float pen = 1;
        if ((dir.x > 0.5f || dir.x < -0.5f) && (dir.y > 0.5f || dir.y < -0.5f))
        {
            pen = 1.35f;
        }

        rb.velocity = dir.normalized * speed * pen;
    }
    private Quaternion GetAngle(Vector3 target)
    {
        Vector2 dir = (transform.position - target).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = angle + 90;

        return Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
