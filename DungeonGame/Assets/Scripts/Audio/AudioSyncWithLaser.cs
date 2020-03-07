using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncWithLaser : AudioSyncer
{
    public float maxLineIntensity;
    public float minLineIntensity;

    private LineRenderer line;
    private IEnumerator MoveToIntensity(int intencity)
    {

        float _curr = maxLineIntensity;
        float _originalValue = _curr;
        float _timer = 0;

        while (_curr != intencity)
        {
            _curr = Mathf.Lerp(_curr, intencity, _timer / timeToBeat);
            _timer += Time.deltaTime;

            ChangeLaserHeight(_curr);

            _curr = Mathf.Lerp(_curr, _originalValue, _timer / timeToBeat);
            _timer += Time.deltaTime;

            ChangeLaserHeight(_curr);

            yield return null;
        }

        m_isBeat = false;
    }


    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat) return;

        ChangeLaserHeight(Mathf.Lerp(minLineIntensity, maxLineIntensity, restSmoothTime * Time.deltaTime));
    }

    public override void OnBeat()
    {
        base.OnBeat();

        StopCoroutine("MoveToIntensity");
        StartCoroutine("MoveToIntensity", maxLineIntensity);
    }

    void ChangeLaserHeight(float val)
    {
        line.SetPosition(1, new Vector3(val, 0, 0));
    }

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(1, new Vector3(minLineIntensity, 0, 0));
    }
}
