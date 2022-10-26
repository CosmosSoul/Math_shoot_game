using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public static scoreScript instance;

    public int scoreValue = 0;
    //public int hiScoreValue = 0;
    public Text scoreText;
    //public Text hiScoreText;

    private void Awake()
    {
        //instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       // scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "Score Current: " + scoreValue;

        //trying new tutorial for updating score
        //scoreText.text = "Score: "+ scoreValue.ToString();
    }

    public void AddPoint()
    {
        scoreValue += 10;
        scoreText.text = "Score: " + scoreValue.ToString();
    }
}
