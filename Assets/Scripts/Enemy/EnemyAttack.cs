using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float attackDistance;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }
    private void CheckDistance()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= attackDistance)
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
