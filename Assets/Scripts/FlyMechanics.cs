using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMechanics : MonoBehaviour
{
    Animator animator;
  
    Rigidbody rigidbody;

    Vector2 input;

    public float thrust = 1;
    public float flySpeed = 1;
   // public float thrustSpeed = 1;
    public bool isOnGround;
    public bool isFloating;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFloating)
        {
            animator.SetBool("FlyMode", true);
            //MoveInAir();
        }

       if(Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("FlyMode", false);
            isFloating = false;
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {   if(!isFloating)
        {
            isFloating = true;
            rigidbody.AddForce(Vector3.up * thrust);
            isOnGround = false;
        }
        }
        if(transform.position.y >= 0.9 && isFloating)
        {
            rigidbody.isKinematic = true;
        }else
        {
            rigidbody.isKinematic = false;
        }
        
    }

}
