using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class AttackBase : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public float attackSpeed;
    public float attackCooldown;
    private float _cooldownTime;
    public bool used;

    public int attackButtonClickCount = 0;
    
    public abstract void Use();

    public void Update()
    {
        if (!used) return;
        
        _cooldownTime += Time.deltaTime;
        
        if (_cooldownTime > attackCooldown)
        {
            //can use attack again
            _cooldownTime = 0;
            used = false;
        }
    }
    
    
}
