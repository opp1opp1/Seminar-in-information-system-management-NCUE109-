using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangYuAnimation : MonoBehaviour {
    public Animator XiangYu_animator;
   
    // Use this for initialization
    void Start () {
        XiangYu_animator = this.GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (XiangYu_animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"))
        {
            XiangYu_animator.SetBool("Attacking", false);
        }
    }
}
