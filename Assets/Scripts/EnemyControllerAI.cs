using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerAI : MonoBehaviour
{
    FlyMechanics flyMechanics;
    public GameObject player;

    public float lookRadius = 10;

    public Transform target;
    public Transform projectileSpawnPoint;
    GameObject eGameObject;
    NavMeshAgent agent;

    public GameObject projectile;
    public float projectileSpeed;
    public float nextFireTime;
    public float coolDownTime;

    Animator animator;
    // Start is called before the first frame update

    Vector3 targetPosition;

    void Awake()
    {
        flyMechanics = player.GetComponent<FlyMechanics>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        targetPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        if(distance <= lookRadius)
        {   
            if(flyMechanics.isFloating)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, 2f);
                animator.SetBool("AIflyMode", true);
            }
            else{
                transform.position = Vector3.Lerp(transform.position, targetPosition, 2f);
                animator.SetBool("AIflyMode", false);
            }

            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
			{	
				FaceTarget();	// Make sure to face towards the target
                if(Time.time > nextFireTime)
                {
                    Attack();
                    nextFireTime = Time.time + coolDownTime;
                }  
			}
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);

        //Debug.Log(flyMechanics.isFloating);
    }

    void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

    void Attack()
    {
        GameObject fireBall = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Rigidbody rb = fireBall.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projectileSpeed;
        rb.useGravity = false;
        Destroy(fireBall, 1);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color =Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
