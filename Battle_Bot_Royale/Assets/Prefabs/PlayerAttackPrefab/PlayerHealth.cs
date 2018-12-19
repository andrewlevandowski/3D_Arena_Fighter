using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//outline taken from: "https://unity3d.com/learn/tutorials/projects/survival-shooter/player-health?playlist=17144"
public class PlayerHealth : MonoBehaviour {

    /*
     *TODO: GET RID OF COMMENTS ON PLAYER ATTACK AND MOVEMENT WHEN THOSE SCRIPTS ARE WRITTEN 
     */

    public int startingHealth = 100;
    public int currentHealth;
    public AudioClip punchSound1;
    public AudioClip punchSound2;
    public AudioClip punchSound3;
    public AudioClip punchSound4;
    public AudioClip punchSound5;

    public AudioClip deathSound;
    //may change this to an integer and just display it on screen
    public Slider healthSlider;

    AudioSource playerAudio;
    AudioSource playerAudio0;
    CharacterController playerMovement;
    System.Random rnd = new System.Random();
    //playerAttack playerAttack;
    bool isDead;
    bool damaged;

    private void Awake()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        playerAudio0 = sources[0];
        playerAudio = sources[1];
        playerAudio.volume = 0.4f;
        playerMovement = GetComponent<CharacterController>();
        //playerAttack = GetComponent<PlayerAttack>();
        currentHealth = startingHealth;
    }

    private void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        //healthSlider.value = currentHealth;

        //set sound to death clip so hurt animation doesn't play
        //playerAudio.clip = deathClip;
        int iCase = rnd.Next(1, 6);
        switch (iCase)
        {
            case 1:
                playerAudio.clip = punchSound1;
                break;
            case 2:
                playerAudio.clip = punchSound2;
                break;
            case 3:
                playerAudio.clip = punchSound3;
                break;
            case 4:
                playerAudio.clip = punchSound4;
                break;
            case 5:
                playerAudio.clip = punchSound5;
                break;
            default:
                playerAudio.clip = punchSound5;
                break;
        }


        
        playerAudio.Play();

        if (currentHealth <= 0 && isDead == false)
        {
            isDead = true;
            playerAudio0.clip = deathSound;
            playerAudio0.Play();
            //playerAttack.enabled = false;
            playerMovement.enabled = false;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
            TakeDamage(1);
        /*if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy detected hit");
            //lose health
        }*/
    }
}
