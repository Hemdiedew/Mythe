using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    float attackRadius = 2.5f;
    float attackCooldown = 0f;
    public float attackSpeed = 1f;

    public GameObject swordSlash;

    Transform target;
    NavMeshAgent agent;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        swordSlash.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        attackCooldown -= Time.deltaTime;

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            
            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
        if (distance <= attackRadius)
        {
            if (attackCooldown <= 0)
            {
                StartCoroutine("Slash");
                attackCooldown = 1f / attackSpeed;
            }
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
    
    IEnumerator Slash()
    {
        swordSlash.SetActive(true);
        yield return new WaitForSeconds(0.5f); 
        swordSlash.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }
}
