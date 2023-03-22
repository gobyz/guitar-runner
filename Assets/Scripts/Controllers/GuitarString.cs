using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuitarString : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip sound;

    public LineRenderer lineRenderer;

    public int points;

    public float amplitude = 0;

    public float frequency = 1;

    public Vector2 xLimits = new Vector2(0, 1);

    public float movementSpeed = 1;

    [Range(0, 2 * Mathf.PI)]
    public float radians;

    public float maxAmplitude;

    public float time;

    public const float Tau = 2 * Mathf.PI;

    public void PlayString()
    {
        PlaySound();

        StartCoroutine(AnimateStringCoroutine());
    }

    public void PlaySound()
    {
        audioSource.clip = sound;

        audioSource.Play();
    }

    public IEnumerator AnimateStringCoroutine()
    {
        Coroutine drawCoroutine = StartCoroutine(Draw());

        LeanTween.value(gameObject, SetAmplitude, 0, maxAmplitude, time);

        yield return new WaitForSeconds(time);

        LeanTween.value(gameObject, SetAmplitude, maxAmplitude, 0, time);

        yield return new WaitForSeconds(time);

        StopCoroutine(drawCoroutine);
    }
    private void SetAmplitude(float val)
    {
        amplitude = val;
    }
    private IEnumerator Draw()
    {
        lineRenderer.positionCount = points;

        while (true)
        {
            for (int currentPoint = 0; currentPoint < points; currentPoint++)
            {
                float progress = (float)currentPoint / (points - 1);

                float x = Mathf.Lerp(xLimits.x, xLimits.y, progress);

                float y = amplitude * Mathf.Sin((Tau * frequency * x) + (Time.timeSinceLevelLoad * movementSpeed));

                lineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
            }

            yield return null;
        }
    }
}
