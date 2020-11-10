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
    public float gravity = -5;

    public Vector3 velocity;
    void Start()
    {
        anim = GetComponent<Animator>();
        data = config.getData();
        Debug.Log(data);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        bool isWalking = false;

        Vector3 temp = Vector3.zero;
        if (Input.GetKey(data.right))
        {
            isWalking = true;
            SetWalkingAnimation(true);
            temp += transform.right;
        }
        if (Input.GetKey(data.left))
        {
            isWalking = true;
            SetWalkingAnimation(true);
            temp += transform.right * -1;
        }
        if (Input.GetKey(data.forward))
        {
            isWalking = true;
            SetWalkingAnimation(true);
            temp += transform.forward;
        }
        if (Input.GetKey(data.backward))
        {
            isWalking = true;
            SetWalkingAnimation(true);
            temp += transform.forward * -1;
        }
        if (!isWalking)
        {
            SetWalkingAnimation(false);
        }
        if (Input.GetKey(data.attack))
        {
            Debug.Log("Attack");
            anim.SetTrigger("Attack");
        }
        controller.Move(temp * speed * Time.fixedDeltaTime);
        velocity.y += gravity * Time.fixedDeltaTime;

        controller.Move(velocity * Time.fixedDeltaTime);

        /*if (controller.isGrounded)
        {
            velocityY = 0;
        }*/

    }
    void SetWalkingAnimation(bool isWalking)
    {
        if (anim != null)
        {
            if (isWalking)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
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
