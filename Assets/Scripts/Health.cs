using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class MyUnityFloatEvent : UnityEvent <float> {}

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float startHealth;

    public MyUnityFloatEvent removeHealthEvent;
    public MyUnityFloatEvent addHealthEvent;

    public UnityEvent dieEvent;
    private void Start()
    {
        health = startHealth;
        if (maxHealth < startHealth) maxHealth = startHealth;

        if (removeHealthEvent == null) removeHealthEvent = new MyUnityFloatEvent();
        if (addHealthEvent == null) addHealthEvent = new MyUnityFloatEvent();
    }

    public void RemoveHealth(float value)
    {
        removeHealthEvent?.Invoke(value);
        
        float newHealth = health - value;
        if (newHealth <= 0) newHealth = 0;
        health = newHealth;
        
        if(health <= 0) { dieEvent.Invoke(); }
    }

    public void AddHealth(float value)
    {
        addHealthEvent.Invoke(value);
        
        float newHealth = health + value;
        if (newHealth >= maxHealth) newHealth = maxHealth;
        health = newHealth;
    }
}
