using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public DataManager playerData;
    public Keybinds keybinds;

    private Animator anim;

    public bool isAttacking = false;
    void Start()
    { 
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (isAttacking && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.80)
        {
            isAttacking = false;
            anim.SetBool("isAttacking",false);
        } 
        else if (Input.GetKeyDown(keybinds.attack))
        {
            SetAttackingAnimation();
            isAttacking = true;
            anim.SetBool("isAttacking", true);
        }
    }

    private void SetAttackingAnimation()
    {
        if (anim != null)
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
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }
}
