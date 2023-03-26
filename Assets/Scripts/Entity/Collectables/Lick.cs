using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lick : Collectable
{
    public float healValue;

    public float scoreValue;
    public void Play()
    {
        Player.instance.Heal(healValue);

        Player.instance.AddToScore(scoreValue);

        gameObject.SetActive(false);

        MakeAvailable();
    }
}
