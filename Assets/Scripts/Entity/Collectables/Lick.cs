using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lick : Collectable
{
    public float healValue;

    public float scoreValue;

    public List<AudioClip> licks = new List<AudioClip>();
    public void Play()
    {
        Player.instance.Heal(healValue);

        Player.instance.AddToScore(scoreValue);

        if (licks.Count > 0)
        {
            PlayLick();
        }

        gameObject.SetActive(false);

        MakeAvailable();
    }

    public AudioClip GetLick()
    {
        return licks[Random.Range(0, licks.Count)];
    }

    public void PlayLick()
    {
        AudioClip lick = GetLick();

        AudioController.licks.clip = lick;

        AudioController.licks.Play();
    }
}
