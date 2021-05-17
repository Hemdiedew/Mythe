using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDisplayer : MonoBehaviour
{
    private Health _health;
    private void Start()
    {
        //if there is a health script on this gameobject we acces it.
        _health = gameObject.GetComponent<Health>();
        print(_health);
        if(_health != null) _health.removeHealthEvent?.AddListener(TakeDamage);
        if(_health != null) _health.dieEvent?.AddListener(Die);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    private void TakeDamage(float amount)
    {
        //display logic
        Debug.Log("DISPLAYING");
    }
}
