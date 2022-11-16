using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUp : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody objectRb;
    public float speed = 10.0f;
    public float zBound = -15f;
    // Start is called before the first frame update.
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.back * speed);

        if (objectRb.transform.position.z < zBound)
        {
            Destroy(gameObject);
        }
    }
}
