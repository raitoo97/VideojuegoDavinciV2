using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    public float moveSpeed =1f;

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;

    void Update()
    {
        /*movement.x = Input.GetAxisRaw("DirX");
        movement.y = Input.GetAxisRaw("DirY");

        animator.SetFloat("DirX", movement.x);
        animator.SetFloat("DirY", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);*/
    }

    void FixedUpdate()
    {
       // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
