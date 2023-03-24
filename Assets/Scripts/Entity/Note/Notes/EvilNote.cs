using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilNote : Entity, IDamagable
{
    public float damage;

    public Vector2 startVelocity;

    public Vector2 velocity;

    public Rigidbody2D rb;

    public CircleCollider2D circleCollider;
    private void Start()
    {
        velocity = startVelocity;
    }
    private void FixedUpdate()
    {
        rb.velocity = velocity * Time.fixedDeltaTime;
    }
    public void Damage()
    {
        Player.instance.Damage(damage);
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
    public void Detach()
    {
        LeanTween.moveY(gameObject, -7, 2f);
    }
}


