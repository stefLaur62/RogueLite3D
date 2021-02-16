using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private Transform attackCenter;

    [SerializeField]
    private int damage;

    private PlayerAttack playerAttack;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    void Update()
    {
        CheckDistance();
        IsAttacking();
    }
    private void CheckDistance()
    {
        float distance = Vector3.Distance(playerPosition.position, transform.position);
        if (distance <= attackDistance)
        {
            Attack();
        }
    }

    private void IsAttacking()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            agent.enabled = false;
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void DamagePlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(attackCenter.position, 0.4f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Player")
            {
                playerAttack.LoseLife(damage);
            }
        }
    }
}
