using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveToPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private NavMeshAgent agent;
    [SerializeField]
    private float maxDistance = 5f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(player.position);
        agent.stoppingDistance = 2.5f;
        agent.autoBraking = true;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        transform.LookAt(player.position);
        CheckDistance();
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= maxDistance)
        {
            agent.enabled = true;
            agent.SetDestination(player.position);
        }

        else
        {
            this.agent.enabled = false;
        }
    }
}
