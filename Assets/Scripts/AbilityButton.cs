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
            fill.color = availableColor;

            keyImage.color = availableColor;
        }

        else
        {
            if(isLoading)
            {
                fill.color = loadingColor;

                keyImage.color = loadingColor;
            }
            else
            {
                fill.color = activeColor;

                keyImage.color = activeColor;
            }
        }
    }
}
