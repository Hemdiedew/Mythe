using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
