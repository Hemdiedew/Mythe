using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class AttackBase : MonoBehaviour
{
    protected Enemy _target;
    protected Enemy[] _targets;
    
    public float damage;
    public float attackSpeed;
    public float attackCooldown;
    private float _cooldownTime;
    public bool used;
    
    public abstract void Use();

    protected virtual void OverrideUpdate()
    {
        
    }
    
    private void Update()
    {
        OverrideUpdate();
        
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
