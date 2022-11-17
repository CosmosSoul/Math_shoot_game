using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spawnManager : MonoBehaviour
{

    public GameObject[] enemyArray;
    public GameObject powerUp;
    public GameObject scoreScript;
    //public TextMeshProUGUI scoreText;

    public float zRange = 15f;
    public float xSpawn = 11f;
    public float ySpawn = 1f;

    public float spawnStartDelay = 2f;
    public float spawnRespawnDelay = 3f;
    public gameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // ATTEMPTING TO STOP SPAWNING WHEN GAME IS OVER WITH gameActive bool
        //gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        //gameManager.gameActive = true;
        //if (gameManager.gameActive)
        //{
            //Enemy spawn and powerup spawn start and repeat at set interval
            InvokeRepeating("SpawnRandomEnemy", spawnStartDelay, spawnRespawnDelay);
            InvokeRepeating("SpawnPowerUp", spawnStartDelay, spawnRespawnDelay + 10);
       // }
       //scoreScript = GameObject.Find("scoreScript");
           // gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        

    }

    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(xSpawn, -xSpawn);
        float randomZ = Random.Range(zRange, -zRange);

        Vector3 randomPosition = new Vector3(randomX, ySpawn, randomZ);
        int randomIndex = Random.Range(0, enemyArray.Length);

        Instantiate(enemyArray[randomIndex], randomPosition, enemyArray[randomIndex].transform.rotation);
    }

    void SpawnPowerUp()
    {
        float randomX = Random.Range(xSpawn, -xSpawn);
        float randomZ = Random.Range(zRange, -zRange);

        Vector3 randomPosition = new Vector3(randomX, ySpawn, randomZ);
        
        Instantiate(powerUp, randomPosition, powerUp.transform.rotation);
    }

    void SpawnTings()
    {
        SpawnPowerUp();
        SpawnRandomEnemy();
    }
}