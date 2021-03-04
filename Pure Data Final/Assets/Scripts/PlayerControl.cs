using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float jumpPower = 10f;
    Rigidbody2D myRigidbody;
    bool isGrounded = false;
    float posX = 0.0f;
    bool isGameOver = false;
    ChallengeController myChallengeController;

    void Start()
    {
       myRigidbody = GetComponent<Rigidbody2D>();
       posX = transform.position.x;
       myChallengeController = GameObject.FindObjectOfType<ChallengeController>();
    }

    void FixedUpdate() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
        }
        if(transform.position.x < posX)
        {
            GameOver();
        }
    }

    void Update() 
    {
        
    }

    void GameOver()
    {
        isGameOver = true;
        myChallengeController.GameOver();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        if(other.collider.tag == "Hazard")
        {
            isGameOver = true;
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
