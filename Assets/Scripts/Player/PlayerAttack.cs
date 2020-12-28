using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerActionControls playerActionControls;


    private GameData playerData;

    private Animator anim;

    public bool isAttacking = false;

    void Start()
    { 
        anim = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        Attack();
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
  
        if (isAttacking && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.80)
        {
            isAttacking = false;
            anim.SetBool("isAttacking", false);
        }
        else if (attackInput > 0)
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
