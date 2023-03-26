using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    public Vector2 offsetIncrement;
    void Update()
    {
        meshRenderer.material.mainTextureOffset += offsetIncrement * Time.deltaTime;
    }
}
