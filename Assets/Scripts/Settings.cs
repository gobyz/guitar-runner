using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static bool isMuted;

    public GameObject soundOn;

    public GameObject soundOff;

    public List<AudioSource> audioSources = new List<AudioSource>();

    private void Start()
    {
        if (PlayerPrefs.HasKey("isMuted"))
        {
            int value = PlayerPrefs.GetInt("isMuted");

            if (value == 0) 
            { 
                Unmute();
            }
            else
            {
                Mute();
            }
        }
        else
        {
            Unmute();
        }
    }
    public void Mute()
    {
        foreach (AudioSource source in audioSources)
        {
            source.mute = true;
        }

        soundOn.SetActive(false);

        soundOff.SetActive(true);

        isMuted = true;

        PlayerPrefs.SetInt("isMuted", 1);
    }

    public void Unmute()
    {
        foreach (AudioSource source in audioSources)
        {
            source.mute = false;
        }

        soundOn.SetActive(true);

        soundOff.SetActive(false);

        isMuted = false;

        PlayerPrefs.SetInt("isMuted", 0);
    }

    public void Click()
    {
        if (isMuted)
        {
            Unmute();
        }
        else
        {
            Mute();
        }
    }
}
