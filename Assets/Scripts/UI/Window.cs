using UnityEngine;

public class Window : MonoBehaviour
{
    public Canvas canvas;

    public GameObject window;

    public float time;

    public AnimationCurve curve;

    public bool shouldPause;
    public void Open()
    {
        canvas.enabled = true;

        window.transform.localScale = Vector3.zero;

        LeanTween.scale(window, Vector2.one, time).setEase(curve);

        if (shouldPause)
        {
            Pause();
        }
    }
    public void Close()
    {
        canvas.enabled = false;

        if (shouldPause)
        {
            Unpause();
        }
    }

    public void Pause()
    {
        //Time.timeScale = 0;
    }

    public void Unpause()
    {
        //Time.timeScale = 1;
    }
}
