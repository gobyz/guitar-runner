using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float angle;
    void Start()
    {
        AudioController.beat.AddListener(RotateObject);    
    }
    public void RotateObject()
    {
        angle *= -1;

        LeanTween.rotateZ(gameObject, angle, 0.5f).setEaseInBack();
    }
}
