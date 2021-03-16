using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 15f;
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/musicStart", 1);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/toggle", 1);
            ChallengeController.gameStart = true;
            Destroy(this.gameObject);
        }
    }
}
