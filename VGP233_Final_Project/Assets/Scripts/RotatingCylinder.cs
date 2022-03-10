using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCylinder : MonoBehaviour
{    
    public GameObject rotatingObject;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); //rotates 50 degrees per second around z axis
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = rotatingObject.transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {

            if (collision.gameObject.CompareTag("Player"))
                collision.transform.parent = null;

        

    }
}
