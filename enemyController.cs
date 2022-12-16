using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    //public int enemyLife = 5;
    public int enemyMaxHealth = 5;
    public int enemyCurrentHealth;
    public TextMeshProUGUI enemyLifeText;

    public GameObject enemyLife;

    // Start is called before the first frame update
    void Start()
    {
        //enemyLifeText.text = randomEnemyLife.ToString();
        enemyCurrentHealth = Random.Range(-enemyMaxHealth, enemyMaxHealth);
        enemyLifeText.text = "" + enemyCurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
