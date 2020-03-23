using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncWithLaser : MonoBehaviour
{
    public float maxLineIntensity;
    public float minLineIntensity;
    public float damage = 1f;

    private LineRenderer line;
    private BeatEvent beat;

    private IEnumerator MoveToIntensity(int intencity)
    {

        float _curr = maxLineIntensity;
        float _originalValue = _curr;
        float _timer = 0;

        while (_curr != intencity)
        {
            _curr = Mathf.Lerp(_curr, intencity, _timer / (beat.noteLength * 2));
            _timer += Time.deltaTime;

            ChangeLaserHeight(_curr);

            _curr = Mathf.Lerp(_curr, _originalValue, _timer / (beat.noteLength * 2));
            _timer += Time.deltaTime;

            ChangeLaserHeight(_curr);

            yield return null;
        }

    }
    void LateUpdate()
    {
        Vector2 laserDirection = transform.right;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, laserDirection, GetLaserLength().magnitude - 4);
        Debug.DrawRay(this.transform.position, laserDirection, Color.green);

        if (hit)
        {
            Debug.Log(hit.transform.name);
            if (hit.collider.tag == "Player")
                hit.transform.GetComponent<Health>().TakeDamage(damage);
        }

        //line.SetPositions(new Vector3[] { transform.position, endPosition });
    }

    void ChangeLaserHeight(float val)
    {
        line.SetPosition(1, new Vector3(val, 0, 0));
    }

    Vector3 GetLaserLength()
    {
        Debug.Log(transform.TransformPoint(line.GetPosition(1)).magnitude - 4);
        return transform.TransformPoint(line.GetPosition(1));
    }

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(1, new Vector3(minLineIntensity, 0, 0));
        beat = FindObjectOfType<BeatEvent>();
        beat.OnBeat += OnBeat;
    }

    private void OnBeat()
    {
        StopCoroutine("MoveToIntensity");
        StartCoroutine("MoveToIntensity", maxLineIntensity);
    }
    private void OnDestroy()
    {
        beat.OnBeat -= OnBeat;
    }
}
