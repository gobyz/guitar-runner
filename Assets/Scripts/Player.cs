using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public bool isImmuneToDamage;

    public static Player instance;

    public float maxHealth;

    public float health;

    public float score;

    public TMP_Text healthText;

    public TMP_Text scoreText;

    public UnityEvent playerDied = new UnityEvent();

    public UnityEvent playerDamaged = new UnityEvent();

    private void Start()
    {
        instance = this;

        health = maxHealth;

        score = 0;

        SetHealthUI();

        SetScoreUI();
    }

    public void Damage(float damage)
    {
        if (!isImmuneToDamage)
        {
            health -= damage;

            SetHealthUI();

            playerDamaged.Invoke();

            IsPlayerDead();
        }
    }

    public bool IsPlayerDead()
    {
        if(health <= 0)
        {
            playerDied.Invoke();

            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddToScore(float toAdd)
    {
        score += toAdd;

        SetScoreUI();
    }

    public void Heal(float value) 
    { 
        health += value;

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        SetHealthUI();
    }

    public void SetHealthUI()
    {
        healthText.text = health.ToString();
    }

    public void SetScoreUI()
    {
        scoreText.text = score.ToString();
    }

}
