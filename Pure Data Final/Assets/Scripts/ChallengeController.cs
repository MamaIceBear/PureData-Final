using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    public GameObject[] challenges; 
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform challengesSpawnPoint;

    void Start()
    {
        GenerateRandomChallenge();
    }

    void Update()
    {
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
            if(currentChild.transform.position.x <= -15.0f)
            {
                Destroy(currentChild);
            }
        }
    }

    void ScrollChallenge(GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GenerateRandomChallenge()
    {
        GameObject newChallenge = Instantiate(challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.transform);
        newChallenge.transform.parent = transform;
        counter++;
    }
}
