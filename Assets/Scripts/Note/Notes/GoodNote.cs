using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodNote : Entity, IPickable
{
    public Vector2 startVelocity;

    public Vector2 velocity;
    
    public Animator animator;

    public Rigidbody2D rb;

    public CircleCollider2D circleCollider;

    private bool picked;

    private void Start()
    {
        velocity = startVelocity;
    }
    private void FixedUpdate()
    {
        rb.velocity = velocity * Time.fixedDeltaTime;
    }
    public void OnPick()
    {
        velocity = Vector2.zero;

        animator.SetTrigger("fly");

        LeanTween.moveY(gameObject, 7, 2f);
    }
    public void Pick()
    {
        if(!picked)
        {
            OnPick();
        }
    }
    override
    public void MakeAvailable()
    {
        animator.Play("good-note");

        transform.localScale = Vector2.one;

        velocity = startVelocity;

        gameObject.SetActive(false);

        isAvailable = true;
    }
}
