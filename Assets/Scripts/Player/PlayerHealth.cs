using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public Text playerHealthBar;
    public GameObject MainCam;
    public GameManager gameManager;
   

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        playerHealthBar.text = "Hralth : " + health;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            MainCam.SetActive(true);
            gameObject.SetActive(false);
            gameManager.gameOverScreen.SetActive(true);
            gameManager.isGameOver = true;
            
            
        }
    }
}
