using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        Sprint();

    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }

    public void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("sprint", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("sprint", false);
        }
    }
}
