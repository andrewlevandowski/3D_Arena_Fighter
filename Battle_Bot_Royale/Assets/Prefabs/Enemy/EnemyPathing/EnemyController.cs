using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//enemy pathfinding from Brackeys https://youtu.be/xppompv1DBg
public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;

    public bool justAttacked = false;

    Transform target;
    NavMeshAgent agent;
    Animator anim;

    
    int attackHash = Animator.StringToHash("Attack1");
    int walkHash = Animator.StringToHash("StartWalk");

    // Use this for initialization
    void Start () {
        target = PlayerFinder.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= 2.8f)
            {
                FaceTarget();
                Attack();
            } else 
            {
                anim.SetTrigger(walkHash);
                justAttacked = false;

            }
        }
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    void Attack()
    {

        anim.SetTrigger(attackHash);
        justAttacked = true;
    }

}
