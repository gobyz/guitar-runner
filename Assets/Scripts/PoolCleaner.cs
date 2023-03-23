using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity = collision.GetComponent<Entity>();

        if (entity != null)
        {
            entity.MakeAvailable();
        }
    }
}
