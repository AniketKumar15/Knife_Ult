using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Cash")]
    public static int cash = 0;
    public Text cashText;

    [Header("KnifeRefill")]
    public ThrowingTutorial throwingKinfe;
    public Text BuyText;

    [Header("HealthRefill")]
    public PlayerHealth playerHealth;

    [Header("GameOver")]
    public GameObject gameOverScreen;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        cash = 0;
        cashText.text = "Money :" + cash;
        gameOverScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        
    }

    // Update is called once per frame
    void Update()
    {
        Cash();
        Retry();
    }

    public void Cash()
    {
        cashText.text = "Money :" + cash;
    }
    public void PlayGame()
    {
        playerHealth.enabled = true;
    }
    public void Retry()
    {
        if (isGameOver == true && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
