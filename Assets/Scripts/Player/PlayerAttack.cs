using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public DataManager playerData;
    public ConfigManager configData;
    public ParameterData parameterData;

    private Animator anim;

    public bool isAttacking = false;
    void Start()
    { 
        anim = GetComponent<Animator>();
        parameterData = configData.data;
    }

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (isAttacking)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.80)
                isAttacking = false;
        } else if (Input.GetKeyDown(parameterData.attack))
        {
            SetAttackingAnimation();
            isAttacking = true;
            /*RaycastHit2D hit = Physics2D.Raycast(attackStart.position, (attackEnd.position - attackStart.position).normalized) ;
            Debug.DrawRay(attackStart.position, (attackEnd.position - attackStart.position).normalized, Color.yellow,50);
            if (hit == true && hit.distance < 1 && hit.transform.gameObject.tag=="Enemy")
            {

                Health enemy = hit.collider.GetComponent<Health>();
                if (enemy != null) 
                {
                    enemy.currentHealth -= 10f; //change damage taken
                }
            }*/
        }
    }

    private void SetAttackingAnimation()
    {
        if (anim != null)
        {
            anim.SetTrigger("isAttacking");
        }
        else
        {
            Debug.LogError("No animation loaded");
        }
    }

}
