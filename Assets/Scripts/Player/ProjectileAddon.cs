using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage = 20;
    

    private Rigidbody rb;

    private bool targetHit;

    public GameObject impactEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        // check if you hit an enemy
        if (collision.gameObject.GetComponent<BasicEnemy>() != null)
        {
            BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();

            enemy.TakeDamage(damage);

            // destroy projectile
            Destroy(gameObject);
        }

        //// make sure projectile sticks to surface
        //rb.isKinematic = true;

        //// make sure projectile moves with target
        //transform.SetParent(collision.transform);

        GameObject Impact = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(Impact, 2f);

        Destroy(gameObject,1f);

        
    }
}