using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : Collectable
{
    public float scoreValue;
    public void AddToScore()
    {
        Player.instance.AddToScore(scoreValue);

        gameObject.SetActive(false);

        MakeAvailable();
    }
}
