using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarStrings : MonoBehaviour
{
    public static GuitarStrings instance;

    private void Start()
    {
        instance = this;
    }

    public List<GuitarString> strings = new List<GuitarString>();
}
