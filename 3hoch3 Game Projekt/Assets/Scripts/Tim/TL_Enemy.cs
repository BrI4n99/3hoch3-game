﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class TL_Enemy : LivingCreature
{
    NavMeshAgent pathfinder;
    Transform target;

    public override void Start()
    {
        base.Start();

        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.y);
            pathfinder.SetDestination(target.position);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}