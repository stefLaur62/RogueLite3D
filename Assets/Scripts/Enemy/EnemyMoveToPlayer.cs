using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveToPlayer : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.position);
        agent.stoppingDistance = 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(goal.position);
    }
}
