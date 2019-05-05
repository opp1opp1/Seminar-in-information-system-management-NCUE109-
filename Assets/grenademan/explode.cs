using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{

    float timer = 2;
    float countdown;
    float radius = 3;
    float force = 500;
    bool hasExploded;

    [SerializeField] GameObject exploParticle;

    // Use this for initialization
    void Start()
    {
        countdown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0 && !hasExploded)
        {
            explode();
        }
    }

    void explode()
    {
        //GameObject spawnedParticle =  Instantiate(exploParticle, transform.position, transform.rotation);
        GameObject spawnedParticle = exploParticle;
        Destroy(spawnedParticle, 1);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        hasExploded = true;

        Destroy(gameObject);

    }
}
