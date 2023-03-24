using System;
using System.Collections;
using UnityEngine;

public class JumpNote : MonoBehaviour
{
    public Entity entity;

    public GameObject note;

    public int beatsToJump;

    public int maxJumps;

    public float time;

    public GameObject upIndicator;

    public GameObject downIndicator;

    public AnimationCurve scaleCurve;

    private GuitarString currentString;

    private GuitarString nextString;

    private int beatsCount;

    private int jumpCount;

    private bool isJumpUp;
    public void OnEnable()
    {
        jumpCount = 0;

        beatsCount = 0;

        currentString = entity.guitarString;

        SetJumpDirection(currentString, true);

        SetIndicator();       
    }
    private void Start()
    {
        AudioController.beat.AddListener(JumpCheck);
    }
    public void SetJumpDirection(GuitarString guitarString, bool isStart = false)
    {
        int index = guitarString.index;

        if (index == 0)
        {
            isJumpUp = false;

            nextString = DownString(guitarString);
        }
        else if (index == 5)
        {
            isJumpUp = true;

            nextString = UpString(guitarString);
        }
        else
        {
            if (isStart)
            {
                System.Random rnd = new System.Random();

                isJumpUp = (rnd.Next(2) == 0);
            }
            
            if (isJumpUp)
            {
                nextString = UpString(guitarString);
            }
            else
            {
                nextString = DownString(guitarString);
            }
        }
    }
    public GuitarString UpString(GuitarString guitarString)
    {
        return GuitarStrings.instance.strings[guitarString.index - 1];
    }
    public GuitarString DownString(GuitarString guitarString)
    {
        return GuitarStrings.instance.strings[guitarString.index + 1];
    }
    public void SetIndicator()
    {     
        if (isJumpUp)
        {
            upIndicator.SetActive(true);

            downIndicator.SetActive(false);  
        }
        else
        {
            upIndicator.SetActive(false);

            downIndicator.SetActive(true);
        }
    }
    public void JumpCheck()
    {
        beatsCount++;

        if(beatsCount == beatsToJump && jumpCount <= maxJumps - 1 && gameObject.activeSelf)
        {
            jumpCount++;

            StartCoroutine(Jump());
        }
    }
    public IEnumerator Jump()
    {       
        Vector2 scale = note.transform.localScale;

        LeanTween.scale(note, Vector2.zero, time).setEase(scaleCurve);

        yield return new WaitForSeconds(time);

        if (entity.isFlipped)
        {
            gameObject.transform.position = new Vector3(transform.position.x, nextString.spawnDown.transform.position.y, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(transform.position.x, nextString.spawnUp.transform.position.y, 0);
        }

        LeanTween.scale(note, Vector2.one * scale, time).setEase(scaleCurve);

        yield return new WaitForSeconds(time);

        OnJumpFinished();
    }
    public void OnJumpFinished()
    {
        beatsCount = 0;

        currentString = nextString;

        entity.guitarString = currentString;

        SetJumpDirection(currentString);

        SetIndicator();

        if (jumpCount == maxJumps)
        {
            DisableIndicators();
        }
    }
    public void DisableIndicators()
    {
        upIndicator.SetActive(false);

        downIndicator.SetActive(false);
    }

    public void SetToFinished()
    {
        jumpCount = maxJumps;

        OnJumpFinished();
    }
}
