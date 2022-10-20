using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    

    public bool addShotActive;
    public bool subShotActive;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        startRotation = transform.rotation;
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


