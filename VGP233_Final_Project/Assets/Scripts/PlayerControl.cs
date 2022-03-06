using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Vector3 move;
    

    [SerializeField] private Rigidbody body;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 moveVector = transform.TransformDirection(move) * speed;
        body.velocity = new Vector3(moveVector.x, body.velocity.y, moveVector.z);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
