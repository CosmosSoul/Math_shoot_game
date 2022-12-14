using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float spawnRate = 1;
    public gameManager gameManager;
    public bool gameActive;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        // ATTEMPTING TO STOP SPAWNING WHEN GAME IS OVER WITH gameActive bool
        //gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        //gameManager.gameActive = true;
        //if (gameManager.gameActive)
        //{
        //Enemy spawn and powerup spawn start and repeat at set interval
        if (gameActive)
        {
            InvokeRepeating("SpawnRandomEnemy", spawnStartDelay, (spawnRate));
            InvokeRepeating("SpawnPowerUp", spawnStartDelay, spawnRate + 10);
        }
       // }
       //scoreScript = GameObject.Find("scoreScript");
           // gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        

    }

    public void StartGame(float difficulty)
    {
        gameActive = true;
        spawnRate /= difficulty;
        
        //SceneManager.LoadScene("My Game_v0.1");
        gameManager.titleScreen.SetActive(false);
        
        StartCoroutine(SpawnRandomEnemy());
        

    }
    private void SetDifficulty()
    {
        StartGame(difficulty);
    }
    IEnumerator SpawnRandomEnemy()
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            float randomX = Random.Range(xSpawn, -xSpawn);
            float randomZ = Random.Range(zRange, -zRange);

            Vector3 randomPosition = new Vector3(randomX, ySpawn, randomZ);
            int randomIndex = Random.Range(0, enemyArray.Length);

            Instantiate(enemyArray[randomIndex], randomPosition, enemyArray[randomIndex].transform.rotation);
        }    
        
       }


    public void SpawnPowerUp()
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
