using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        SetMaxHealth(_health.maxHealth);
        // _health.RemoveHealthEvent.AddListener(SetMaxHealth(_health.health));
        _health.RemoveHealthEvent.AddListener((int value)=>
        {
            //we dont want to get value what equals damage value. but we want the new health.
            SetHealth(_health.health);
        });
    }

    private void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public  void SetHealth(int health)
    {
        slider.value = health;
    }
}
