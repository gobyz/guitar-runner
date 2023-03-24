using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilNote : Entity, IDamagable
{
    public void Damage()
    {
        Debug.Log("AGGHH");
    }

    override
    public void MakeAvailable()
    {
        transform.localScale = Vector2.one;

        gameObject.SetActive(false);

        isAvailable = true;
    }
}


