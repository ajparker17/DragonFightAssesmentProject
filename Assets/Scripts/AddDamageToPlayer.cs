using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDamageToPlayer : MonoBehaviour
{
    public int damage = 50;
  
    void OnTriggerEnter(Collider other)
    {
        //need to add vfx
        if(other.gameObject.tag == "Player")
        { 
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
            //Destroy(gameObject, 1);
        }
    }
}
