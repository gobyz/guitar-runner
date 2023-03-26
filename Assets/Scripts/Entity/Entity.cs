using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public bool isAvailable;

    public bool isFlipped;

    public Vector2 startVelocity;
    [HideInInspector]
    public Vector2 velocity;

    public Rigidbody2D rb;

    public GuitarString guitarString;
    public abstract void MakeAvailable();
    public abstract void Interact();

    private void Start()
    {
        velocity = startVelocity;
    }
    private void FixedUpdate()
    {
        rb.velocity = velocity * Time.fixedDeltaTime;
    }
}
