using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngineInternal;

public class Throw : AttackBase
{
    [SerializeField] private GameObject throwObject;
    [SerializeField] private GameObject target; //target is where we are throwing it.. so its easier to aim
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layer;

    protected override void OverrideUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.white,0, true);
    }
    public override void Use()
    {
        //what has to happen.
        // public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, maxDistance, layer, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            //when there is a enemy in the direct direction we are aiming
            float distanceToObstacle = hit.distance;
            target = hit.collider.gameObject;
            return;
        }
        
        if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, maxDistance))
        {
            //just to make aiming a lot easier if the aim is a little of we check if we hit element a little bit from the raycast
            float distanceToObstacle = hit.distance;
            target = hit.collider.gameObject;
            return;
        }
    }
}
