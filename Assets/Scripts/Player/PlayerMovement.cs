using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private ParameterData data;
    public ConfigManager config;


    private Animator anim;

    private float speed = 7f;
    private float walkSpeed = 3f;
    private float diagSpeed = 0.6f;
    public float gravity = -5;

    public Vector3 velocity;
    void Start()
    {
        anim = GetComponent<Animator>();
        data = config.getData();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        bool forward = false;
        bool right = false;
        bool left = false;
        bool backward = false;
        bool walk = false;

        Vector3 temp = Vector3.zero;
        if (Input.GetKey(data.right))
        {
            right = true;
            temp += transform.right;
        }
        if (Input.GetKey(data.left))
        {
            left = true;
            temp += transform.right * -1;
        }
        if (Input.GetKey(data.forward))
        {
            forward = true;
            temp += transform.forward;
        }
        if (Input.GetKey(data.backward))
        {
            backward = true;
            temp += transform.forward * -1;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            walk = true;
        }


        SetAnimation(left, forward, right, backward, walk);

        MoveController(temp, left, forward, right, backward, walk);
        //Diagonal move

        /*if (controller.isGrounded)
        {
            velocityY = 0;
        }*/

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
        anim.SetBool("isRunning", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("goBackward", false);
        anim.SetInteger("Strafe", 0);
    }

    void SetAnimation(bool left, bool forward, bool right, bool backward, bool walk)
    {
        if((left || right) && !forward && !backward) //Only left or right
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
        if (anim != null)
        {
            anim.SetBool("goBackward", true);
            if (walk)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isRunning", true);
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
        if (anim != null) { 
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("goBackward", false);
            anim.SetInteger("Strafe", strafe);
        }
        else
        {
            Debug.LogError("No animation loaded");
        }
    }

    void SetMoveAnimation(int strafe)
    {
        if (anim != null)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("goBackward", false);
            anim.SetInteger("Strafe", strafe);
        }
        else
        {
            Debug.LogError("No animation loaded");
        }
    }

    private void ChangeInput()
    {
        throw new NotImplementedException();
    }

}
