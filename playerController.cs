using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerController : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float moveSpeed = 15f;
    public float zBound = 12;
    public int lives = 3;

    private Rigidbody playerRb;
    [SerializeField]
    public Quaternion startRotation;
    
    public GameObject laserShotSub;
    public GameObject laserShotPlus;
    public GameObject plusSymbol;
    public GameObject minusSymbol;
    public ParticleSystem thrusterParticles;
   
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI shotStateText;
    public TextMeshProUGUI livesText;
    
    private int currentScore = 0;

    private gameManager gameManager;
    private spawnManager spawnManager;
    //private laserShot laserShot;
    /*
  public Text hiScoreText;
  public int hiScore = 0;
   */


    public scoreScript scoreScript;

    public bool addShotActive;
    public bool subShotActive;
    public bool laserState;



    private void Awake()
    {
        livesText.text = "Lives: " + lives;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        thrusterParticles.Stop();

        playerRb = GetComponent<Rigidbody>();
        startRotation = transform.rotation;
        // scoreScript.instance.AddPoint();
        scoreScript = GameObject.Find("Game Manager").GetComponent<scoreScript>();
        gameOverText.gameObject.SetActive(false);
        gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<spawnManager>();
        //laserShot = GameObject.Find("laserShot").GetComponent<laserShot>();
        shotStateText.text = "Shot Type: + ";
        minusSymbol.gameObject.SetActive(false);
        plusSymbol.gameObject.SetActive(false);
        

        // scoreText.text = "Score Hs: ";

    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + lives;
        constrainZ();

        if (gameManager.gameActive)
        {
            movePlayer();
            shotsFired();
            changeLaserState();
            
        }

    }

    void changeLaserState()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            laserState = true;
            shotStateText.text = "Shot Type: + ";
            plusSymbol.gameObject.SetActive(true);
            minusSymbol.gameObject.SetActive(false);
            Debug.Log(laserState);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            laserState = false;
            shotStateText.text = "Shot Type: - ";
            Debug.Log(laserState);
            plusSymbol.gameObject.SetActive(false);
            minusSymbol.gameObject.SetActive(true);
        }
    }


    void shotsFired()
    {
        if (laserState)
        {
            Vector3 shotPosition = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, playerRb.transform.position.z - 1);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(laserShotPlus, shotPosition, startRotation);
            }
        }
        else if (!laserState)
        {
            Vector3 shotPosition = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, playerRb.transform.position.z - 1);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(laserShotSub, shotPosition, startRotation);
            }
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

        if (transform.position.z < -zBound - 15)
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
        if ((collision.gameObject.CompareTag("plusEnemy")) || (collision.gameObject.CompareTag("minusEnemy")))
        {
            Debug.Log("One " + collision.gameObject.tag + " has hit you, captain!");
            lives -= 1;
            livesText.text = "lives: " + lives;
            Debug.Log( lives + " Lives Remaining!");

            if (lives <= 0)
            {
                // scoreScript.scoreValue += 10;
                // scoreScript.Test();
                //
                //
                //
                //   scoreScript.AddPoint();
                Debug.Log(scoreScript.scoreValue);
                gameOverText.gameObject.SetActive(true);
                gameManager.restartButton.SetActive(true);
                gameManager.gameActive = false;
            }
            //spawnManager.CancelInvoke("SpawnRandomEnemy");
            //scoreScript.scoreText.text = "Score(pc): " + scoreScript.scoreValue;

            // Attempting to use script communication with "scoreScript" to update score.

            // scoreScript.scoreText = scoreScript.scoreValue.ToString();
            //scoreScript.instance.AddPoint();
            // scoreScript.instance.scoreText = "Score: " + scoreScript.instance.scoreValue;
            // Debug.Log(scoreScript.instance.scoreValue);
        }

        

    }

    IEnumerator ThrusterActivate()
    {
        thrusterParticles.Play();
        moveSpeed *= 4;
        yield return new WaitForSeconds(5.0f);
        moveSpeed /= 4;
        thrusterParticles.Stop();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerUp"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ThrusterActivate());
            //Add speed increase
            
        }
    }
}


