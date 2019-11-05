using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handanimation : MonoBehaviour {
    public Animator hand_animator;

	// Use this for initialization
	void Start () {
        
    }
    void Awake()
    {
        hand_animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (hand_animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
        {
            hand_animator.SetBool("Attacking", false);
        }
        if (hand_animator.GetCurrentAnimatorStateInfo(0).IsName("Escaping"))
        {
            hand_animator.SetBool("Escaping", false);
        }
	}
}
