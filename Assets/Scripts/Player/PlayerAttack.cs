﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerActionControls playerActionControls;
    [SerializeField]
    private GameData gameData;
    private Animator animator;

    public bool isAttacking = false;
    private bool mageAttackDone = false;
    [SerializeField]
    private GameObject mageAttackImpactPrefab;

    private int currentDamage;
    [SerializeField]
    private StaticInterface playerEquipment;
    private int itemAttackBonus = 0;

    void Start()
    {
        SetAnimator();
        currentDamage = GetDamage();
    }

    public int GetDamage()
    {
        if (playerEquipment != null)
        {
            if (playerEquipment.inventory.container.items[1].item.id != -1)
            {
                return playerEquipment.inventory.container.items[1].item.buffs[0].value * (gameData.attack + itemAttackBonus);
            }
            else
            {
                return 5 * (gameData.attack + itemAttackBonus);
            }
        } else
        {
            return 5;
        }
    }

    public void SetAttackBonus()
    {
        int attackBonus = 0;
        for (int i = 0; i < playerEquipment.inventory.container.items.Length; i++)
        {
            if (playerEquipment.inventory.container.items[i].item.id != -1)
            {
                foreach (ItemBuff buff in playerEquipment.inventory.container.items[i].item.buffs)
                {
                    if (buff.attributes == Attributes.Attack)
                    {
                        attackBonus += buff.value;
                    }
                }
            }
        }
        Debug.Log("Attack bonus:" + attackBonus);
        itemAttackBonus = attackBonus;
    }

    void Update()
    {
        Attack();
    }

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        playerActionControls = new PlayerActionControls();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    public void Attack()
    {
        float attackInput = playerActionControls.Player.Attack.ReadValue<float>();
        if (animator == null)
        {
            return;
        }
        if (isAttacking)
        {
            if(gameData.classId == 1 && !mageAttackDone && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.40 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.42)
            {
                MageAttack();
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.80)
            {
                isAttacking = false;
                animator.SetBool("isAttacking", false);
                mageAttackDone = false;
            }
        }
        else if (attackInput > 0)
        {
            SetAttackingAnimation();
            isAttacking = true;
            animator.SetBool("isAttacking", true);
        }
        
    }

    private void SetAttackingAnimation()
    {
        if (animator != null)
        {
            //anim.SetTrigger("isAttacking");
        }
        else
        {
            Debug.LogError("No animation loaded");
        }
    }
   
    public void OnSwordHit(Collider other)
    {
        animator.SetBool("isAttacking", false);
        isAttacking = false;
    }

    private void SetAnimator()
    {
        animator = GetComponentsInChildren<Animator>()[gameData.classId];
    }
    private void MageAttack()
    {
        mageAttackDone = true;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, Mathf.Infinity))
        {

            //Spawn effect
            Instantiate(mageAttackImpactPrefab, hit.point, Quaternion.identity);
            
            if (hit.collider.gameObject.tag == "Enemy")
            {
                EnemyIsHit enemyScript = hit.collider.gameObject.GetComponent<EnemyIsHit>();
                enemyScript.loseLife();
            }
        }
    }
}