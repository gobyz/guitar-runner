using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public int loadBeats;

    public bool isAbilityLoaded;

    public float duration;

    public KeyCode keycode;

    public bool abilityActivated;

    public AbilityButton abilityButton;
    public abstract void ActivateAbility();
    public abstract void DeactivateAbility();
    private void Start()
    {
        Load();

        AudioController.beat.AddListener(CheckLoading);
    }
    private bool shouldCheckLoading;
    public void CheckLoading()
    {
        if (shouldCheckLoading)
        {
            beatsLeft--;

            abilityButton.Set(GetFillRatio());

            if(beatsLeft== 0)
            {
                isAbilityLoaded = true;
            }
        }
    }

    public void Update()
    {
        if (!abilityActivated)
        {
            if(Input.GetKeyDown(keycode))
            {
                abilityActivated = true;

                isAbilityLoaded = false;

                ActivateAbility();

                abilityButton.Set(1);

                StartCoroutine(AbilityTimer());
            }
        }
    }
    public IEnumerator AbilityTimer()
    {
        shouldCheckLoading = false;

        yield return new WaitForSeconds(duration);

        abilityActivated = false;

        DeactivateAbility();

        Load();
    }
    public void Load()
    {
        beatsLeft = loadBeats;

        shouldCheckLoading = true;
    }
    private int beatsLeft;

    public float GetFillRatio()
    {
        return (float)beatsLeft / (float)loadBeats;
    }
}
