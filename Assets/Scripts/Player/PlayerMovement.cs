using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerActionControls playerActionControls;

    private CharacterController controller;
    
    private Animator animator;

    [SerializeField]
    private PlayerAttack playerAttack;

    [SerializeField]
    private float speed = 6.5f;
    [SerializeField]
    private float walkSpeed = 3f;
    private float diagSpeed = 0.6f;
    [SerializeField]
    private float gravity = -17f;
    [SerializeField]
    private float jumpHeight = 1f;

    public Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;

    [SerializeField]
    private GameData gameData;
    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
    }
    void Start()
    {
        SetAnimator();
        SetPlayerAttack();
        SetCharacterController();
    }

    private void SetAnimator()
    {
        animator = GetComponentsInChildren<Animator>()[gameData.classId];
    }
    private void SetPlayerAttack()
    {
        Debug.Log(GetComponentsInChildren<PlayerAttack>().Length);
        playerAttack = GetComponentInChildren<PlayerAttack>();
    }

    private void SetCharacterController()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    private void Move()
    {
        bool forward = false;
        bool right = false;
        bool left = false;
        bool backward = false;
        bool walk = false;
        bool jump = false;
        animator.ResetTrigger("isJumping");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 temp = Vector3.zero;
        if (!playerAttack.isAttacking || !isGrounded)
        {
            Vector2 movementInput = playerActionControls.Player.Move.ReadValue<Vector2>();
            float jumpInput = playerActionControls.Player.Jump.ReadValue<float>();

            if (movementInput.x > 0)
            {
                right = true;
                temp += transform.right;
            }
            if (movementInput.x < 0)
            {
                left = true;
                temp += transform.right * -1;
            }
            if (movementInput.y > 0)
            {
                forward = true;
                temp += transform.forward;
            }
            if (movementInput.y < 0)
            {
                backward = true;
                temp += transform.forward * -1;
            }
            if (playerActionControls.Player.Walk.ReadValue<float>() > 0)
            {
                walk = true;
            }
            if (jumpInput > 0 && isGrounded)
            {
                jump = true;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            }
            SetAnimation(left, forward, right, backward, walk, jump);
        }
        MoveController(temp, left, forward, right, backward, walk);

    }

    void MoveController(Vector3 temp, bool left, bool forward, bool right, bool backward, bool walk)
    {
        if ((left && forward) || (left && backward) || (right && forward) || (right && backward))
        {
            if (walk || backward)
            {
                controller.Move(temp * diagSpeed * walkSpeed * Time.fixedDeltaTime);

            }
            else
            {
                controller.Move(temp * diagSpeed * speed * Time.fixedDeltaTime);
            }
        } 
        else
        {
            if (walk || backward)
            {
                controller.Move(temp * walkSpeed * Time.fixedDeltaTime);
            }
            else
            {
                controller.Move(temp * speed * Time.fixedDeltaTime);
            }
        }
        velocity.y += gravity * Time.fixedDeltaTime;
        controller.Move(velocity * Time.fixedDeltaTime);
    }

    void resetAnimation()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("goBackward", false);
        animator.SetInteger("Strafe", 0);
    }

    void SetAnimation(bool left, bool forward, bool right, bool backward, bool walk, bool jump)
    {
        if (jump)
        {
            animator.SetTrigger("isJumping");

        }
        else if((left || right) && !forward && !backward) //Only left or right
        {
            if (left)
            {
                if (walk)
                {
                    SetWalkAnimation(-1);
                } 
                else
                {
                    SetMoveAnimation(-1);
                }
            } 
            else
            {
                if (walk)
                {
                    SetWalkAnimation(1);
                }
                else
                {
                    SetMoveAnimation(1);
                }
            }
        } 
        else if(forward && !backward)
        {
            if (right && !left)
            {
                if (walk)
                {
                    SetWalkAnimation(1);
                }
                else
                {
                    SetMoveAnimation(0);
                }
            }
            else if(left && !right)
            {
                if (walk)
                {
                    SetWalkAnimation(-1);
                }
                else
                {
                    SetMoveAnimation(0);
                }
            } 
            else
            {
                if (walk)
                {
                    SetWalkAnimation(0);
                }
                else
                {
                    SetMoveAnimation(0);
                }
            }
        } 
        else if (backward && !forward)
        {
            SetBackwardAnimation(walk);
        }

        if (!forward && !backward && !left && !right)
        {
            resetAnimation();
        }
    }

    void SetBackwardAnimation(bool walk)
    {
        if (animator != null)
        {
            animator.SetBool("goBackward", true);
            if (walk)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isRunning", true);
            }
        }
        else
        {
            Debug.LogError("No animation loaded");
        }
    }

    //Strafe -1 = left   |   strafe 1 = right
    void SetWalkAnimation(int strafe)
    {
        if (animator != null) { 
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("goBackward", false);
            animator.SetInteger("Strafe", strafe);
        }
        else
        {
            Debug.LogError("No animation loaded");
        }
    }

    void SetMoveAnimation(int strafe)
    {
        if (animator != null)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("goBackward", false);
            animator.SetInteger("Strafe", strafe);
        }
        else
        {
            Debug.LogError("No animation loaded");
        }
    }
}
