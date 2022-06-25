using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject projectile;
    public Transform transform;
    public float projectileSpeed;
    
    // Update is called once per frame
    void Update()
    {

         if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Mouse button clicked");
            ShootFireBall();
        }
        if(Input.GetButtonDown("Fire2"))
        {
            ShootFireBallDown();
        }
    }

    void ShootFireBall()
    {
        GameObject fireBall = Instantiate(projectile, transform.position, transform.rotation);
        Rigidbody rb = fireBall.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projectileSpeed;
        rb.useGravity = false;
        Destroy(fireBall, 1);
    }

    void ShootFireBallDown()
    {
        GameObject fireBall = Instantiate(projectile, transform.position, transform.rotation);
        // Rigidbody rb = fireBall.GetComponent<Rigidbody>();
        // rb.velocity = transform.forward * projectileSpeed;
        // rb.useGravity = true;
    }

}
