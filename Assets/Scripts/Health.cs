using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class MyUnityFloatEvent : UnityEvent <int> {}

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int startHealth;

    public UnityEvent<int> RemoveHealthEvent;
    public UnityEvent<int> AddHealthEvent;

    public UnityEvent dieEvent;
    private void Awake()
    {
        health = startHealth;
        if (maxHealth < startHealth) maxHealth = startHealth;

        if (RemoveHealthEvent == null) RemoveHealthEvent = new MyUnityFloatEvent();
        if (AddHealthEvent == null) AddHealthEvent = new MyUnityFloatEvent();
    }

    public void RemoveHealth(int value)
    {
        value = (int) value;
        RemoveHealthEvent?.Invoke(value);

        int newHealth = health - value;
        if (newHealth <= 0) newHealth = 0;
        health = newHealth;
        
        if(health <= 0) { dieEvent.Invoke(); }

        Debug.Log("new hp: " + health);
    }

    public void AddHealth(int value)
    {
        value = (int) value;
        AddHealthEvent.Invoke(value);
        
        int newHealth = health + value;
        if (newHealth >= maxHealth) newHealth = maxHealth;
        health = newHealth;
    }

    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
}
