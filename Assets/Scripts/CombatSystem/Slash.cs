using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Slash : AttackBase
{
    public Slash(EnemyInRangeChecker checker)
    {
        _rangeChecker = checker;
    }

    public override void Use()
    {
        //making sure there are enemies to hit.
        List<GameObject> enemies = _rangeChecker.GetAllEniemiesObjectsInRange()?.ToList();
        if (enemies == null || enemies?.Count < 0) return;
        Debug.Log(enemies);
        Debug.Log(enemies.Count);
        
        foreach (GameObject enemy in enemies)
        {
            //wat willen we doen met de enemy gameobject.
            enemy.GetComponent<Health>().RemoveHealth(damage);
        }
    }
}
