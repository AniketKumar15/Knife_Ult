using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefill : MonoBehaviour
{
    public GameManager gameManager;
    public int heathRefill = 100;
    public int price;
    public bool isAbleToBuy = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.BuyText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && gameManager.playerHealth.health < heathRefill && GameManager.cash >= price && isAbleToBuy == true)
        {
            gameManager.playerHealth.health = gameManager.playerHealth.maxHealth;
            GameManager.cash -= price;
            gameManager.BuyText.text = "Health Is Full";
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameManager.playerHealth.health < heathRefill && GameManager.cash >= price)
            {
                gameManager.BuyText.text = "Press F Full Health : " + price + " Rupees";
                isAbleToBuy = true;
            }
            else if (GameManager.cash < price)
            {
                gameManager.BuyText.text = "You Have Not Enough Money [Price : " + price + "]";
            }
            else
            {
                gameManager.BuyText.text = "Health Is Full";
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.BuyText.text = " ";
        isAbleToBuy = false;
    }
}
