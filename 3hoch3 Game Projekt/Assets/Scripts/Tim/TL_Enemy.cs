using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class TL_Enemy : LivingCreature
{
    NavMeshAgent pathfinder;
    Transform target;

    bool start = false;

    public override void Start()
    {
        base.Start();

        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NavMeshAgent>().enabled == true && start == false)
        {
            StartCoroutine(UpdatePath());
            start = true;
        }
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
