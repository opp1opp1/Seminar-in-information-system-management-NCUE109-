using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {
    private NavMeshAgent agent;
    public GameObject Player;
    public float WakeUpDistance = 5.0f;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < WakeUpDistance)
        {
            //Vector3 dirToPlayer = transform.position - Player.transform.position;
            //Vector3 newPos = transform.position + dirToPlayer;
            Vector3 newPos = Player.transform.position;
            agent.SetDestination(newPos);
        }
	}
}
