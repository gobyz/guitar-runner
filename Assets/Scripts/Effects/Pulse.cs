using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public float pulseScale;

    public float time;
    private void Start()
    {
        AudioController.beat.AddListener(Play);
    }
    public void Play()
    {
        Vector2 defaultScale = transform.localScale;

        transform.localScale = defaultScale * pulseScale;

        LeanTween.scale(gameObject, defaultScale, time);
    }
}
