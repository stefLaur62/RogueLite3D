using System;
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
    void Start()
    {
        SetAnimator();
    }

    void Update()
    {
        Attack();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
        Debug.Log("Boom");
        mageAttackDone = true;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position + Vector3.up, transform.forward * hit.distance, Color.red, 10);

            //Spawn effect
            Instantiate(mageAttackImpactPrefab, hit.point, Quaternion.identity);
            
            if (hit.collider.gameObject.tag == "Enemy")
            {
                //Damage enemy
                Debug.Log("TT");
                EnemyIsHit enemyScript = hit.collider.gameObject.GetComponent<EnemyIsHit>();
                enemyScript.loseLife();
            }
        }
    }
}