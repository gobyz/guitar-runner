using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public bool isAvailable;

    public abstract void MakeAvailable();
}
