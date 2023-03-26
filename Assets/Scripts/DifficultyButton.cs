using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    public TMP_Text difficultyText;
    private void Start()
    {
        if (DifficultyController.instance != null)
        {
            DifficultyController.instance.SetButtonText(difficultyText);

            DifficultyController.instance.SetStartDifficulty();
        }
    }

    public void ChangeDifficulty()
    {
        DifficultyController.instance.ChangeDifficulty();
    }
}
