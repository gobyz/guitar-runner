using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Collectable
{
    public float healValue;

    public void HealPlayer()
    {
        Player.instance.Heal(healValue);

        gameObject.SetActive(false);

        MakeAvailable();
    }
    public override void Interact()
    {
        HealPlayer();
    }
}
