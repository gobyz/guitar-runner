using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public int loadBeats;

    public int beatsActive;

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

        AudioController.beat.AddListener(CheckActive);
    }
    private bool shouldCheckLoading;

    private bool shouldCheckActive;
    public void CheckLoading()
    {
        if (shouldCheckLoading)
        {
            beatsLeftLoad--;

            abilityButton.Set(GetFillRatioLoad(), true);

            if(beatsLeftLoad== 0)
            {
                isAbilityLoaded = true;
            }
        }
    }
    public void CheckActive()
    {
        if (shouldCheckActive)
        {
            beatsLeftActive--;

            abilityButton.Set(1 - GetFillRatioActive(), false);

            if (beatsLeftActive == 0)
            {
                abilityActivated = false;

                shouldCheckActive = false;

                DeactivateAbility();

                Load();
            }
        }
    }
    public void Update()
    {
        if (!abilityActivated)
        {
            if(Input.GetKeyDown(keycode) && isAbilityLoaded)
            {
                abilityActivated = true;

                isAbilityLoaded = false;

                ActivateAbility();

                shouldCheckLoading = false;

                beatsLeftActive = beatsActive;

                shouldCheckActive = true;
            }
        }
    }
    public void Load()
    {
        beatsLeftLoad = loadBeats;

        shouldCheckLoading = true;
    }
    private int beatsLeftLoad;

    private int beatsLeftActive;

    public float GetFillRatioLoad()
    {
        return (float)beatsLeftLoad / (float)loadBeats;
    }

    public float GetFillRatioActive()
    {
        return (float)beatsLeftActive / (float)beatsActive;
    }
}
