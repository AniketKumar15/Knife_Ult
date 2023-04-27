using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KinfeRefill : MonoBehaviour
{
    public GameManager gameManager;
    public int maxThrow = 10;
    public int price = 300;
    public bool isAbleToBuy = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.BuyText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && gameManager.throwingKinfe.totalThrows < maxThrow && GameManager.cash >= price && isAbleToBuy == true)
        {
            gameManager.throwingKinfe.totalThrows += 10;
            GameManager.cash -= price;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameManager.throwingKinfe.totalThrows < maxThrow && GameManager.cash >= price)
            {
                gameManager.BuyText.text = "Press F to Get 10 Knife : " + price + " Rupees";
                isAbleToBuy = true;
            }
            else if(GameManager.cash < price)
            {
                gameManager.BuyText.text = "You Have Not Enough Money [Price : " + price + "]";
            }
            else
            {
                gameManager.BuyText.text = "Knife Is Full";
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.BuyText.text = " ";
        isAbleToBuy = false;
    }
}
