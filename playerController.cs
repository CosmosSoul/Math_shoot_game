using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float moveSpeed = 15f;
    public float zBound = 12; 

    private Rigidbody playerRb;
    [SerializeField]
    public Quaternion startRotation;
    public GameObject laserShotAdd;
    public GameObject laserShotSub;
     /*
    public Text scoreText;
    private int currentScore = 0;
    public Text hiScoreText;
    public int hiScore = 0;
     */


    public scoreScript scoreScript;

    public bool addShotActive;
    public bool subShotActive;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        startRotation = transform.rotation;
        // scoreScript.instance.AddPoint();
        scoreScript = GameObject.Find("Game Manager").GetComponent<scoreScript>();
        

        // scoreText.text = "Score Hs: ";

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        constrainZ();
        shotsFired();

    }

    void shotsFired()
    {
        Vector3 shotPosition = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, playerRb.transform.position.z - 1);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserShotSub, shotPosition, startRotation);
        }
        
    }

    void movePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.left * horizontalInput * moveSpeed);
        playerRb.AddForce(Vector3.back * verticalInput * moveSpeed);

    }

    void constrainZ()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);


            //Trying to fix glitch where object rapidly moves to one side when touching zbound
            //transform.rotation = Quaternion.Slerp(transform.rotation, startRotation, Time.time * 1);
            playerRb.velocity = new Vector3(0, 0, 0);
        }

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);


            playerRb.velocity = new Vector3(0, 0, 0);
        }

        //Good for 2D movement? but if colliding with object, center of gravity(?) changes and then directions get mixed up
        //transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * moveSpeed);
        //verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.back * verticalInput * Time.deltaTime * moveSpeed);
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
            //scoreScript.scoreText.text = "Score(pc): " + scoreScript.scoreValue;
            


            // Attempting to use script communication with "scoreScript" to update score.

            // scoreScript.scoreText = scoreScript.scoreValue.ToString();
            //scoreScript.instance.AddPoint();
            // scoreScript.instance.scoreText = "Score: " + scoreScript.instance.scoreValue;
            // Debug.Log(scoreScript.instance.scoreValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerUp"))
        {
            Destroy(other.gameObject);

           
        }
    }
}


