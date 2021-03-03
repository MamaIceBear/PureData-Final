using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float jumpPower = 10f;
    Rigidbody2D myRigidbody;
    bool isGrounded = false;

    void Start()
    {
       myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D other) 
    {
        if(other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
