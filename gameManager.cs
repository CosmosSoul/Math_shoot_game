using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public GameObject restartButton;
    public GameObject titleScreen;
    public bool gameActive = true;
    // Start is called before the first frame update
    void Start()
    {
       // titleScreen = GameObject.Find("Title Screen");
        gameActive = false;
        restartButton.SetActive(false);
        titleScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("My Game_v0.1");
    }
}
