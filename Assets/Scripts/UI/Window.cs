using UnityEngine;

public class Window : MonoBehaviour
{
    public Canvas canvas;

    public GameObject window;

    public float time;

    public AnimationCurve curve;
    public void Open()
    {
        canvas.enabled = true;

        window.transform.localScale = Vector3.zero;

        LeanTween.scale(window, Vector2.one, time).setEase(curve);
    }
    public void Close()
    {
        canvas.enabled = false;
    }
}
