using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllScript : MonoBehaviour {
    private Animator _animator;
    private GameObject player;
    // Use this for initialization
    void Start () {
        _animator = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        LevelChecker();
	}
    void LevelChecker(){
        if (player.GetComponent<PlayerRotation>().enemychecker == false)
        {
            _animator.SetBool("LevelCompleteChecker", true);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Opening"))
        {
            _animator.SetBool("DoorisOpened", true);
        }
    }
}
