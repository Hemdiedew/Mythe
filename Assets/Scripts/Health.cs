using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float startHealth;

    public UnityEvent removeHealthEvent;
    public UnityEvent dieEvent;
    public UnityEvent addHealthEvent;
    private void Start()
    {
        health = startHealth;
        if (maxHealth < startHealth) maxHealth = startHealth;
    }

    public void RemoveHealth(float value)
    {
        removeHealthEvent.Invoke();
        
        float newHealth = health - value;
        if (newHealth <= 0) newHealth = 0;
        health = newHealth;
        
        if(health <= 0) { dieEvent.Invoke(); }
    }

    public void AddHealth(float value)
    {
        addHealthEvent.Invoke();
        
        float newHealth = health + value;
        if (newHealth >= maxHealth) newHealth = maxHealth;
        health = newHealth;
    }
}
