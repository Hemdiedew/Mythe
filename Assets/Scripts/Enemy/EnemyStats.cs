using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    int maxHealth;
    int currentHealth;
    int damage;

    public Healthbar healthbar;

    public bool EnemyType1;
    //public bool EnemyType2;
    //public bool EnemyType3;

    private void Start()
    {
        if(EnemyType1 == true)
        {
            maxHealth = 10;
            damage = 5;
        }

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hurt(5);
            Debug.Log("attack");
        }
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }



    void Attack()
    {
        //Deals Damage to player based on "damage"
    }

    void Hurt(int playerDamage)
    {
        //Lowers hp by Player Attacks damage
        //Play Hurt Animation
        currentHealth -= playerDamage;

        healthbar.SetHealth(currentHealth);
    }

    void Die()
    {
        //Play Death Animation
        Destroy(gameObject);
    }

}
