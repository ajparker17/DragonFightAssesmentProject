using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovements : MonoBehaviour
{

    Rigidbody rigidbody;
    Animator animator;
    Vector2 input;

    bool isTroting = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
        animator.SetBool("isTroting", isTroting);


    }
}
