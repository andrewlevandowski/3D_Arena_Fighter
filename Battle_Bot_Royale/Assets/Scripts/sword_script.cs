using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_script : MonoBehaviour {

    Animator anim;
    AudioSource audio;
    int swingHash = Animator.StringToHash("isSwinging");
    float lastSwing = 0.0f;
    public AudioClip swingSound;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.clip = swingSound;
    }

    // Update is called once per frame
    void Update()
    {
        //timer for swing cooldown
        if (Input.GetMouseButtonDown(0) && (lastSwing + 1f) < Time.time)
        {
            anim.SetTrigger(swingHash);
            audio.Play();
            lastSwing = Time.time;
        }
    }
}
