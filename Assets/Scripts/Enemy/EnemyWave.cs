using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWave : MonoBehaviour
{
    public GameObject[] enemy;
    public float timer;
    float maxTime = 5;
    public Transform[] spawnPoint;
    public Text numberOfEnemy;
    public Text killCountText;
    public static int aliveEnemy = 0;
    public static int killCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        aliveEnemy = 0;
        killCount = 0;

        timer = maxTime;
        numberOfEnemy.text = "Enemy Alive : " + aliveEnemy;
        killCountText.text = "Kill : " + killCount;

       
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        
        if (timer <= 0)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);
            timer = maxTime;
            aliveEnemy++;
        }

        numberOfEnemy.text = "Enemy Alive : " + aliveEnemy;
        killCountText.text = "Kill : " + killCount;

        


    }
}
