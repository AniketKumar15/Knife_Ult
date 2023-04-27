using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        // check if you hit an enemy
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            playerHealth.TakeDamage(damage);
            AudioManager.instance.Play("Hurt");

            // destroy projectile
            Destroy(gameObject);
        }

        Destroy(gameObject,2f);
    }
}
