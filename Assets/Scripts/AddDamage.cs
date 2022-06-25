using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDamage : MonoBehaviour
{
    public int damage = 50;
  
    void OnTriggerEnter(Collider other)
    {
        //need to add vfx
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Enemy")
        { 
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            //Destroy(gameObject, 1);
        }
    }
}
