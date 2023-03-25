using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public bool isImmuneToDamage;

    public static Player instance;

    public float maxHealth;

    public float health;

    public float score;

    public UnityEvent playerDied = new UnityEvent();

    public UnityEvent playerDamaged = new UnityEvent();

    private void Start()
    {
        instance = this;

        health = maxHealth;

        score = 0;
    }

    public void Damage(float damage)
    {
        if (!isImmuneToDamage)
        {
            health -= damage;

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
    }

    public void Heal(float value) 
    { 
        health += value;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

}
