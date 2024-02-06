using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: Ensure RigidBody component is attached to player
public class JumpIntensity : MonoBehaviour
{
    public Rigidbody rb;
    public bool isGrounded = true;
    float jumpForce = 10;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (jumpForce == 10)
            {
                jumpForce = 15;
            } else if (jumpForce == 15)
            {
                jumpForce = 5;
            } else if(jumpForce == 5)
            {
                jumpForce = 10;
            }
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
