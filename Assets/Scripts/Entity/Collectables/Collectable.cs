using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Collectable : Entity
{   
    public override void MakeAvailable()
    {
        if (isFlipped)
        {
            Vector3 scale = transform.localScale;

            transform.localScale = new Vector3(scale.x, -scale.y, scale.z);
        }

        gameObject.SetActive(false);

        isAvailable = true;
    }
}
