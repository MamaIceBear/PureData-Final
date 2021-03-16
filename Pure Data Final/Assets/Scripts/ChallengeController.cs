using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    public GameObject[] challenges; 
    public float frequency = 0.9f;
    float counter = 0.0f;
    string previousObj = "";

    public Transform challengesSpawnPoint;
    public static bool gameStart = false;
    bool isGameOver = false;
    bool crashSound = true;

    void Start()
    {
        GenerateRandomChallenge();
    }

    void Update()
    {
        if(gameStart)
        {
            if(isGameOver)
            {
                if(crashSound)
                {
                    OSCHandler.Instance.SendMessageToClient("pd", "/unity/crash", 1);
                    crashSound = false;
                }
                return;
            }
            //Generate Objects
            if(counter <= 0f)
            {
                GenerateRandomChallenge();
            }
            else
            {
                counter -= Time.deltaTime * frequency;
            }

            //Scrolling
            GameObject currentChild;
            for(int i = 0; i < transform.childCount; i++)
            {
                currentChild = transform.GetChild(i).gameObject;
                ScrollChallenge(currentChild);
                if(currentChild.transform.position.x <= -20.0f)
                {
                    Destroy(currentChild);
                }
            }
        }
    }

    void ScrollChallenge(GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GenerateRandomChallenge()
    {
        GameObject chosenChallenge = challenges[Random.Range(0, challenges.Length)];
        while(previousObj == chosenChallenge.name)
        {
            chosenChallenge = challenges[Random.Range(0, challenges.Length)];
        }
        GameObject newChallenge = Instantiate(chosenChallenge, challengesSpawnPoint.transform);
        newChallenge.transform.parent = transform;
        previousObj = chosenChallenge.name;
        counter++;
        
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
