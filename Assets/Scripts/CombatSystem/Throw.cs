using System;
using System.Collections;
using System.Collections.Generic;
using TweenMachine;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngineInternal;

public class Throw : AttackBase
{
    [SerializeField] private GameObject throwObject;
    [SerializeField] private GameObject throwFromLocation;
    [SerializeField] private GameObject target; //target is where we are throwing it.. so its easier to aim
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layer;

    protected override void OverrideUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.white,0, true);
    }

    private void Start()
    {
        if (throwFromLocation == null) throwFromLocation = this.transform.gameObject;
    }

    public override void Use()
    {
        //what has to happen.
        // public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, maxDistance, layer, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);
        RaycastHit hit;
        if (Physics.Raycast(throwFromLocation.transform.position, throwFromLocation.transform.forward, out hit, maxDistance, layer))
        {
            //when there is a enemy in the direct direction we are aiming
            float distanceToObstacle = hit.distance;
            target = hit.collider.gameObject;
            Hit();
            return;
        }
        
        if (Physics.SphereCast(throwFromLocation.transform.position, radius, throwFromLocation.transform.forward, out hit, maxDistance, layer))
        {
            //just to make aiming a lot easier if the aim is a little of we check if we hit element a little bit from the raycast
            float distanceToObstacle = hit.distance;
            target = hit.collider.gameObject;
            Hit();
            return;
        }
    }

    private void Hit()
    {
        if (throwObject == null) return;
        //create object an set position
        GameObject obj = Instantiate(throwObject);
        obj.transform.position = this.transform.position;
        
        //create a tween between current location an target. (easy way to move object to destination)
        TweenBuild tweenBuild = new TweenBuild(obj);
        Tween tweenPosition = tweenBuild.SetTweenPosition(target.transform.position, .4f, EasingType.Linear);
        //make sure to remove health from enemy when the easing is done an we hit. 
        //making sure the enemy get damaged when we hit instead of before hit 
        tweenBuild.OnTweenBuildFinish += () => { if (target != null) target.GetComponent<Health>()?.RemoveHealth(damage); }; 
        tweenBuild.DestroyOnFinish = true;
        tweenBuild.StartTween();
        
    }
}
