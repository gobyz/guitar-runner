using System.Collections;
using UnityEngine;

public class GoodNote : Entity, IPickable
{    
    public Animator animator;

    public CircleCollider2D circleCollider;

    private bool picked;
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
    public void FocusToGuitarString(GuitarString guitarString)
    {
        StartCoroutine(Jump(guitarString));
    }
    public IEnumerator Jump(GuitarString guitarString)
    {
        Vector2 scale = transform.localScale;

        LeanTween.scale(gameObject, Vector2.zero, 0.2f).setEaseInCubic();

        yield return new WaitForSeconds(0.2f);

        if (isFlipped)
        {
            gameObject.transform.position = new Vector3(transform.position.x, guitarString.spawnDown.transform.position.y, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(transform.position.x, guitarString.spawnUp.transform.position.y, 0);
        }

        LeanTween.scale(gameObject, Vector2.one * scale, 0.2f).setEaseInCubic();

        yield return new WaitForSeconds(0.2f);
    }
}
