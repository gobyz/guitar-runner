using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public static DifficultyController instance;

    [SerializeField]
    public List<Difficulty> difficulties = new List<Difficulty>();
    [HideInInspector]
    public Difficulty currentDifficulty;

    private Difficulty startDifficulty;

    public TMP_Text difficultyButtonText;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SetStartDifficulty();
    }

    public void SetStartDifficulty()
    {
        startDifficulty = difficulties[1];

        currentDifficulty = startDifficulty;

        SetDifficultyButton();
    }
    public void ChangeDifficulty()
    {
        int currentDifficultyIndex = difficulties.IndexOf(currentDifficulty);

        if (currentDifficultyIndex != difficulties.Count - 1)
        {
            currentDifficulty = difficulties[currentDifficultyIndex + 1];
        }
        else
        {
            currentDifficulty = difficulties[0];
        }

        SetDifficultyButton();
    }

    public void SetDifficultyButton()
    {
        difficultyButtonText.text = currentDifficulty.name;
    }

    public void SetButtonText(TMP_Text tmp_text)
    {
        difficultyButtonText = tmp_text;
    }
}

[System.Serializable]
public struct Difficulty
{
    public float difficulty;

    public string name;
}
