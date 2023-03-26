using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordPart : Entity
{
    public float damage;

    public bool damagedPlayer;
    public void Damage()
    {
        if (!damagedPlayer)
        {
            Player.instance.Damage(damage);

            damagedPlayer = true;
        }
    }
    public override void Interact()
    {
        Damage();
    }

    public override void MakeAvailable()
    {
        damagedPlayer = false;
    }
}
