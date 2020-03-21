using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public float laserBeamLength = 15f;
    LineRenderer line;
    bool laserOn = false;


    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }
    void Update()
    {
        Vector3 endPosition = transform.position + (transform.right * laserBeamLength);
        Vector2 laserDirection = transform.right;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, laserDirection, laserBeamLength);

        if (hit)
        {
            Debug.Log(hit.transform.name);
            if (hit.collider.tag == "Player")
                hit.transform.GetComponent<Health>().TakeDamage(25f);

            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.right * laserBeamLength);
        }

        //line.SetPositions(new Vector3[] { transform.position, endPosition });
    }
    /*IEnumerator FireLaser()
    {
        line.enabled = true;

        while (laserOn)
        {
            Ray2D ray = new Ray2D(transform.position, transform.up);
            RaycastHit2D hit;

            line.SetPosition(0, ray.origin);

            hit = Physics2D.Raycast(ray.origin, transform.up);

            Debug.DrawLine(transform.position, hit.point);

            if (hit.collider)
            {
                line.SetPosition(1, hit.point);
            }
            else
                line.SetPosition(1, transform.up * 2000);

            yield return null;
        }
        line.enabled = false;
        laserOn = false;
    }*/
}
