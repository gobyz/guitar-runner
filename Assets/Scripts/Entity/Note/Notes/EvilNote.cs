using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilNote : Entity
{
    public float damage;

    public CircleCollider2D circleCollider;

    private bool isDetached;
    public void Damage()
    {
        if (!isDetached)
        {
            Player.instance.Damage(damage);

            isDetached = true;
        }
    }
    public void Detach()
    {
        LeanTween.moveY(gameObject, -7, 2f);
    }

    override
    public void MakeAvailable()
    {
        isDetached = false;

        transform.localScale = Vector2.one;

        velocity = startVelocity;

        gameObject.SetActive(false);

        circleCollider.enabled = true;

        isAvailable = true;
    }

}


