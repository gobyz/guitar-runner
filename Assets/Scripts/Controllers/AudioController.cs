using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AudioController : MonoBehaviour
{
    [SerializeField] private float bpm;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Intervals[] intervals;

    public static UnityEvent beat = new UnityEvent();

    public bool isPaused;

    public List<AudioSource> audioSources = new List<AudioSource>();
    private void Awake()
    {
        foreach (AudioSource source in audioSources)
        {
            source.mute = Settings.isMuted;
        }
    }

    private void Update()
    {
        foreach(Intervals interval in intervals)
        {
            float sampleTime = (audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLenght(bpm)));

            interval.CheckForNewInterval(sampleTime);
        }
    }

    public void Beat()
    {
        if (!isPaused)
        {
            beat.Invoke();
        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float steps;

    [SerializeField] private UnityEvent trigger;

    private int lastInterval;

    public float GetIntervalLenght(float bpm)
    {
        return 60f / (bpm * steps);
    }

    public void CheckForNewInterval (float interval)
    {
        if(Mathf.FloorToInt(interval) != lastInterval) 
        { 
            lastInterval = Mathf.FloorToInt(interval);

            trigger.Invoke();
        }
    }
}
