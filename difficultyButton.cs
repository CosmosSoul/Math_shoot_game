using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class difficultyButton : MonoBehaviour
{
    private Button button;
    private gameManager gameManager;
    private spawnManager spawnManager;
    public float difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<spawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDifficulty()
    {
        spawnManager.StartGame(difficulty);
        gameManager.gameActive = true;
    }
}
