using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Entity
{
    public override void MakeAvailable()
    {
        isAvailable = true;
    }
}
