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
       
    }

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
            agent.enabled = false;
        }
    }
}
