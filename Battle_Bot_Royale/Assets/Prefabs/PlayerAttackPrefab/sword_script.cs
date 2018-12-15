using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_script : MonoBehaviour {

    Animator anim;
    int swingHash = Animator.StringToHash("isSwinging");
    float lastSwing = 0.0f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //!anim.GetCurrentAnimatorStateInfo(0).IsName("sword_swing")
        if (Input.GetMouseButtonDown(0) && (lastSwing + 1f) < Time.time)
        {
            anim.SetTrigger(swingHash);
            lastSwing = Time.time;
        }
    }
}
