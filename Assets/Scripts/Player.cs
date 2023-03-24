using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public bool isImmuneToDamage;

    public static Player instance;

    [SerializeField]
    public float health;

    public UnityEvent playerDied = new UnityEvent();

    private void Start()
    {
        instance = this;
    }

    public void Damage(float damage)
    {
        if (!isImmuneToDamage)
        {
            health -= damage;

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
}
