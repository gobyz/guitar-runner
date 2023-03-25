using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilNote : Entity
{
    public float damage;

    public CircleCollider2D circleCollider;
    public void Damage()
    {
        Player.instance.Damage(damage);
    }
    public void Detach()
    {
        LeanTween.moveY(gameObject, -7, 2f);
    }

    override
    public void MakeAvailable()
    {
        transform.localScale = Vector2.one;

        velocity = startVelocity;

        gameObject.SetActive(false);

        circleCollider.enabled = true;

        isAvailable = true;
    }

}


