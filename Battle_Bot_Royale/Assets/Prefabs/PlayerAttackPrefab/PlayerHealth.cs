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
    public AudioClip damagedSound;
    //may change this to an integer and just display it on screen
    public Slider healthSlider;

    AudioSource playerAudio;
    //PlayerMovement playerMovement;
    //playerAttack playerAttack;
    bool isDead;
    bool damaged;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        //playerMovement = GetComponent<PlayerMovement>();
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

        healthSlider.value = currentHealth;

        //set sound to death clip so hurt animation doesn't play
        //playerAudio.clip = deathClip;
        playerAudio.Play();
        
        if(currentHealth<=0)
        {
            isDead = true;

            //playerAttack.enabled = false;
            //playerMovement.enabled = false;

        }
    }
}
