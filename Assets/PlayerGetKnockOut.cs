using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetKnockOut : MonoBehaviour {
    private Transform m_transform;
    // Use this for initialization
    void Start () {
        m_transform = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_transform.position.y > 20 || m_transform.position.y < -20)
{
            Destroy(gameObject);
        }
    }
    }
