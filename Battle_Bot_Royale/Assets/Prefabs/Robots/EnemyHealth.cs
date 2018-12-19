using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//outline taken from: "https://unity3d.com/learn/tutorials/projects/survival-shooter/harming-enemies?playlist=17144"
public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;
    public AudioClip weaponHit;
    public AudioClip deathClip;

    Animator anim;


    int deadHash = Animator.StringToHash("isDead");

    NavMeshAgent navmesh;
    AudioSource enemyAudio;
    MeshCollider meshCollider;
    ParticleSystem hitParticles;        //if we want to make an animation when robots get hit
    bool isDead;
    bool dissapear;

    void Awake()
    {
        //set up links to external stuff
        enemyAudio = GetComponent<AudioSource>();
        meshCollider = GetComponent<MeshCollider>();
        navmesh = GetComponent<NavMeshAgent>();
        currentHealth = startingHealth;
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // decide when to make the enemy model dissapear
        if (dissapear)
        {
            //Not sure how we want to handle this yet
        }
    }

    //took out "Vector3 hitPoint"
    public void TakeDamage(int amount)
    {
        
        if (isDead)
           
            return;

        enemyAudio.clip = weaponHit;

        enemyAudio.Play();

        currentHealth -= amount;

        //hitParticles.transform.position = hitPoint;

        //hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        anim.SetTrigger(deadHash);
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        GameSingleton.instance.enemyAmount--;
        //meshCollider.isTrigger = true;
        navmesh.speed = 0;

        dissapear = true;

        //destroys game object after 2 seconds may want to change this depending on how we want the enemies to dissapear.
        Destroy(gameObject, 2f);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Weapon")
        {
            TakeDamage(25);
            
        }
    }
}
