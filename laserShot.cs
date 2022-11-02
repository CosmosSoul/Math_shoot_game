using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserShot : MonoBehaviour
{

    //public playerController playerController;
    //public gameManager gameManager;
    public scoreScript scoreScript;
    // Start is called before the first frame update
    void Start()
    {
        //playerController = GameObject.Find("Player Controller").GetComponent<playerController>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        scoreScript = GameObject.Find("Game Manager").GetComponent<scoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("enemy")) || (collision.gameObject.CompareTag("obstacle")))
        {
            Debug.Log("One " + collision.gameObject.tag + " has hit you, captain!");
            // scoreScript.scoreValue += 10;
            scoreScript.Test();
            scoreScript.AddPoint();
            Debug.Log(scoreScript.scoreValue);

        }
    }
}
