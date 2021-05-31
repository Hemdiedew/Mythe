using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdamageTEST : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SwordSlash")
        {
            Debug.Log("TakeDamage");
        }
    }
}
