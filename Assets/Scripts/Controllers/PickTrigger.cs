using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickTrigger : MonoBehaviour
{
    public Entity currentEntity;

    public UnityEvent triggerEntered = new UnityEvent();

    public UnityEvent triggerExited = new UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentEntity = collision.GetComponent<Entity>();

        triggerEntered.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentEntity = null;

        triggerExited.Invoke();
    }
}
