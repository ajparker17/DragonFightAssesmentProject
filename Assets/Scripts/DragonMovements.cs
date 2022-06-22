using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovements : MonoBehaviour
{
    Animator animator;
    Vector2 input;

    bool isTroting = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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

        //Debug.Log(isTroting);
        animator.SetBool("isTroting", isTroting);
    }
}
