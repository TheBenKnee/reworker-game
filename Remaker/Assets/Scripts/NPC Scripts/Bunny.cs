﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    // private Rigidbody2D myRigidbody;
    // public Transform target;
    // public float runRadius;
    // private Animator anim;


    // // Start is called before the first frame update
    // void Start()
    // {
    //     currentState = PassiveState.idle;
    //     myRigidbody = GetComponent<Rigidbody2D>();
    //     anim = GetComponent<Animator>();
    //     target = GameObject.FindWithTag("Player").transform;
    // }

    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //     CheckDistance();
    // }

    // void CheckDistance()
    // {
    //     if (Vector3.Distance(target.position, transform.position) <= runRadius)
    //     {
    //         if (currentState == PassiveState.idle || currentState == PassiveState.walk && currentState != PassiveState.stagger)
    //         {
    //             {
    //                 Vector3 temp = Vector3.MoveTowards(transform.position, target.position, (-moveSpeed) * Time.deltaTime);
    //                 ChangeAnim(temp - transform.position);
    //                 myRigidbody.MovePosition(temp);
    //                 ChangeState(PassiveState.walk);
    //             }
    //         }
    //     }
    //     else
    //     {
    //         ChangeState(PassiveState.idle);
    //         anim.SetBool("moving", false);
    //     }
    // }

    // private void SetAnimFloat(Vector2 setVector)
    // {
    //     anim.SetFloat("moveX", setVector.x);
    //     anim.SetFloat("moveY", setVector.y);
    //     anim.SetBool("moving", true);
    // }

    // private void ChangeAnim(Vector2 direction)
    // {
    //     if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
    //     {
    //         if (direction.x > 0)
    //         {
    //             SetAnimFloat(Vector2.right);
    //         }
    //         else if (direction.x < 0)
    //         {
    //             SetAnimFloat(Vector2.left);
    //         }
    //     }
    //     else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
    //     {
    //         if (direction.y > 0)
    //         {
    //             SetAnimFloat(Vector2.up);
    //         }
    //         else if (direction.y < 0)
    //         {
    //             SetAnimFloat(Vector2.down);
    //         }
    //     }
    // }

    // private void ChangeState(PassiveState newState)
    // {
    //     if (currentState != newState)
    //     {
    //         currentState = newState;
    //     }
    // }
}
