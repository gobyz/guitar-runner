using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public float defaultScale;

    public float pulseScale;

    public float time;

    public void Play()
    {
        gameObject.transform.localScale = Vector3.one * pulseScale;

        LeanTween.scale(gameObject, Vector3.one * defaultScale, time);
    }
}
