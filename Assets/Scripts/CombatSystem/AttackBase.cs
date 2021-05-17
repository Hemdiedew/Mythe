using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    [SerializeField] protected RangeChecker _rangeChecker;
    protected Enemy _target;
    protected Enemy[] _targets;
    
    public float damage;
    public float attackSpeed;
    public float attackCooldown;
    private float _cooldownTime;
    public bool used;
    
    public abstract void Use();
    
    private void Update()
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
