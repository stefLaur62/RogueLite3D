using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInRange : MonoBehaviour
{
    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private float playerDistanceTrigger;

    private NavMeshAgent navMeshAgent;
    private WakeUp wakeUpScript;
    private Animator animator;
    private bool canNowMove = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        wakeUpScript = GetComponent<WakeUp>(); 
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        CheckDistance();
        transform.LookAt(playerPosition.position);
    }
    private void CheckDistance()
    {
        float distance = Vector3.Distance(playerPosition.position, transform.position);
        if (distance <= playerDistanceTrigger)
        {
            animator.SetTrigger("PlayerInRange");
            wakeUpScript.enabled = true;
            canNowMove = true;
        }
        if (canNowMove)
        {
            if(navMeshAgent.enabled)
                navMeshAgent.SetDestination(playerPosition.position);
        }
    }
}
