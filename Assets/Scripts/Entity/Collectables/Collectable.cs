using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Entity
{
    public Vector2 startVelocity;

    public Vector2 velocity;

    public Rigidbody2D rb;
    private void Start()
    {
        velocity = startVelocity;
    }
    private void FixedUpdate()
    {
        rb.velocity = velocity * Time.fixedDeltaTime;
    }

    public override void MakeAvailable()
    {
        isAvailable = true;
    }
}
