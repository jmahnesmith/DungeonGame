using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatEvent : MonoBehaviour
{
    public delegate void BeatDelegate();
    public event BeatDelegate OnBeat;

    public AudioClip clip;
    public int bpm;
    public int bpmBias;
    public float noteLength
    {
        get;
        private set;
    }

    private void Start()
    {
        bpm = BPM.AnalyzeBpm(clip) + bpmBias;
        noteLength = BPM.CalculateBeatLength(bpm);
        InvokeRepeating("StartBeat", 0f, noteLength * 2);
    }
    void StartBeat()
    {
        if(OnBeat != null)
        OnBeat();
    }


}
