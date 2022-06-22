using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovements : MonoBehaviour
{
    private CharacterController controller;
    Rigidbody rigidBody;

    Animator animator;
    Vector2 input;


    bool isTroting = false;
    bool ascend;
    bool inAir;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controller.isGrounded);

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isTroting = true;
        }
        else
        {
            isTroting = false;
        }

        //Debug.Log(isTroting);
        animator.SetBool("isTroting", isTroting);

        //Levitate to air
         if(Input.GetKey(KeyCode.Q))
        {   
            Debug.Log("Flying");
            animator.SetBool("toAir", true);
            rigidBody.isKinematic = true;
        }

         if(Input.GetKey(KeyCode.E))
        {
            Debug.Log("Fallin");
            animator.SetBool("toAir", false);
            rigidBody.isKinematic = false;
        }

        animator.SetBool("inAir",rigidBody.isKinematic);
        
    }


    
}
