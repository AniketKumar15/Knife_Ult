using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int dropCash;
   

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            EnemyWave.aliveEnemy--;
            EnemyWave.killCount++;
            GameManager.cash += dropCash;
            AudioManager.instance.Play("Kill");
            Destroy(gameObject);
        }
    }
    
    
}
