using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncWithLaser : MonoBehaviour
{
    public float maxLineIntensity;
    public float minLineIntensity;

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

    void ChangeLaserHeight(float val)
    {
        line.SetPosition(1, new Vector3(val, 0, 0));
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
