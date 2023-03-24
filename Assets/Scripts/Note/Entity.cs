using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public bool isAvailable;

    public bool isFlipped;

    public GuitarString guitarString;
    public abstract void MakeAvailable();
}
