using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    public Image fill;

    public Color loadingColor;

    public Color availableColor;

    public Color activeColor;

    public Image keyImage;
    public void Set(float fillRatio, bool isLoading)
    {
        fill.fillAmount = 1 - fillRatio;

        if (fill.fillAmount == 1)
        {
            SetColor(availableColor);
        }
        else
        {
            if(isLoading)
            {
                SetColor(loadingColor);
            }
            else
            {
                SetColor(activeColor);
            }
        }
    }
    public void SetColor(Color color)
    {
        fill.color = color;

        keyImage.color = color;
    }
}
