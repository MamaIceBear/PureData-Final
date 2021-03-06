﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float jumpPower = 10f;
    Rigidbody2D myRigidbody;
    public int numJumps = 1;
    float posX = 0.0f;
    bool isGameOver = false;
    ChallengeController myChallengeController;
    public ParticleSystem dust;

    void Start()
    {
       myRigidbody = GetComponent<Rigidbody2D>();
       posX = transform.position.x;
       myChallengeController = GameObject.FindObjectOfType<ChallengeController>();
    }

    void Update() 
    {
        if(ChallengeController.gameStart)
        {
            if(Input.GetKeyDown(KeyCode.Space) && numJumps > 0 && !isGameOver)
            {
                myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
                numJumps -= 1;
                OSCHandler.Instance.SendMessageToClient("pd", "/unity/jump", 1);
                OSCHandler.Instance.SendMessageToClient("pd", "/unity/height", transform.position.y);
            }
            if(transform.position.x < posX)
            {
                GameOver();
            }
        }
    }


    void GameOver()
    {
        isGameOver = true;
        myChallengeController.GameOver();
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/musicStart", 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Ground")
        {
            dust.Play();
            numJumps = 1;
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/landing", 1);
        }
        if(other.collider.tag == "Hazard")
        {
            isGameOver = true;
            Debug.Log("WOMP WOMP");
        }
    }
}
