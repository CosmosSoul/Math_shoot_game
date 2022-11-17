using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDown : MonoBehaviour
{

    private Rigidbody objectRb;
    public float speed = 5.0f;
    public float zBound = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * speed);
        
        if (objectRb.transform.position.z > zBound)
        {
            Destroy(gameObject);
            
        }
    }
}
