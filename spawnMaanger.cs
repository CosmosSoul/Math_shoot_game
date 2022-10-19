using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMaanger : MonoBehaviour
{

    public GameObject[] enemyArray;
    public GameObject powerUp;

    public float zRange = 15f;
    public float xSpawn = 11f;
    public float ySpawn = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("SpawnRandomEnemy", 2, 5);
    }

    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(xSpawn, -xSpawn);
        float randomZ = Random.Range(zRange, -zRange);

        Vector3 randomPosition = new Vector3(randomX, ySpawn, randomZ);
        int randomIndex = Random.Range(0, enemyArray.Length);

        Instantiate(enemyArray[randomIndex], randomPosition, enemyArray[randomIndex].transform.rotation);
    }
}
