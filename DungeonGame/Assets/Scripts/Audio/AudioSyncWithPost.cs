using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class AudioSyncWithPost : AudioSyncer
{
    public float maxBloomIntensity;
    public float minBloomIntensity;

    private float bloomIntensity;
    private int m_randomIndx;
    public PostProcessProfile postProcessProfile;
    private IEnumerator MoveToIntensity(int intencity)
    {
        
        float _curr = postProcessProfile.GetSetting<Bloom>().intensity.value;
        float _originalValue = _curr;
        float _timer = 0;

        while (_curr != intencity)
        {
            _curr = Mathf.Lerp(_curr, intencity, _timer / timeToBeat);
            _timer += Time.deltaTime;

            ChangeBloom(_curr);

            _curr = Mathf.Lerp(_curr, _originalValue, _timer / timeToBeat);
            _timer += Time.deltaTime;

            ChangeBloom(_curr);

            yield return null;
        }

        m_isBeat = false;
    }


    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat) return;

        postProcessProfile.GetSetting<Bloom>().intensity.value = Mathf.Lerp(10f, 15f, restSmoothTime * Time.deltaTime);
    }

    void ChangeBloom(float val)
    {
        postProcessProfile.GetSetting<Bloom>().intensity.value = val;
    }

    private void DuplicatePostProcessing()
    {
        var newProfile = Instantiate(postProcessProfile, transform);
        postProcessProfile = newProfile;

    }
    private void Awake()
    {
        DuplicatePostProcessing();
    }

    private void Start()
    {
        FindObjectOfType<BeatEvent>().OnBeat += OnBeat;
        Debug.Log("Subscribed to on beat from post.");
    }

    private void OnBeat()
    {
        base.OnBeat();
        StopCoroutine("MoveToIntensity");
        StartCoroutine("MoveToIntensity", maxBloomIntensity);
    }
}
