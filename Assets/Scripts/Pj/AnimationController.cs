using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class AnimationController : MonoBehaviour
{

    [SerializeField] Animator animator;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        float dirX = 0;
        float dirY = 0;
        bool isWalking = false;

        /* if (Input.GetKey(KeyCode.W))
         {
             animator.SetFloat("DirX", 0);
             animator.SetFloat("DirY", 1);
             animator.SetBool("Walk", true);
         }
         else
         {
             animator.SetBool("Walk", false);
         }
         if (Input.GetKey(KeyCode.S))
         {
             animator.SetFloat("DirX", 0);
             animator.SetFloat("DirY", -1);
             animator.SetBool("Walk", true);
         }
         else
         {
             animator.SetBool("Walk", false);
         }
         if (Input.GetKey(KeyCode.A))
         {
             animator.SetFloat("DirX", -1);
             animator.SetFloat("DirY", 0);
             animator.SetBool("Walk", true);
         }
         else
         {
             animator.SetBool("Walk", false);
         }
         if (Input.GetKey(KeyCode.D))
         {
             animator.SetFloat("DirX", 1);
             animator.SetFloat("DirY", 0);
             animator.SetBool("Walk", true);
         }
         else
         {
             animator.SetBool("Walk", false);
         }*/

        if (Input.GetKey(KeyCode.W))
        {
            dirY = 1;
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dirY = -1;
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dirX = -1;
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dirX = 1;
            isWalking = true;
        }
        animator.SetFloat("DirX", dirX);
        animator.SetFloat("DirY", dirY);
        animator.SetBool("Walk", isWalking);

    }
}
